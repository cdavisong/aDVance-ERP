using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Seguridad.MVP.Modelos;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario.Plantillas;

public interface IVistaGestionRolesUsuarios : IVistaContenedor, IGestorEntidades,
    IBuscadorEntidades<FiltroBusquedaRolUsuario>, IGestorTablaDatos { }