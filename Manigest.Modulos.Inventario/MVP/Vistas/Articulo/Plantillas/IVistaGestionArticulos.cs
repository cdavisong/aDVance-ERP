using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;
using Manigest.Modulos.Inventario.MVP.Modelos;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas {
    public interface IVistaGestionArticulos : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaArticulo>, IGestorTablaDatos { 
        string NombreAlmacen { get; }

        void CargarNombresAlmacenes(string[] nombresAlmacenes);
    }
}
