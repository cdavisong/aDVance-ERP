using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Core.Extension.MVP.Modelos; 

public class ModuloAplicacion : IEntidadBaseDatos {
    public ModuloAplicacion() { }

    public ModuloAplicacion(long id, string? nombre, string? version) {
        Id = id;
        Nombre = nombre;
        Version = version;
    }

    public long Id { get; set; }
    public string? Nombre { get; }
    public string? Version { get; }
}

public enum FiltroBusquedaModuloAplicacion {
    Todos,
    Id,
    Nombre
}