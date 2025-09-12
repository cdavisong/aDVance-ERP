using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Seguridad.MVP.Modelos;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario.Plantillas;

public interface IVistaGestionCuentasUsuarios : IVistaContenedor, IGestorEntidades,
    IBuscadorEntidades<FiltroBusquedaCuentaUsuario>, IGestorTablaDatos {
    bool HabilitarBtnAprobacionSolicitudCuenta { get; set; }

    event EventHandler? AprobarSolicitudCuenta;
}