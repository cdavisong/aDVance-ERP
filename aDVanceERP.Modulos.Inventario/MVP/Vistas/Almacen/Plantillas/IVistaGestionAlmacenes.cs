using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas; 

public interface IVistaGestionAlmacenes : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaAlmacen>,
    IGestorTablaDatos {
}