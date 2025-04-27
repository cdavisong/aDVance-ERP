using System.ComponentModel;
using System.IO.Compression;
using System.Runtime.InteropServices;

using IWshRuntimeLibrary;

namespace aDVanceINSTALL.Desktop.MVP.Vistas {
    public partial class VistaProgresoInstalacion : Form {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

        public VistaProgresoInstalacion() {
            InitializeComponent();
            EstablecerColorBarraProgreso(fieldBarraProgreso, Color.Firebrick);
        }

        public string? DirectorioInstalacion { get; set; }

        private void EstablecerColorBarraProgreso(ProgressBar pBar, Color newColor) {
            SendMessage(pBar.Handle, 1040, newColor.ToArgb(), IntPtr.Zero);
        }

        public void InstalarAplicacion() {
            // Ejecutar instalación en segundo plano
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += (s, e) => InstalarAplicacion(worker, e);
            worker.ProgressChanged += (s, e) => {
                fieldBarraProgreso.Value = e.ProgressPercentage;
                fieldInfo.Text = e.UserState?.ToString();
            };
            worker.RunWorkerCompleted += (s, e) => {
                if (e.Error != null) {
                    fieldInfo.Text = "ERROR: " + e.Error.Message;
                } else {
                    Hide();
                }
            };
            worker.RunWorkerAsync();
        }

        private void InstalarAplicacion(BackgroundWorker worker, DoWorkEventArgs e) {
            worker.ReportProgress(0, "Creando directorios...");
            Thread.Sleep(250);
            if (!Directory.Exists(DirectorioInstalacion))
                Directory.CreateDirectory(DirectorioInstalacion);
            else {
                worker.ReportProgress(2, "Eliminando versión anterior...");
                Thread.Sleep(2250);
                Directory.Delete(DirectorioInstalacion, true);
                Directory.CreateDirectory(DirectorioInstalacion);
            }

            worker.ReportProgress(10, "Descomprimiendo archivos...");
            Thread.Sleep(500);
            ExtraerArchivoZip("aplicacion.zip", DirectorioInstalacion, worker);

            worker.ReportProgress(90, "Configurando aplicación...");
            Thread.Sleep(350);
            CrearArchivoConfiguracion(DirectorioInstalacion);

            worker.ReportProgress(92, "Creando acceso directo...");
            Thread.Sleep(500);
            var rutaEjecutable = $"{DirectorioInstalacion}\\aDVanceERP.Desktop.exe";
            CrearAccesoDirecto(nombreAcceso: "aDVance ERP",
                rutaEjecutable: rutaEjecutable,
                argumentos: "--modo-empresa",
                directorioTrabajo: Path.GetDirectoryName(rutaEjecutable),
                descripcion: "Sistema de gestión empresarial aDVance ERP",
                icono: rutaEjecutable + ",0");

            worker.ReportProgress(100, "Instalación completada!");
            Thread.Sleep(2000);
        }

        private void ExtraerArchivoZip(string archivoZip, string directorioInstalacion, BackgroundWorker worker) {
            try {
                // 1. Validar parámetros
                if (string.IsNullOrWhiteSpace(archivoZip))
                    throw new ArgumentException("La ruta del archivo ZIP no puede estar vacía");

                if (string.IsNullOrWhiteSpace(directorioInstalacion))
                    throw new ArgumentException("El directorio de destino no puede estar vacío");

                if (!System.IO.File.Exists(archivoZip))
                    throw new FileNotFoundException($"El archivo ZIP no existe: {archivoZip}");

                // 2. Abrir el archivo ZIP
                using (ZipArchive archive = ZipFile.OpenRead(archivoZip)) {
                    int totalArchivos = archive.Entries.Count;
                    int archivosProcesados = 0;

                    worker.ReportProgress(11, $"Iniciando descompresión de {totalArchivos} archivos...");
                    Thread.Sleep(1000);

                    // 3. Procesar cada entrada en el ZIP
                    foreach (ZipArchiveEntry entry in archive.Entries) {
                        if (worker.CancellationPending)
                            return;

                        try {
                            string rutaCompleta = Path.Combine(directorioInstalacion, entry.FullName);

                            // Para directorios
                            if (string.IsNullOrEmpty(entry.Name)) {
                                Directory.CreateDirectory(rutaCompleta);
                                continue;
                            }

                            // Crear directorio padre si no existe
                            string directorioPadre = Path.GetDirectoryName(rutaCompleta);
                            if (!Directory.Exists(directorioPadre))
                                Directory.CreateDirectory(directorioPadre);

                            // Extraer archivo
                            entry.ExtractToFile(rutaCompleta, overwrite: true);

                            archivosProcesados++;
                            int porcentaje = (int) ((double) archivosProcesados / totalArchivos * 100);

                            worker.ReportProgress(
                                11 + (79 * porcentaje / 100),
                                $"Extrayendo: {entry.Name} ({archivosProcesados}/{totalArchivos})");
                            Thread.Sleep(250);
                        } catch (Exception ex) {
                            worker.ReportProgress(0, $"Error al extraer {entry.FullName}: {ex.Message}");
                            // Continuar con el siguiente archivo
                        }
                    }
                }

                worker.ReportProgress(90, "Descompresión completada exitosamente!");
                Thread.Sleep(250);
            } catch (Exception ex) {
                worker.ReportProgress(0, $"ERROR CRÍTICO: {ex.Message}");
                throw; // Relanzar para manejo superior
            }
        }

        private void CrearArchivoConfiguracion(string directorioInstalacion) {
            string configPath = Path.Combine(directorioInstalacion, "config.ini");
            System.IO.File.WriteAllText(configPath, "[Settings]\nInstallPath=" + directorioInstalacion);
        }

        private void CrearAccesoDirecto(string nombreAcceso, string rutaEjecutable,
                                     string argumentos = "", string directorioTrabajo = "",
                                     string descripcion = "", string icono = "") {
            try {
                // Obtener ruta del escritorio
                string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string rutaAcceso = Path.Combine(escritorio, nombreAcceso + ".lnk");

                // Crear el objeto WScript.Shell
                WshShell shell = new WshShell();
                IWshShortcut acceso = (IWshShortcut) shell.CreateShortcut(rutaAcceso);

                // Configurar propiedades del acceso directo
                acceso.TargetPath = rutaEjecutable;
                acceso.Arguments = argumentos;
                acceso.WorkingDirectory = string.IsNullOrEmpty(directorioTrabajo) ?
                                         Path.GetDirectoryName(rutaEjecutable) : directorioTrabajo;
                acceso.Description = descripcion;

                if (!string.IsNullOrEmpty(icono)) {
                    acceso.IconLocation = icono;
                }

                acceso.Save(); // Guardar el acceso directo
            } catch (Exception ex) {
                throw new Exception($"Error al crear acceso directo: {ex.Message}");
            }
        }
    }
}
