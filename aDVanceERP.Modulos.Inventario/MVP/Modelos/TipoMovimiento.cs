using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos; 

public enum EfectoMovimiento {
    Ninguno,
    Carga,
    Descarga,
    Transferencia
}

public class TipoMovimiento : IObjetoUnico {
    public TipoMovimiento() {
        Id = 0;
        Nombre = string.Empty;
        Efecto = EfectoMovimiento.Ninguno;
    }

    public TipoMovimiento(long id, string nombre, EfectoMovimiento efecto) {
        Id = id;
        Nombre = nombre;
        Efecto = efecto;
    }

    public string Nombre { get; set; }
    public EfectoMovimiento Efecto { get; set; }

    public long Id { get; set; }
}

public enum CriterioBusquedaTipoMovimiento {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaTipoMovimiento {
    public static string[] CriterioBusquedaTipoMovimiento = {
        "Todos los tipos de movimiento",
        "Identificador de BD",
        "Nombre del movimiento"
    };
}