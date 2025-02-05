using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas {
    public interface IVistaGestionMovimientos : IVistaContenedor, IGestorDatos, IBuscadorDatos, IGestorTablaDatos {
        void CargarNombresAlmacenes(string[] nombresAlmacenes);
    }
}
