using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Core.Extension.MVP.Modelos;

public class ModuloAplicacion : IEntidadBd {
    public ModuloAplicacion() { }

    public ModuloAplicacion(long id, string? nombre, string? version) {
        Id = id;
        Nombre = nombre;
        Version = version;
    }

    public string? Nombre { get; }
    public string? Version { get; }

    public long Id { get; set; }

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

public enum CriterioBusquedaModuloAplicacion {
    Todos,
    Id,
    Nombre
}