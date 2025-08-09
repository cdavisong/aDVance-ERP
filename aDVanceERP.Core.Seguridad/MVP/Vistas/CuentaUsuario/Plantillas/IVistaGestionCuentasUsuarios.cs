using aDVanceERP.Core.Interfaces;
using aDVanceERP.Core.Modelos.Modulos.Seguridad;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario.Plantillas;

public interface IVistaGestionCuentasUsuarios : IVistaContenedor, IGestorDatos,
    IBarraBusquedaEntidadesBd<CriterioBusquedaCuentaUsuario>, ITablaResultadosBusqueda {
    bool HabilitarBtnAprobacionSolicitudCuenta { get; set; }

    event EventHandler? AprobarSolicitudCuenta;
}