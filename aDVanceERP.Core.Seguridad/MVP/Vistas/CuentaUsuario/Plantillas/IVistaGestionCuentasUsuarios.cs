using aDVanceERP.Core.Interfaces.Comun;
using aDVanceERP.Core.Modelos.Modulos.Seguridad;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario.Plantillas;

public interface IVistaGestionCuentasUsuarios : IVistaContenedor, IGestorDatos,
    IBuscadorDatos<CriterioBusquedaCuentaUsuario>, IGestorTablaDatos {
    bool HabilitarBtnAprobacionSolicitudCuenta { get; set; }

    event EventHandler? AprobarSolicitudCuenta;
}