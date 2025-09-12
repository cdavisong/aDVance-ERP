using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Taller.Modelos;

namespace aDVanceERP.Modulos.Taller.Interfaces
{
    public interface IVistaGestionOrdenesProduccion : IVistaContenedor, IGestorDatos, IBuscadorEntidades<FiltroBusquedaOrdenProduccion>, IGestorTablaDatos {
        bool HabilitarBtnCierreOrdenProduccion { get; set; }

        event EventHandler? CerrarOrdenProduccionSeleccionada;
    }
}