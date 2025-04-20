using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroProveedor? _registroProveedor;

    private void InicializarVistaRegistroProveedor() {
        _registroProveedor = new PresentadorRegistroProveedor(new VistaRegistroProveedor());
        _registroProveedor.Vista.CargarNombresContactos(UtilesContacto.ObtenerNombresContactos());
        _registroProveedor.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
        _registroProveedor.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroProveedor.Salir += async (sender, e) => {
            if (_gestionProveedores != null) await _gestionProveedores.RefrescarListaObjetos();
        };
    }

    private void MostrarVistaRegistroProveedor(object? sender, EventArgs e) {
        InicializarVistaRegistroProveedor();

        if (_registroProveedor == null)
            return;

        MostrarVistaPanelTransparente(_registroProveedor.Vista);

        _registroProveedor?.Vista.Mostrar();
        _registroProveedor?.Dispose();
    }

    private void MostrarVistaEdicionProveedor(object? sender, EventArgs e) {
        InicializarVistaRegistroProveedor();

        if (_registroProveedor != null && sender is Proveedor proveedor) {

            MostrarVistaPanelTransparente(_registroProveedor.Vista);

            _registroProveedor.PopularVistaDesdeObjeto(proveedor);
            _registroProveedor.Vista.Mostrar();
        }

        _registroProveedor?.Dispose();
    }
}