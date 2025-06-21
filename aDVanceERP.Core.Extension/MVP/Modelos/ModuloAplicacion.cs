using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Core.Extension.MVP.Modelos; 

public class ModuloAplicacion : IEntidad {
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

public enum FbModuloAplicacion {
    Todos,
    Id,
    Nombre
}