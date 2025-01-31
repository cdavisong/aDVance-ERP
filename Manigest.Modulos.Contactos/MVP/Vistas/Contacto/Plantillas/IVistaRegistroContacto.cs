using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Vistas.Contacto.Plantillas {
    public interface IVistaRegistroContacto : IVistaRegistro {
        string Nombre { get; set; }
        string TelefonoMovil { get; set; }
        string TelefonoFijo { get; set; }
        string CorreoElectronico { get; set; }
        string Direccion { get; set; }
        string Notas { get; set; }
    }
}
