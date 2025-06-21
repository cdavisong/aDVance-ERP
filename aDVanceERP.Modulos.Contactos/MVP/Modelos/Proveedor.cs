using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Modelos;

public class Proveedor : IEntidad {
    public Proveedor() { }

    public Proveedor(long idProveedor, string razonSocial, string numeroIdentificacionTributaria,
        long idContacto) {
        Id = idProveedor;
        RazonSocial = razonSocial;
        NumeroIdentificacionTributaria = numeroIdentificacionTributaria;
        IdContacto = idContacto;
    }

    public long Id { get; set; }
    public string? RazonSocial { get; }
    public string? NumeroIdentificacionTributaria { get; }
    public long IdContacto { get; set; }
}

public enum FbProveedor {
    Todos,
    Id,
    RazonSocial,
    NIT
}

public static class UtilesBusquedaProveedor {
    public static string[] FbProveedor = {
        "Todos los proveedores",
        "Identificador de BD",
        "Razón Social del proveedor",
        "No. Identificación Tributaria"
    };
}