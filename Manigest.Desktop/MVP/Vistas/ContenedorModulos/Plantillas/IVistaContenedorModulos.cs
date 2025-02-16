using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Desktop.MVP.Vistas.ContenedorModulos.Plantillas {
    public interface IVistaContenedorModulos : IVistaContenedor {
        //bool BtnModuloAdministracionVisible { get; set; }

        event EventHandler? MostrarVistaInicio;
        event EventHandler? MostrarMenuEstadisticas;
        event EventHandler? MostrarMenuContactos;
        event EventHandler? MostrarMenuInventario;
        event EventHandler? MostrarMenuVentas;
        event EventHandler? CambioModulo;
    }
}
