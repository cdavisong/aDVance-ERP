using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos; 

public class Almacen : IEntidadBaseDatos {
    public Almacen() { }

    public Almacen(long idAlmacen, string nombre, string direccion, bool autorizoVenta, string notas) {
        Id = idAlmacen;
        Nombre = nombre;
        Direccion = direccion;
        AutorizoVenta = autorizoVenta;
        Notas = notas;
    }

    public long Id { get; set; }
    public string? Nombre { get; }
    public string? Direccion { get; }
    public bool AutorizoVenta { get; }
    public string? Notas { get; set; }
}

public enum FiltroBusquedaAlmacen {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaAlmacen {
    public static object[] FiltroBusquedaAlmacen = {
        "Todos los almacenes",
        "Identificador de BD",
        "Nombre del almacén"
    };
}