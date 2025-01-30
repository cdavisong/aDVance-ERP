using System.Net;

namespace Manigest.Core.ClienteFTP.MVP.Modelos {
    public sealed class ClienteFTP {
        private ConfServidorFTP _config { get; }

        public ClienteFTP(string servidor, string nombreUsuario, string password) {
            _config = new ConfServidorFTP(servidor, nombreUsuario, password);
        }        

        public event EventHandler? ProgresoDescargaArchivo;
        public event EventHandler? ErrorDescarga;
        public event EventHandler? ErrorCarga;

        public string DescargarContenidoArchivo(string rutaArchivo) {
            var contenido = string.Empty;

            try {
                var peticion = (FtpWebRequest) WebRequest.Create($"ftp://{_config.Servidor}/{rutaArchivo}");

                peticion.Method = WebRequestMethods.Ftp.DownloadFile;
                peticion.Credentials = new NetworkCredential(_config.Usuario, _config.Password);

                using (var respuesta = (FtpWebResponse) peticion.GetResponse()) {
                    using (var sr = new StreamReader(respuesta.GetResponseStream())) {
                        contenido = sr.ReadToEnd();
                    }
                }
            } catch (WebException) {
                ErrorDescarga?.Invoke(this, EventArgs.Empty);
            }

            return contenido;
        }

        public void DescargarArchivo(string rutaRemotaArchivo, string rutaLocalArchivo) {
            try {
                var peticion = (FtpWebRequest) WebRequest.Create($"ftp://{_config.Servidor}/{rutaRemotaArchivo}");

                peticion.Method = WebRequestMethods.Ftp.DownloadFile;
                peticion.Credentials = new NetworkCredential(_config.Usuario, _config.Password);

                using (var respuesta = (FtpWebResponse) peticion.GetResponse()) {
                    using (var hiloRespuesta = respuesta.GetResponseStream()) {
                        using (var fs = new FileStream(rutaLocalArchivo, FileMode.Create)) {
                            var buffer = new byte[1024];
                            var bytesRecibidos = 0;
                            long bytesTotalesRecibidos = 0;
                            var bytesTotales = respuesta.ContentLength;

                            while ((bytesRecibidos = hiloRespuesta.Read(buffer, 0, buffer.Length)) > 0) {
                                fs.Write(buffer, 0, bytesRecibidos);
                                bytesTotalesRecibidos += bytesRecibidos;

                                var porciento = (int) (bytesTotalesRecibidos * 100 / bytesTotales);

                                ProgresoDescargaArchivo?.Invoke(porciento, EventArgs.Empty);
                            }
                        }
                    }
                }
            } catch (WebException) {
                ErrorDescarga?.Invoke(this, EventArgs.Empty);
            }
        }

        public void SubirArchivo(string rutaRemotaArchivo, string rutaLocalArchivo) {
            try {
                var peticion = (FtpWebRequest) WebRequest.Create($"ftp://{_config.Servidor}/{rutaRemotaArchivo}");
                var bufferDatos = new byte[1024];
                var bytesLeidos = 0;

                peticion.Method = WebRequestMethods.Ftp.UploadFile;
                peticion.Credentials = new NetworkCredential(_config.Usuario, _config.Password);

                using (var sourceStream = new FileStream(rutaLocalArchivo, FileMode.Open, FileAccess.Read)) {
                    using (var requestStream = peticion.GetRequestStream()) {
                        while ((bytesLeidos = sourceStream.Read(bufferDatos, 0, bufferDatos.Length)) > 0) {
                            requestStream.Write(bufferDatos, 0, bytesLeidos);
                        }
                    }
                }

                using (var response = (FtpWebResponse) peticion.GetResponse()) { }
            } catch (WebException) {
                ErrorCarga?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Eliminar(string rutaRemotaArchivo) {
            try {
                var peticion = (FtpWebRequest) WebRequest.Create($"ftp://{_config.Servidor}/{rutaRemotaArchivo}");

                peticion.Method = WebRequestMethods.Ftp.DeleteFile;
                peticion.Credentials = new NetworkCredential(_config.Usuario, _config.Password);

                using (var respuesta = (FtpWebResponse) peticion.GetResponse()) { }
            } catch (WebException) {
                ErrorCarga?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
