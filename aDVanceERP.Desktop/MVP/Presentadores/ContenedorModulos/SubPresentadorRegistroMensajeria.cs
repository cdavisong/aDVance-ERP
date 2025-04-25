using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Mensajeria;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroMensajeria? _registroMensajeria;

    private async void InicializarVistaRegistroMensajeria() {
        _registroMensajeria = new PresentadorRegistroMensajeria(new VistaRegistroMensajeria());
        _registroMensajeria.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
        _registroMensajeria.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroMensajeria.Vista.CargarNombresMensajeros(await UtilesMensajero.ObtenerNombresMensajeros());
        _registroMensajeria.Vista.CargarTiposEntrega();
    }

    private void MostrarVistaRegistroMensajeria(object? sender, EventArgs e) {
        InicializarVistaRegistroMensajeria();

        if (_registroMensajeria != null && _registroVentaArticulo != null) {
            _registroMensajeria.Vista.IdVenta = _proximoIdVenta;
            _registroMensajeria.Vista.PopularDatosCliente(_registroVentaArticulo.Vista.RazonSocialCliente);
            _registroMensajeria.Vista.PopularArticulosVenta(_registroVentaArticulo.Vista.Articulos);
            _registroMensajeria.Vista.Mostrar();
        }

        _registroMensajeria?.Dispose();
    }

    private void MostrarVistaEdicionMensajeria(object? sender, EventArgs e) {
        InicializarVistaRegistroMensajeria();

        if (sender is SeguimientoEntrega seguimientoEntrega) {
            if (_registroMensajeria != null && _registroVentaArticulo != null) {
                _registroMensajeria.PopularVistaDesdeObjeto(seguimientoEntrega);
                _registroMensajeria.Vista.PopularDatosCliente(_registroVentaArticulo.Vista.RazonSocialCliente);
                _registroMensajeria.Vista.PopularArticulosVenta(_registroVentaArticulo.Vista.Articulos);
                _registroMensajeria.Vista.Mostrar();
            }
        }

        _registroMensajeria?.Dispose();
    }
}