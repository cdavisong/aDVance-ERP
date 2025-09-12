using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario.Plantillas;

public interface IVistaGestionRolesUsuarios : IVistaContenedor, IGestorEntidades,
    IBuscadorEntidades<FiltroBusquedaRolUsuario>, INavegadorTuplasEntidades { }