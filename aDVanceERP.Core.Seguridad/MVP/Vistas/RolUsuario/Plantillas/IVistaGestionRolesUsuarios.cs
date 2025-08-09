using aDVanceERP.Core.Interfaces;
using aDVanceERP.Core.Modelos.Modulos.Seguridad;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario.Plantillas;

public interface IVistaGestionRolesUsuarios : IVistaContenedor, IGestorDatos,
    IBarraBusquedaEntidadesBd<CriterioBusquedaRolUsuario>, ITablaResultadosBusqueda { }