namespace Manigest.Core.Utiles {
    public static class UtilesConfServidores {
        public static List<string> ObtenerConfServidorMySQL() {
            if (!Directory.Exists(@".\settings") || !File.Exists(@".\settings\mysqlsrv.config"))
                return new List<string>() {
                    "127.0.0.1",
                    "manigest",
                    "admin",
                    "admin"
                };

            var objetoConf = new List<string>();

            using (var fs = new FileStream(@".\settings\mysqlsrv.config", FileMode.Open)) {
                using (var sr = new StreamReader(fs)) {
                    var datos = sr.ReadToEnd();
                    var datosSplit = datos.Split(';');
                    var modelo = new List<string>() {
                        datosSplit[0],
                        datosSplit[1],
                        datosSplit[2],
                        datosSplit[3]
                    };

                    objetoConf = modelo;
                }
            }

            return objetoConf;
        }

        public static string ObtenerStringConfServidorMySQL() {
            var stringConexion = VariablesGlobales.StringConexionBaseDatos;

            if (string.IsNullOrEmpty(stringConexion)) {
                var confServidorMySQL = ObtenerConfServidorMySQL();

                VariablesGlobales.StringConexionBaseDatos = $"server = {confServidorMySQL.ElementAt(0)}; user id = {confServidorMySQL.ElementAt(2)}; password = {confServidorMySQL.ElementAt(3)}; database = {confServidorMySQL.ElementAt(1)}; pooling = false;";
                stringConexion = VariablesGlobales.StringConexionBaseDatos;
            }

            return stringConexion;
        }

        public static List<string> ObtenerConfServidorFTP() {
            if (!Directory.Exists(@".\settings") || !File.Exists(@".\settings\ftpsrv.config"))
                return new List<string>() {
                    "127.0.0.1",
                    "admin",
                    "admin"
                };

            var objetoConf = new List<string>();

            using (var fs = new FileStream(@".\settings\ftpsrv.config", FileMode.Open)) {
                using (var sr = new StreamReader(fs)) {
                    var datos = sr.ReadToEnd();
                    var datosSplit = datos.Split(';');
                    var modelo = new List<string>() {
                        datosSplit[0],
                        datosSplit[1],
                        datosSplit[2]
                    };

                    objetoConf = modelo;
                }
            }

            return objetoConf;
        }
    }
}
