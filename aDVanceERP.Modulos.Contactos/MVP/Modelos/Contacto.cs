using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Modelos; 

public class Contacto : IEntidad {
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
}

public enum FbContacto {
    Todos,
    Id,
    Nombre,
    CorreoElectronico
}

public static class UtilesBusquedaContacto {
    public static string[] FbContacto = {
        "Todos los contactos",
        "Identificador de BD",
        "Nombre del contacto",
        "Correo electrónico del contacto"
    };
}