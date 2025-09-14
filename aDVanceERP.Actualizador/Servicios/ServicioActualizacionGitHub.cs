using aDVanceERP.Actualizador.Interfaces;
using aDVanceERP.Actualizador.Modelos;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace aDVanceERP.Actualizador.Servicios;

public class ServicioActualizacionGitHub : IServicioActualizacion {
    private readonly HttpClient _httpClient;
    private readonly string _repositoryOwner;
    private readonly string _repositoryName;

    public ServicioActualizacionGitHub(string propietarioRepositorio, string nombreRepositorio) {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "AutoUpdater");
        _repositoryOwner = propietarioRepositorio;
        _repositoryName = nombreRepositorio;
    }

    public async Task<InfoActualizacion> ComprobarActualizaciones(string versionActual, bool incluirPreActualizaciones = false) {
        try {
            var url = $"https://api.github.com/repos/{_repositoryOwner}/{_repositoryName}/releases";
            var response = await _httpClient.GetStringAsync(url);
            var releases = JsonConvert.DeserializeObject<GitHubRelease[]>(response);

            foreach (var release in releases) {
                if (release.PreRelease && !incluirPreActualizaciones)
                    continue;

                if (Version.TryParse(release.TagName.TrimStart('v', 'V').Replace("-alpha", string.Empty).Replace("-beta", string.Empty), out var releaseVersion)) {
                    var current = Version.Parse(versionActual);

                    if (releaseVersion > current) {
                        var asset = release.Assets?.Count > 0 ? release.Assets[0] : null;

                        return new InfoActualizacion {
                            UltimaVersion = releaseVersion,
                            UrlDescarga = asset?.DownloadUrl,
                            NotasVersion = release.Body,
                            FechaLanzamiento = release.PublishedAt,
                            TamanoArchivo = asset?.Size ?? 0,
                            EsPreActualizacion = release.PreRelease,
                            ActualizacionDisponible = true
                        };
                    }
                }
            }

            return new InfoActualizacion { ActualizacionDisponible = false };
        }
        catch (Exception ex) {
            throw new Exception("Error al verificar actualizaciones", ex);
        }
    }

    public async Task<bool> DescargarActualizacion(InfoActualizacion info, IProgress<double> progreso = null) {
        if (string.IsNullOrEmpty(info.UrlDescarga))
            return false;

        try {
            var tempPath = Path.GetTempPath();
            var fileName = Path.GetFileName(new Uri(info.UrlDescarga).LocalPath);
            var rutaArchivo = Path.Combine(tempPath, fileName);

            using (var response = await _httpClient.GetAsync(info.UrlDescarga, HttpCompletionOption.ResponseHeadersRead)) {
                response.EnsureSuccessStatusCode();

                var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                var receivedBytes = 0L;
                var buffer = new byte[8192];

                using (var contentStream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write)) {
                    int bytesRead;
                    while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0) {
                        await fileStream.WriteAsync(buffer, 0, bytesRead);
                        receivedBytes += bytesRead;

                        if (totalBytes > 0)
                            progreso?.Report((double)receivedBytes / totalBytes * 100);
                    }
                }
            }

            info.UrlDescarga = rutaArchivo; // Guardamos la ruta local
            return true;
        }
        catch (Exception ex) {
            throw new Exception("Error al descargar la actualización", ex);
        }
    }

    public void AplicarActualizacion(string rutaDescargaActualizacion) {
        if (!File.Exists(rutaDescargaActualizacion))
            throw new FileNotFoundException("Archivo de actualización no encontrado");

        try {
            var currentExe = Process.GetCurrentProcess().MainModule.FileName;
            var tempExe = Path.Combine(Path.GetTempPath(), Path.GetFileName(currentExe) + ".old");

            // Mover el ejecutable actual a temporal
            File.Move(currentExe, tempExe);

            // Copiar el nuevo ejecutable
            File.Copy(rutaDescargaActualizacion, currentExe);

            // Programar eliminación del archivo temporal
            File.Delete(tempExe);

            // Reiniciar la aplicación
            Process.Start(currentExe);
            Application.Exit();
        }
        catch (Exception ex) {
            throw new Exception("Error al aplicar la actualización", ex);
        }
    }
}