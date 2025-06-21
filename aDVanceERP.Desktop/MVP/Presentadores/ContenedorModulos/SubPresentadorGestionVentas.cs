using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorGestionVentas? _gestionVentas;

    private async void InicializarVistaGestionVentas() {
        _gestionVentas = new PresentadorGestionVentas(new VistaGestionVentas());
        _gestionVentas.EditarEntidad += MostrarVistaEdicionVentaProducto;
        _gestionVentas.Vista.RegistrarDatos += MostrarVistaRegistroVentaProducto;

        if (Vista.Vistas != null)
            await Task.Run(() => Vista.Vistas?.Registrar("vistaGestionVentas", _gestionVentas.Vista));
    }

    private async void MostrarVistaGestionVentas(object? sender, EventArgs e) {
        if (_gestionVentas?.Vista == null)
            return;

        _gestionVentas.Vista.CargarCriteriosBusqueda(UtilesBusquedaVenta.FbVenta);
        _gestionVentas.Vista.Restaurar();
        _gestionVentas.Vista.Mostrar();

        await _gestionVentas.PopularTuplasDatosEntidades();
    }
}