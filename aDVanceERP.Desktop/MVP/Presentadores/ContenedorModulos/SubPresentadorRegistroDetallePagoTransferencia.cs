using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Ventas.MVP.Modelos;
using aDVanceERP.Modulos.Ventas.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Ventas.MVP.Presentadores;
using aDVanceERP.Modulos.Ventas.MVP.Vistas.DetallePagoTransferencia;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroDetallePagoTransferencia _registroDetallePagoTransferencia;

        public string[] Transferencia { get; private set; } = new string[0];

        private void InicializarVistaRegistroDetallePagoTransferencia() {
            _registroDetallePagoTransferencia = new PresentadorRegistroDetallePagoTransferencia(new VistaRegistroDetallePagoTransferencia());
            _registroDetallePagoTransferencia.Vista.CargarAliasTarjetas(UtilesCuentaBancaria.ObtenerAliasesCuentas());
            _registroDetallePagoTransferencia.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
            _registroDetallePagoTransferencia.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroDetallePagoTransferencia.Salir += delegate {
                Transferencia = new string[] {
                    _registroDetallePagoTransferencia.Vista.Alias,
                    _registroDetallePagoTransferencia.Vista.NumeroConfirmacion,
                    _registroDetallePagoTransferencia.Vista.NumeroTransaccion
                };
            };
        }

        private void MostrarVistaRegistroDetallePagoTransferencia(object? sender, EventArgs e) {
            InicializarVistaRegistroDetallePagoTransferencia();

            if (_registroDetallePagoTransferencia != null) {
                _registroDetallePagoTransferencia.Vista.Mostrar();
            }

            _registroDetallePagoTransferencia?.Dispose();
        }

        private void MostrarVistaEdicionDetallePagoTransferencia(object? sender, EventArgs e) {
            InicializarVistaRegistroDetallePagoTransferencia();

            if (_registroDetallePagoTransferencia != null && sender is DetallePagoTransferencia detallePagoTransferencia) {
                _registroDetallePagoTransferencia.PopularVistaDesdeObjeto(detallePagoTransferencia);
                _registroDetallePagoTransferencia.Vista.Mostrar();
            }

            _registroDetallePagoTransferencia?.Dispose();
        }

        private void RegistrarTransferencia() {
            if (Transferencia == null || Transferencia.Length == 0)
                return;

            using (var transferencia = new DatosDetallePagoTransferencia()) {
                transferencia.Adicionar(new DetallePagoTransferencia(
                    0,
                    UtilesBD.ObtenerUltimoIdTabla("venta"),
                    UtilesCuentaBancaria.ObtenerIdCuenta(Transferencia[0]),
                    Transferencia[1],
                    Transferencia[2]
                ));
            }

            Transferencia = new string[0];
        }
    }
}
