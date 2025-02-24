using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas {
    public interface IVistaGestionArticulos : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaArticulo>, IGestorTablaDatos {
        string NombreAlmacen { get; }
        string ValorBrutoInversion { get; }

        void CargarNombresAlmacenes(string[] nombresAlmacenes);
    }
}
