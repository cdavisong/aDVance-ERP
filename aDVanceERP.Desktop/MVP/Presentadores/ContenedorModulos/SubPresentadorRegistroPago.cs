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
        _registroPago.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
        _registroPago.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroPago.Vista.PagoEliminado += delegate (object? sender, EventArgs e) {
            if (sender is not string[] metodoPago || !metodoPago[0].Contains("Transferencia"))
                return;

            _registroPago.Vista.CargarMetodosPago();

            Transferencia = Array.Empty<string>();
        };
        _registroPago.DatosRegistradosActualizados += delegate {
            if (_registroVentaArticulo == null) 
                return;

            _registroVentaArticulo.Vista.PagoEfectuado = true;

            ActualizarSeguimientoEntrega();
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

    //TODO: Trabajar en la edicion de pagos
    private void MostrarVistaEdicionPago(object? sender, EventArgs e) {
        InicializarVistaRegistroPago();

        if (sender is Venta venta) {
            if (_registroPago != null && _registroVentaArticulo != null) {
                _registroPago.PopularVistaDesdeObjeto(new Pago(0, venta.Id, string.Empty, venta.Total));
                _registroPago.Vista.EfectuarTransferencia += delegate {
                    MostrarVistaEdicionDetallePagoTransferencia(sender, e);
                };
                _registroPago.Vista.Mostrar();
            }
        }

        _registroPago?.Dispose();
    }

    private void ActualizarSeguimientoEntrega() {
        using (var datosSeguimiento = new DatosSeguimientoEntrega()) {
            var objetoSeguimiento = datosSeguimiento
                .Obtener(CriterioBusquedaSeguimientoEntrega.IdVenta, _registroPago?.Vista.IdVenta.ToString())
                .FirstOrDefault();

            if (objetoSeguimiento == null)
                return;

            objetoSeguimiento.FechaPago = DateTime.Now;
            datosSeguimiento.Editar(objetoSeguimiento);
        }
    }
}