using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Pago;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroPago? _registroPago;

    private void InicializarVistaRegistroPago() {
        _registroPago = new PresentadorRegistroPago(new VistaRegistroPago());
        _registroPago.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
        _registroPago.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroPago.Vista.PagoEliminado += delegate (object? sender, EventArgs e) {
            if (sender is not string[] metodoPago || !metodoPago[0].Contains("Transferencia"))
                return;

            _registroPago.Vista.CargarMetodosPago();

            Transferencia = Array.Empty<string>();
        };
        _registroPago.Vista.RegistrarDatos += delegate {
            if (_registroVentaArticulo != null)
                _registroVentaArticulo.Vista.PagoConfirmado = _registroPago.Vista.Pagos.Count > 0;

            // Actualizar el seguimiento de entrega
            using (var datosSeguimiento = new DatosSeguimientoEntrega()) {
                var objetoSeguimiento = datosSeguimiento.Obtener(CriterioBusquedaSeguimientoEntrega.IdVenta, _registroPago.Vista.IdVenta.ToString()).FirstOrDefault();

                if (objetoSeguimiento != null) {
                    objetoSeguimiento.FechaPago = DateTime.Now;

                    datosSeguimiento.Editar(objetoSeguimiento);
                }
            }
        };
    }

    private void MostrarVistaRegistroPago(object? sender, EventArgs e) {
        InicializarVistaRegistroPago();

        if (_registroPago != null && _registroVentaArticulo != null) {
            _registroPago.Vista.IdVenta = _proximoIdVenta;
            _registroPago.Vista.Total = _registroVentaArticulo.Vista.Total;
            _registroPago.Vista.EfectuarTransferencia += delegate {
                MostrarVistaRegistroDetallePagoTransferencia(sender, e);
            };

            _registroPago.Vista.Mostrar();
        }

        _registroPago?.Dispose();
    }

    private void MostrarVistaEdicionPago(object? sender, EventArgs e) {
        InicializarVistaRegistroPago();

        if (_registroPago != null && sender is Venta venta) {
            _registroPago.PopularVistaDesdeObjeto(new Pago(0, venta?.Id ?? 0, string.Empty, venta?.Total ?? 0));
            _registroPago.Vista.EfectuarTransferencia += delegate {
                MostrarVistaEdicionDetallePagoTransferencia(sender, e);
            };
            _registroPago.Vista.Mostrar();
        }

        _registroPago?.Dispose();
    }
}