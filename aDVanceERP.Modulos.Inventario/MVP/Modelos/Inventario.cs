using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos; 

public class Inventario : IEntidad {
    public Inventario() { }

    public Inventario(long idInventario, long idProducto, long idAlmacen, decimal cantidad, decimal costoPromedio, decimal valorTotal, DateTime ultimaActualizacion) {
        Id = idInventario;
        IdProducto = idProducto;
        IdAlmacen = idAlmacen;
        Cantidad = cantidad;
        CostoPromedio = costoPromedio;
        ValorTotal = valorTotal;
        UltimaActualizacion = ultimaActualizacion;
    }

    public long Id { get; set; }
    public long IdProducto { get; set; }
    public long IdAlmacen { get; set; }
    public decimal Cantidad { get; set; }
    public decimal CostoPromedio { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime UltimaActualizacion { get; set; }
}

public enum CriterioBusquedaInventario {
    Todos,
    Id,
    IdProducto,
    IdAlmacen
}