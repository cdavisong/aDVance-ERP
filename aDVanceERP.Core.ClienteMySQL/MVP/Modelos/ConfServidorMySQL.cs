using aDVanceERP.Core.ClienteMySQL.MVP.Modelos.Plantillas;

namespace aDVanceERP.Core.ClienteMySQL.MVP.Modelos {
    public class ConfServidorMySQL : IConfServidorMySQL {
        public ConfServidorMySQL(string servidor, string baseDatos, string usuario, string password) {
            Servidor = servidor;
            BaseDatos = baseDatos;
            Usuario = usuario;
            Password = password;
        }

        public string Servidor { get; set; }

        public string BaseDatos { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }

        public override string ToString() {
            return $"{Servidor};{BaseDatos};{Usuario};{Password}";
        }
    }
}
