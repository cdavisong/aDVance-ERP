using aDVanceERP.Core.Modelos.BD;
using aDVanceERP.Core.Repositorios.Interfaces;

namespace aDVanceERP.Core.Repositorios.BD {
    public class RepoConfBd : IRepoConfBd<ConfBd> {
        private const string NombreArchivo = "confServidorMySQL.json";

        private List<ConfBd> _configuraciones;
        private readonly string _directorioRaiz;

        public RepoConfBd() {
            _configuraciones = new List<ConfBd>();
            _directorioRaiz = ".\\settings";
        }

        public ConfBd Obtener() {
            var rutaArchivo = Path.Combine(_directorioRaiz, NombreArchivo);

            if (File.Exists(rutaArchivo)) {
                var contenido = File.ReadAllText(rutaArchivo);
                _configuraciones = System.Text.Json.JsonSerializer.Deserialize<List<ConfBd>>(contenido) ?? new List<ConfBd>();
            } else {
                // Si el archivo no existe, retornar una configuración por defecto
                _configuraciones = new List<ConfBd> {
                    new ConfBd {
                        Servidor = "localhost",
                        BaseDatos = "advanceerp",
                        Usuario = "admin",
                        Password = "admin",
                        RecordarConfiguracion = true
                    }
                };
            }

            return _configuraciones.FirstOrDefault() ?? new ConfBd();
        }

        public IEnumerable<ConfBd> ObtenerTodos() {
            var rutaArchivo = Path.Combine(_directorioRaiz, NombreArchivo);

            if (File.Exists(rutaArchivo)) {
                var contenido = File.ReadAllText(rutaArchivo);
                _configuraciones = System.Text.Json.JsonSerializer.Deserialize<List<ConfBd>>(contenido) ?? new List<ConfBd>();
            } else {
                // Si el archivo no existe, retornar una lista vacía
                _configuraciones = new List<ConfBd>();
            }

            return _configuraciones;
        }

        public void Salvar(string directorio, ConfBd entidad) {
            if (string.IsNullOrWhiteSpace(directorio)) {
                directorio = _directorioRaiz;
            }
            if (entidad == null) {
                throw new ArgumentNullException(nameof(entidad), "La entidad no puede ser nula.");
            }
            if (!Directory.Exists(directorio)) {
                Directory.CreateDirectory(directorio);
            }

            var rutaArchivo = Path.Combine(_directorioRaiz, NombreArchivo);

            _configuraciones.Clear();
            _configuraciones.Add(entidad);

            var contenido = System.Text.Json.JsonSerializer.Serialize(_configuraciones, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });

            using (var stream = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write, FileShare.None)) {
                using (var writer = new StreamWriter(stream)) {
                    writer.Write(contenido);
                }
            }
        }
    }
}