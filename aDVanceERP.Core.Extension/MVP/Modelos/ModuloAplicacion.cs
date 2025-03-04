using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Core.Extension.MVP.Modelos {
    public class ModuloAplicacion : IObjetoUnico {
        public ModuloAplicacion() {
        }

        public ModuloAplicacion(long id, string? nombre, string? version) {
            Id = id;
            Nombre = nombre;
            Version = version;
        }

        public long Id { get; set; }
        public string? Nombre { get; }
        public string? Version { get; }
    }

    public enum CriterioBusquedaModuloAplicacion {
        Todos,
        Id,
        Nombre
    }
}
