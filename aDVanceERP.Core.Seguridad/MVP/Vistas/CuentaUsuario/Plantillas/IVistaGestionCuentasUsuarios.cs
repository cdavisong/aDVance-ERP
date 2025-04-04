using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Seguridad.MVP.Modelos;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario.Plantillas; 

public interface IVistaGestionCuentasUsuarios : IVistaContenedor, IGestorDatos,
    IBuscadorDatos<CriterioBusquedaCuentaUsuario>, IGestorTablaDatos {
    bool HabilitarBtnAprobacionSolicitudCuenta { get; set; }

    event EventHandler? AprobarSolicitudCuenta;
}