using Manigest.Core.MVP.Modelos.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Modelos {
    public class Proveedor : IObjetoUnico {
        public Proveedor(long idProveedor, string razonSocial, string numeroIdentificacionTributaria, long idContactoRepresentante) {
            Id = idProveedor;
            RazonSocial = razonSocial;
            NumeroIdentificacionTributaria = numeroIdentificacionTributaria;
            IdContactoRepresentante = idContactoRepresentante;
        }

        public Proveedor(string nombre, string numeroIdentificacionTributaria, long idContactoRepresentante)
            : this(0, nombre, numeroIdentificacionTributaria, idContactoRepresentante) { }

        public long Id { get; set; }
        public string RazonSocial { get; }
        public string NumeroIdentificacionTributaria { get; }
        public long IdContactoRepresentante { get; }
    }

    public enum CriterioBusquedaProveedor {
        Todos,
        Id,
        RazonSocial,
        NIT
    }

    public static class UtilesBusquedaProveedor {
        public static string[] CriterioBusquedaProveedor = new string[] {
            "Todos los proveedores",
            "Identificador de BD",
            "Razón Social del proveedor",
            "No. Identificación Tributaria"
        };
    }
}
