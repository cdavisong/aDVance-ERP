using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Vistas.Menu.Plantillas {
    public interface IVistaMenuContacto : IVista {
        event EventHandler? VerProveedores;
        event EventHandler? VerClientes;
        event EventHandler? VerContactos;
        event EventHandler? CambioMenu;
    }
}
