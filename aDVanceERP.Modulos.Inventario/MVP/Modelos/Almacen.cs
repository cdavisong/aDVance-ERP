using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos; 

public class Almacen : IEntidad {
    public Almacen() { }

    public Almacen(long idAlmacen, string nombre, string direccion, bool autorizoVenta, string notas) {
        Id = idAlmacen;
        Nombre = nombre;
        Direccion = direccion;
        AutorizoVenta = autorizoVenta;
        Notas = notas;
    }

    public string? Nombre { get; }
    public string? Direccion { get; }
    public bool AutorizoVenta { get; }
    public string? Notas { get; set; }

    public long Id { get; set; }
}

public enum FbAlmacen {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaAlmacen {
    public static string[] FbAlmacen = {
        "Todos los almacenes",
        "Identificador de BD",
        "Nombre del almacén"
    };
}