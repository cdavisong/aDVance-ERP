using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Modelos; 

public class Proveedor : IObjetoUnico {
    public Proveedor() { }

    public Proveedor(long idProveedor, string razonSocial, string numeroIdentificacionTributaria,
        long idContactoRepresentante) {
        Id = idProveedor;
        RazonSocial = razonSocial;
        NumeroIdentificacionTributaria = numeroIdentificacionTributaria;
        IdContactoRepresentante = idContactoRepresentante;
    }

    public string? RazonSocial { get; }
    public string? NumeroIdentificacionTributaria { get; }
    public long IdContactoRepresentante { get; }

    public long Id { get; set; }
}

public enum CriterioBusquedaProveedor {
    Todos,
    Id,
    RazonSocial,
    NIT
}

public static class UtilesBusquedaProveedor {
    public static string[] CriterioBusquedaProveedor = {
        "Todos los proveedores",
        "Identificador de BD",
        "Razón Social del proveedor",
        "No. Identificación Tributaria"
    };
}