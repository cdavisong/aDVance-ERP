using aDVanceERP.Core.Interfaces.Comun;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;

namespace aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas
{
    public interface IVistaGestionCajas : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaCaja>, IGestorTablaDatos {
        bool HabilitarBtnRegistroMovimientoCaja { get; set; }
        bool HabilitarBtnCierreCaja { get; set; }

        event EventHandler? RegistrarMovimientoCajaSeleccionada;
        event EventHandler? CerrarCajaSeleccionada;
    }
}
