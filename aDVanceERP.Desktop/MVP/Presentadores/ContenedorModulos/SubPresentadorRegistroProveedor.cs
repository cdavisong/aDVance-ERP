using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroProveedor _registroProveedor;

    private async Task InicializarVistaRegistroProveedor() {
        _registroProveedor = new PresentadorRegistroProveedor(new VistaRegistroProveedor());
        _registroProveedor.Vista.CargarNombresContactos(UtilesContacto.ObtenerNombresContactos());
        _registroProveedor.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
        _registroProveedor.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroProveedor.Salir += async (sender, e) => {
            if (_gestionProveedores != null) await _gestionProveedores.RefrescarListaObjetos();
        };
    }

    private async void MostrarVistaRegistroProveedor(object? sender, EventArgs e) {
        await InicializarVistaRegistroProveedor();

        if (_registroProveedor != null) _registroProveedor.Vista.Mostrar();

        _registroProveedor?.Dispose();
    }

    private async void MostrarVistaEdicionProveedor(object? sender, EventArgs e) {
        await InicializarVistaRegistroProveedor();

        if (_registroProveedor != null && sender is Proveedor proveedor) {
            _registroProveedor.PopularVistaDesdeObjeto(proveedor);
            _registroProveedor.Vista.Mostrar();
        }

        _registroProveedor?.Dispose();
    }
}