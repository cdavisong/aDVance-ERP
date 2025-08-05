using aDVanceERP.Core.Interfaces.Comun;

namespace aDVanceERP.Modulos.Contactos.MVP.Modelos;

public class Proveedor : IEntidadBd {
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

public enum CriterioBusquedaProveedor {
    Todos,
    Id,
    RazonSocial,
    NIT
}

public static class UtilesBusquedaProveedor {
    public static object[] CriterioBusquedaProveedor = {
        "Todos los proveedores",
        "Identificador de BD",
        "Razón Social del proveedor",
        "No. Identificación Tributaria"
    };
}