using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas {
    public interface IVistaTuplaProveedor : IVistaTupla {
        string Id { get; set; }
        string RazonSocial { get; set; }
        string NumeroIdentificacionTributaria { get; set; }
        string NombreRepresentante { get; set; }
    }
}
