using Manigest.Core.Utiles;
using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Ventas.MVP.Modelos;
using Manigest.Modulos.Ventas.MVP.Modelos.Repositorios;
using Manigest.Modulos.Ventas.MVP.Presentadores;
using Manigest.Modulos.Ventas.MVP.Vistas.Pago;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroPago _registroPago;
        
        public List<string[]> Pagos { get; private set; } = new List<string[]>();

        private void InicializarVistaRegistroPago() {
            _registroPago = new PresentadorRegistroPago(new VistaRegistroPago());
            _registroPago.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroPago.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroPago.Vista.Dimensiones = new Size(_registroPago.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
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

            _registroPago.Vista.Total = float.Parse(sender?.ToString() ?? "0");
            _registroPago.Vista.EfectuarTransferencia += delegate { 
                MostrarVistaRegistroDetallePagoTransferencia(sender, e); 
            };
            _registroPago.Vista.Mostrar();
            _registroPago = null;
        }

        private void MostrarVistaEdicionPago(object? sender, EventArgs e) {
            InicializarVistaRegistroPago();

            _registroPago.PopularVistaDesdeObjeto(sender as Pago);
            _registroPago.Vista.EfectuarTransferencia += delegate { 
                MostrarVistaEdicionDetallePagoTransferencia(sender, e); 
            };
            _registroPago.Vista.Mostrar();
            _registroPago = null;
        }

        private void RegistrarPagos() {
            if (Pagos.Count == 0)
                return;

            var datosPago = DatosPago.Instance;
            var ultimoIdVenta = UtilesBD.ObtenerUltimoIdTabla("venta");

            foreach (var pago in Pagos) {
                datosPago.Adicionar(new Pago(
                    0,
                    ultimoIdVenta,
                    pago[0],
                    float.Parse(pago[1])
                ));
            }

            Pagos.Clear();
        }
    }
}
