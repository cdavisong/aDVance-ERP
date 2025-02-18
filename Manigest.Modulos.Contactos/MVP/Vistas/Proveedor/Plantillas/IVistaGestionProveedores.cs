using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;
using Manigest.Modulos.Contactos.MVP.Modelos;

namespace Manigest.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas {
    public interface IVistaGestionProveedores : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaProveedor>, IGestorTablaDatos { }
}
