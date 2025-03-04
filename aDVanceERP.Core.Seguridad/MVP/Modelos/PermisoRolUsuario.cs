using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos {
    public class PermisoRolUsuario : IObjetoUnico {
        public PermisoRolUsuario() {
        }

        public PermisoRolUsuario(long id, long idRolUsuario, long idPermiso) {
            Id = id;
            IdRolUsuario = idRolUsuario;
            IdPermiso = idPermiso;
        }

        public long Id { get; set; }
        public long IdRolUsuario { get; }
        public long IdPermiso { get; }
    }

    public enum CriterioBusquedaPermisoRolUsuario {
        Todos,
        Id
    }
}
