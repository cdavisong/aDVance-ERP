using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
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
            _registroDetallePagoTransferencia.Vista.CargarAliasTarjetas(UtilesCuenta.ObtenerAliasesCuentas());
            _registroDetallePagoTransferencia.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroDetallePagoTransferencia.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroDetallePagoTransferencia.Vista.Dimensiones = new Size(_registroDetallePagoTransferencia.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
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

            _registroDetallePagoTransferencia.Vista.Mostrar();
            _registroDetallePagoTransferencia = null;
        }

        private void MostrarVistaEdicionDetallePagoTransferencia(object? sender, EventArgs e) {
            InicializarVistaRegistroDetallePagoTransferencia();

            _registroDetallePagoTransferencia.PopularVistaDesdeObjeto(sender as DetallePagoTransferencia);
            _registroDetallePagoTransferencia.Vista.Mostrar();
            _registroDetallePagoTransferencia = null;
        }

        private void RegistrarTransferencia() {
            if (Transferencia.Length == 0)
                return;

            DatosDetallePagoTransferencia.Instance.Adicionar(new DetallePagoTransferencia(
                0,
                UtilesBD.ObtenerUltimoIdTabla("venta"),
                UtilesCuenta.ObtenerIdCuenta(Transferencia[0]),
                Transferencia[1],
                Transferencia[2]
            ));

            Transferencia = new string[0];
        }
    }
}
