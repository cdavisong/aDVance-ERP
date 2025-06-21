using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos; 

public class Movimiento : IEntidad {
    public Movimiento() { }

    public Movimiento(long id, long idProducto, long idAlmacenOrigen, long idAlmacenDestino, DateTime fecha,
        float cantidadMovida, long idTipoMovimiento) {
        Id = id;
        IdProducto = idProducto;
        IdAlmacenOrigen = idAlmacenOrigen;
        IdAlmacenDestino = idAlmacenDestino;
        Fecha = fecha;
        CantidadMovida = cantidadMovida;
        IdTipoMovimiento = idTipoMovimiento;
    }

    public long IdProducto { get; set; }
    public long IdAlmacenOrigen { get; set; }
    public long IdAlmacenDestino { get; set; }
    public DateTime Fecha { get; set; }
    public float CantidadMovida { get; set; }
    public long IdTipoMovimiento { get; set; }

    public long Id { get; set; }
}

public enum CriterioBusquedaMovimiento {
    Todos,
    Id,
    Producto,
    AlmacenOrigen,
    AlmacenDestino,
    Fecha,
    TipoMovimiento
}

public static class UtilesBusquedaMovimiento {
    public static object[] CriterioBusquedaMovimiento = {
        "Todos los movimientos",
        "Identificador de BD",
        "Nombre del producto",
        "Almacén de orígen",
        "Almacén de destino",
        "Fecha del movimiento",
        "Tipo de movimiento"
    };
}