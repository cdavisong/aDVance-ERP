using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorGestionCompras? _gestionCompras;

    private async void InicializarVistaGestionCompras() {
        _gestionCompras = new PresentadorGestionCompras(new VistaGestionCompras());
        _gestionCompras.EditarObjeto += MostrarVistaEdicionCompraProducto;
        _gestionCompras.Vista.RegistrarDatos += MostrarVistaRegistroCompraProducto;

        if (Vista.Vistas != null)
            await Task.Run(() => Vista.Vistas?.Registrar("vistaGestionCompras", _gestionCompras.Vista));
    }

    private async void MostrarVistaGestionCompras(object? sender, EventArgs e) {
        if (_gestionCompras?.Vista == null)
            return;

        _gestionCompras.Vista.CargarCriteriosBusqueda(UtilesBusquedaCompra.CriterioBusquedaCompra);
        _gestionCompras.Vista.Restaurar();
        _gestionCompras.Vista.Mostrar();

        await _gestionCompras.RefrescarListaObjetos();
    }
}