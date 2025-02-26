using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos {
    public class CuentaUsuario : IObjetoUnico {
        public CuentaUsuario() {
        }

        public CuentaUsuario(long id, string nombre, string passwordHash, string passwordSalt, long idRolUsuario) {
            Id = id;
            Nombre = nombre;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            IdRolUsuario = idRolUsuario;
        }        

        public long Id { get; set; }
        public string? Nombre { get; }
        public string? PasswordHash { get; private set; }
        public string? PasswordSalt { get; private set; }
        public long IdRolUsuario { get; set; }
        public bool Administrador { get; set; }
        public bool Aprobado { get; set; }
    }

    public enum CriterioBusquedaCuentaUsuario {
        Todos,
        Nombre,
        Rol
    }

    public static class UtilesBusquedaCuentaUsuario {
        public static string[] CriterioBusquedaBusquedaCuentaUsuario = new string[] {
            "Todos los usuarios",
            "Identificador de BD",
            "Nombre del usuario",
            "Rol del usuario"
        };
    }
}
