using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Pago;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios;

using System.Globalization;

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

            ActualizarMovimientoCaja(_registroPago.Vista.Pagos);
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

    private void ActualizarMovimientoCaja(List<string[]> pagos) {
        using (var datosCaja = new DatosCaja()) {
            var cajaActiva = datosCaja
                .Obtener(CriterioBusquedaCaja.Estado, "Abierta")
                .FirstOrDefault();

            if (cajaActiva != null) {
                using (var datosMovimientoCaja = new DatosMovimientoCaja()) {
                    foreach (var pago in pagos) {
                        var idPago = long.Parse(pago[1]);
                        var tipoPago = pago[2];

                        if (tipoPago != "Efectivo")
                            continue;

                        var montoPago = decimal.TryParse(pago[3], NumberStyles.Any, CultureInfo.InvariantCulture, out var monto) ? monto : 0;
                        var movimientoCaja = datosMovimientoCaja
                            .Obtener(CriterioBusquedaMovimientoCaja.IdPago, idPago.ToString())
                            .FirstOrDefault();

                        if (movimientoCaja == null) {
                            movimientoCaja = new MovimientoCaja(0,
                                cajaActiva.Id,
                                DateTime.Now,
                                montoPago,
                                TipoMovimientoCaja.Ingreso,
                                "Venta",
                                idPago,
                                UtilesCuentaUsuario.UsuarioAutenticado?.Id ?? 0,
                                "Movimiento de caja por venta de artículo");

                            datosMovimientoCaja.Adicionar(movimientoCaja);
                        } else {
                            movimientoCaja.Monto = montoPago;

                            datosMovimientoCaja.Editar(movimientoCaja);
                        }                            
                    }

                    // Actualizar el monto actual de la caja activa
                    var movimientosCaja = datosMovimientoCaja.Obtener();
                    var saldoActual = movimientosCaja.Sum(m => m.Monto);

                    cajaActiva.SaldoActual = cajaActiva.SaldoInicial + saldoActual;
                    datosCaja.Editar(cajaActiva);
                }
            }
        }
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