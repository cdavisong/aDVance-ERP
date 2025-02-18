using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;
using Manigest.Modulos.Contactos.MVP.Modelos;

namespace Manigest.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas {
    public interface IVistaGestionClientes : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaCliente>, IGestorTablaDatos { }
}
