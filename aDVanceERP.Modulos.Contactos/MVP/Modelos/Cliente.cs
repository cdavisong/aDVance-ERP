using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Modelos; 

public class Cliente : IEntidad {
    public Cliente() { }

    public Cliente(long idCliente, string? numero, string? razonSocial, long idContacto) {
        Id = idCliente;
        Numero = numero;
        RazonSocial = razonSocial;
        IdContacto = idContacto;
    }

    public string? Numero { get; }
    public string? RazonSocial { get; }
    public long IdContacto { get; set; }

    public long Id { get; set; }
}

public enum CriterioBusquedaCliente {
    Todos,
    Id,
    Numero,
    RazonSocial
}

public static class UtilesBusquedaCliente {
    public static readonly object[] CriterioBusquedaCliente = {
        "Todos los clientes",
        "Identificador de BD",
        "Número del cliente",
        "Razón Social"
    };
}