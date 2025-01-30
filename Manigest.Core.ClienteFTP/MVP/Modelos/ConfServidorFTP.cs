using Manigest.Core.ClienteFTP.MVP.Modelos.Plantillas;

namespace Manigest.Core.ClienteFTP.MVP.Modelos {
    public class ConfServidorFTP : IConfServidorFTP {
        public ConfServidorFTP(string servidor, string usuario, string password) {
            Servidor = servidor;
            Usuario = usuario;
            Password = password;
        }

        public string Servidor { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }

        public override string ToString() {
            return $"{Servidor};{Usuario};{Password}";
        }
    }
}
