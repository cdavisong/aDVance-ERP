using aDVanceERP.Core.Modelos.Modulos.Seguridad;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios.Plantillas;

public interface
    IRepositorioPermisoRolUsuario : IRepositorioDatos<RolPermisoUsuario, CriterioBusquedaPermisoRolUsuario> { }