using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;
using Manigest.Modulos.Inventario.MVP.Modelos;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas {
    public interface IVistaGestionAlmacenes : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaAlmacen>, IGestorTablaDatos { }
}
