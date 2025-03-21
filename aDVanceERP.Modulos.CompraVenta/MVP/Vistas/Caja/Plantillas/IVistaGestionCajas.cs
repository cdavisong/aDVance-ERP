using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Caja.Plantillas {
    public interface IVistaGestionCajas : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaCaja>, IGestorTablaDatos {
        bool HabilitarBtnCierreCajaRegistradora { get; set; }

        event EventHandler? CerrarCaja;
    }
}
