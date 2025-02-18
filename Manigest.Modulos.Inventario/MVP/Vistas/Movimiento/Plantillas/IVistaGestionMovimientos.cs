using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;
using Manigest.Modulos.Inventario.MVP.Modelos;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas {
    public interface IVistaGestionMovimientos : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaMovimiento>, IGestorTablaDatos { }
}
