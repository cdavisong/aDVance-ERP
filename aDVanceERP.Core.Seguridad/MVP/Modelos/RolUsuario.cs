using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos {
    public class RolUsuario : IObjetoUnico {
        public RolUsuario() {
        }

        public RolUsuario(long id, string nombre, byte nivelAcceso) {
            Id = id;
            Nombre = nombre;
            NivelAcceso = nivelAcceso;
        }

        public long Id { get; set; }
        public string? Nombre { get; }
        public byte NivelAcceso { get; set; }
    }

    public enum CriterioBusquedaRolUsuario {
        Todos,
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
