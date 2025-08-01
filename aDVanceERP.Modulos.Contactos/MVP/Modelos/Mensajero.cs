using aDVanceERP.Core.Modelos.Comun;

namespace aDVanceERP.Modulos.Contactos.MVP.Modelos; 

public class Mensajero : IEntidadBd {
    public Mensajero() { }

    public Mensajero(long id, string nombre, bool activo, long idContacto) {
        Id = id;
        Nombre = nombre;
        Activo = activo;
        IdContacto = idContacto;
    }

    public long Id { get; set; }
    public string Nombre { get; set; }
    public bool Activo { get; set; }
    public long IdContacto { get; set; }    
}

public enum CriterioBusquedaMensajero {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaMensajero {
    public static object[] CriterioBusquedaMensajero = {
        "Todos los mensajeros",
        "Identificador de BD",
        "Nombre del mensajero"
    };
}