using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos;

public class TipoMateriaPrima : IEntidad {
    public TipoMateriaPrima() {
        Id = 0;
        Nombre = string.Empty;
        Descripcion = string.Empty;
    }

    public TipoMateriaPrima(long id, string nombre, string descripcion) {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
    }

    public long Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
}

public enum FbTipoMateriaPrima {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaTiposMateriasPrimas {
    public static string[] FbTiposMateriasPrimas = {
        "Todos los tipos de materias primas",
        "Identificador de BD",
        "Nombre del tipo de materia prima"
    };
}