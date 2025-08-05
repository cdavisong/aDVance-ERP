using aDVanceERP.Core.Interfaces.Comun;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos; 

public class DetalleCompraProducto : IEntidadBd {
    public DetalleCompraProducto() { }

    public DetalleCompraProducto(long id, long idCompra, long idProducto, decimal cantidad, decimal precioCompra) {
        Id = id;
        IdCompra = idCompra;
        IdProducto = idProducto;
        Cantidad = cantidad;
        PrecioCompra = precioCompra;
    }

    public long IdCompra { get; set; }
    public long IdProducto { get; set; }
    public decimal Cantidad { get; set; }
    public decimal PrecioCompra { get; set; }

    public long Id { get; set; }

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        throw new NotImplementedException();
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        throw new NotImplementedException();
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        throw new NotImplementedException();
    }
}

public enum CriterioDetalleCompraProducto {
    Todos,
    Id,
    IdCompra,
    IdProducto
}