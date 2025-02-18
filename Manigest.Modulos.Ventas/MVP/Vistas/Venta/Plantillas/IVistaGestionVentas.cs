using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;
using Manigest.Modulos.Ventas.MVP.Modelos;

namespace Manigest.Modulos.Ventas.MVP.Vistas.Venta.Plantillas {
    public interface IVistaGestionVentas : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaVenta>, IGestorTablaDatos { }
}
