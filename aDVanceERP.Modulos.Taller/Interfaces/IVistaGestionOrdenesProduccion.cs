using aDVanceERP.Core.Interfaces.Comun;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Taller.Modelos;

namespace aDVanceERP.Modulos.Taller.Interfaces
{
    public interface IVistaGestionOrdenesProduccion : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaOrdenProduccion>, IGestorTablaDatos {
        bool HabilitarBtnCierreOrdenProduccion { get; set; }

        event EventHandler? CerrarOrdenProduccionSeleccionada;
    }
}