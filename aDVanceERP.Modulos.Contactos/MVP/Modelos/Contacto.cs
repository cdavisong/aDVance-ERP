using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Modulos.Contactos.MVP.Modelos;

public class Contacto : IEntidadBd {
    public Contacto() { }

    public Contacto(long idContacto, string nombre, string direccionCorreoElectronico, string direccion, string notas) {
        Id = idContacto;
        Nombre = nombre;
        DireccionCorreoElectronico = direccionCorreoElectronico;
        Direccion = direccion;
        Notas = notas;
    }

    public long Id { get; set; }
    public string? Nombre { get; set; }
    public string? DireccionCorreoElectronico { get; set; }
    public string? Direccion { get; set; }
    public string? Notas { get; set; }

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

public enum CriterioBusquedaContacto {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaContacto {
    public static string[] CriterioBusquedaContacto = {
        "Todos los contactos",
        "Identificador de BD",
        "Nombre del contacto"
    };
}