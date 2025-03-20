using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Pago;
using System.Globalization;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroPago _registroPago;

        public List<string[]> Pagos { get; private set; } = new List<string[]>();

        private void InicializarVistaRegistroPago() {
            _registroPago = new PresentadorRegistroPago(new VistaRegistroPago());
            _registroPago.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
            _registroPago.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroPago.Vista.PagoEliminado += delegate (object? sender, EventArgs e) {
                if (sender is string[] metodoPago && metodoPago[0].Contains("Transferencia")) {
                    _registroPago.Vista.CargarMetodosPago();

                    Transferencia = new string[0];
                }
            };
            _registroPago.Salir += delegate {
                Pagos = _registroPago.Vista.Pagos;
            };
        }

        private void MostrarVistaRegistroPago(object? sender, EventArgs e) {
            InicializarVistaRegistroPago();

            if (_registroPago != null) {
                if (sender is decimal decimalValue)
                    _registroPago.Vista.Total = decimalValue;
                else
                    _registroPago.Vista.Total = 0.00m; // Valor por defecto si la conversión falla                
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

        private void RegistrarPagos() {
            if (Pagos == null || Pagos.Count == 0)
                return;

            using (var datosPago = new DatosPago()) {
                var ultimoIdVenta = UtilesBD.ObtenerUltimoIdTabla("venta");

                foreach (var pago in Pagos) {
                    datosPago.Adicionar(new Pago(
                        0,
                        ultimoIdVenta,
                        pago[0],
                        decimal.TryParse(pago[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var monto) ? monto : 0.00m
                    ));
                }
            }

            Pagos.Clear();
        }
    }
}
