using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
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
        _registroMensajeria.Vista.CargarRazonesSocialesClientes(UtilesCliente.ObtenerRazonesSocialesClientes());
        _registroMensajeria.DatosRegistradosActualizados += delegate {
            if (_registroVentaArticulo == null) 
                return;

            _registroVentaArticulo.Vista.RazonSocialCliente = _registroMensajeria.Vista.RazonSocialCliente;
            _registroVentaArticulo.Vista.Direccion = _registroMensajeria.Vista.Direccion;
            _registroVentaArticulo.Vista.TipoEntrega = _registroMensajeria.Vista.TipoEntrega;
            _registroVentaArticulo.Vista.EstadoEntrega = "Pendiente";
            _registroVentaArticulo.Vista.MensajeriaConfigurada = true;
        };
    }

    private void MostrarVistaRegistroMensajeria(object? sender, EventArgs e) {
        InicializarVistaRegistroMensajeria();

        if (_registroMensajeria != null && _registroVentaArticulo != null) {
            _registroMensajeria.Vista.IdVenta = _proximoIdVenta;
            _registroMensajeria.Vista.PopularArticulosVenta(_registroVentaArticulo.Vista.Articulos);
            _registroMensajeria.Vista.AsignarNuevoMensajero += MostrarVistaRegistroMensajero;
            _registroMensajeria.Vista.AsignarNuevoCliente += MostrarVistaRegistroCliente;
            _registroMensajeria.Vista.Mostrar();
        }

        _registroMensajeria?.Dispose();
    }

    private void MostrarVistaEdicionMensajeria(object? sender, EventArgs e) {
        InicializarVistaRegistroMensajeria();

        if (sender is Venta venta) {
            if (_registroMensajeria != null && _registroVentaArticulo != null) {
                using (var datosSeguimientoEntrega = new DatosSeguimientoEntrega()) {
                    var seguimientoEntrega = datosSeguimientoEntrega.Obtener(CriterioBusquedaSeguimientoEntrega.IdVenta, venta.Id.ToString()).FirstOrDefault();

                    if (seguimientoEntrega != null) {
                        _registroMensajeria.PopularVistaDesdeObjeto(seguimientoEntrega);
                        _registroMensajeria.Vista.RazonSocialCliente = _registroVentaArticulo.Vista.RazonSocialCliente;
                        _registroMensajeria.Vista.PopularArticulosVenta(_registroVentaArticulo.Vista.Articulos);
                        _registroMensajeria.Vista.Mostrar();
                    }
                }
            }
        }

        _registroMensajeria?.Dispose();
    }
}