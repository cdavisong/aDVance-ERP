using aDVanceERP.Core.Modelos.Comun;

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
}

public enum CriterioBusquedaModuloAplicacion {
    Todos,
    Id,
    Nombre
}