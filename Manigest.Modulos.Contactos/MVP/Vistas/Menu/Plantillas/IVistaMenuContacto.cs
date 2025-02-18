using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Vistas.Menu.Plantillas {
    public interface IVistaMenuContacto : IVistaMenu {
        event EventHandler? VerProveedores;
        event EventHandler? VerClientes;
        event EventHandler? VerContactos;        
    }
}
