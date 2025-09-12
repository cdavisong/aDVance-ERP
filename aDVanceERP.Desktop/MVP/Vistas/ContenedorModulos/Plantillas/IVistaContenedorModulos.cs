using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Desktop.MVP.Vistas.ContenedorModulos.Plantillas;

public interface IVistaContenedorModulos : IVistaContenedor {
    //bool BtnModuloAdministracionVisible { get; set; }

    event EventHandler? MostrarVistaInicio;
    event EventHandler? MostrarVistaEstadisticas;
    event EventHandler? MostrarMenuContactos;
    event EventHandler? MostrarMenuFinanzas;
    event EventHandler? MostrarMenuInventario;
    event EventHandler? MostrarMenuTaller;
    event EventHandler? MostrarMenuVentas;
    event EventHandler? MostrarMenuSeguridad;
    event EventHandler? CambioModulo;

    void PresionarBotonModulo(object? sender, EventArgs e);
}