using aDVanceERP.Core.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Taller.Modelos;

namespace aDVanceERP.Modulos.Taller.Interfaces
{
    public interface IVistaGestionOrdenesProduccion : IVistaContenedor, IGestorDatos, IBarraBusquedaEntidadesBd<CriterioBusquedaOrdenProduccion>, ITablaResultadosBusqueda {
        bool HabilitarBtnCierreOrdenProduccion { get; set; }

        event EventHandler? CerrarOrdenProduccionSeleccionada;
    }
}