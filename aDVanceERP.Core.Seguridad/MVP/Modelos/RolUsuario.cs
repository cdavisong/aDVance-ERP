using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos {
    public class RolUsuario : IObjetoUnico {
        public RolUsuario() {
        }

        public RolUsuario(long id, string nombre) {
            Id = id;
            Nombre = nombre;
        }

        public long Id { get; set; }
        public string? Nombre { get; }
    }

    public enum CriterioBusquedaRolUsuario {
        Todos,
        Id,
        Nombre
    }

    public static class UtilesBusquedaRolUsuario {
        public static string[] CriterioBusquedaBusquedaRolUsuario = new string[] {
            "Todos los roles",
            "Identificador de BD",
            "Nombre del rol"
        };
    }
}
