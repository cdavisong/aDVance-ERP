using aDVanceERP.Modulos.Ventas.MVP.Modelos;
using aDVanceERP.Modulos.Ventas.MVP.Presentadores;
using aDVanceERP.Modulos.Ventas.MVP.Vistas.Venta;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionVentas _gestionVentasArticulos;

        private async void InicializarVistaGestionVentasArticulos() {
            _gestionVentasArticulos = new PresentadorGestionVentas(new VistaGestionVentas());
            _gestionVentasArticulos.EditarObjeto += MostrarVistaEdicionVentaArticulo;
            _gestionVentasArticulos.Vista.RegistrarDatos += MostrarVistaRegistroVentaArticulo;
            _gestionVentasArticulos.Vista.CargarCriteriosBusqueda(UtilesBusquedaVenta.CriterioBusquedaVenta);

            if (Vista.Vistas != null)
                await Task.Run(() => Vista.Vistas?.Registrar("vistaGestionVentas", _gestionVentasArticulos.Vista));
        }

        private async void MostrarVistaGestionVentasArticulos(object? sender, EventArgs e) {
            if ((_gestionVentasArticulos?.Vista) == null)
                return;

            _gestionVentasArticulos.Vista.Restaurar();
            _gestionVentasArticulos.Vista.Mostrar();

            await _gestionVentasArticulos.RefrescarListaObjetos();
        }
    }
}
