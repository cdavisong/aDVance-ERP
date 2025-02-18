using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;
using Manigest.Modulos.Contactos.MVP.Modelos;

namespace Manigest.Modulos.Contactos.MVP.Vistas.Contacto.Plantillas {
    public interface IVistaGestionContactos : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaContacto>, IGestorTablaDatos { 
    
    }
}
