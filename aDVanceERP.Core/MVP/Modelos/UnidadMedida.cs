using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Core.MVP.Modelos;

public class UnidadMedida : IObjetoUnico {
    public UnidadMedida() {
        Id = 0;
        Nombre = string.Empty;
        Abreviatura = string.Empty;
        Descripcion = string.Empty;
    }

    public UnidadMedida(long id, string nombre, string abreviatura, string descripcion) {
        Id = id;
        Nombre = nombre;
        Abreviatura = abreviatura;
        Descripcion = descripcion;
    }

    public long Id { get; set; }
    public string Nombre { get; set; }
    public string Abreviatura { get; set; }
    public string Descripcion { get; set; }
}

public enum CriterioBusquedaUnidadMedida {
    Todos,
    Id,
    Nombre,
    Abreviatura
}

public static class UtilesBusquedaUnidadesMedida {
    public static object[] CriterioBusquedaUnidadesMedida = {
        "Todas las unidades de medida",
        "Identificador de BD",
        "Nombre de la unidad de medida",
        "Abreviatura de la unidad de medida"
    };
}

