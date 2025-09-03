using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Core.Modelos.Modulos.Inventario;

public class Movimiento : IEntidadBaseDatos {
    public Movimiento() { }

    public Movimiento(long id, long idProducto, long idAlmacenOrigen, long idAlmacenDestino, DateTime fecha,
        decimal cantidadMovida, long idTipoMovimiento) {
        Id = id;
        IdProducto = idProducto;
        IdAlmacenOrigen = idAlmacenOrigen;
        IdAlmacenDestino = idAlmacenDestino;
        Fecha = fecha;
        CantidadMovida = cantidadMovida;
        IdTipoMovimiento = idTipoMovimiento;
    }

    public long Id { get; set; }
    public long IdProducto { get; set; }
    public long IdAlmacenOrigen { get; set; }
    public long IdAlmacenDestino { get; set; }
    public DateTime Fecha { get; set; }
    public decimal CantidadMovida { get; set; }
    public long IdTipoMovimiento { get; set; }
}

public enum FiltroBusquedaMovimiento {
    Todos,
    Id,
    Producto,
    AlmacenOrigen,
    AlmacenDestino,
    Fecha,
    TipoMovimiento
}

public static class UtilesBusquedaMovimiento {
    public static object[] FiltroBusquedaMovimiento = {
        "Todos los movimientos",
        "Identificador de BD",
        "Nombre del producto",
        "Almacén de orígen",
        "Almacén de destino",
        "Fecha del movimiento",
        "Tipo de movimiento"
    };
}