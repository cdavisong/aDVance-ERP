using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Taller.MVP.Modelos;

public class ActividadProduccion : IEntidad {
    public ActividadProduccion() {
        Nombre = string.Empty;
        Descripcion = "No hay descripción disponible";
        Costo = 0.0m;
    }

    public ActividadProduccion(long id, string nombre, string descripcion, decimal costo) {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Costo = costo;
    }

    public long Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Costo { get; set; }
}

public enum FbActividadProduccion {
    Todos,
    Id,
    Nombre,
    Descripcion
}

public static class UtilesBusquedaActividadProduccion {
    public static object[] FbActividadProduccion = {
        "Todas las actividades de producción",
        "Identificador de BD",
        "Nombre de la actividad",
        "Descripción de la actividad"
    };
}