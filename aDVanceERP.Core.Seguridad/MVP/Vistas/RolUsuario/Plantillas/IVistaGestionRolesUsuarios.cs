using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Seguridad.MVP.Modelos;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario.Plantillas {
    public interface IVistaGestionRolesUsuarios : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaRolUsuario>, IGestorTablaDatos { }
}
