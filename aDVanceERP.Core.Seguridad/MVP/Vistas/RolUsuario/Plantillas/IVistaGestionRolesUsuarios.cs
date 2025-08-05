using aDVanceERP.Core.Interfaces.Comun;
using aDVanceERP.Core.Modelos.Modulos.Seguridad;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario.Plantillas;

public interface IVistaGestionRolesUsuarios : IVistaContenedor, IGestorDatos,
    IBuscadorDatos<CriterioBusquedaRolUsuario>, IGestorTablaDatos { }