using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Vistas.Contacto.Plantillas {
    public interface IVistaTuplaContacto : IVistaTupla {
        string Id { get; set; }
        string Nombre { get; set; }
        string Telefonos { get; set; }
        string CorreoElectronico { get; set; }
        string Direccion { get; set; }
    }
}
