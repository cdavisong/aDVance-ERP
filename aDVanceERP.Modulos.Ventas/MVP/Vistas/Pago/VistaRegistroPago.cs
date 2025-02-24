using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.Ventas.MVP.Vistas.Pago.Plantillas;

using System.Globalization;

namespace aDVanceERP.Modulos.Ventas.MVP.Vistas.Pago {
    public partial class VistaRegistroPago : Form, IVistaRegistroPago, IVistaGestionPagos {
        private bool _modoEdicion;
        private float _total;

        public VistaRegistroPago() {
            InitializeComponent();
            Inicializar();
        }

        public bool Habilitada {
            get => Enabled;
            set => Enabled = value;
        }

        public Point Coordenadas {
            get => Location;
            set => Location = value;
        }

        public Size Dimensiones {
            get => Size;
            set => Size = value;
        }

        public string MetodoPago {
            get => fieldMetodoPago.Text;
            set => fieldMetodoPago.Text = value;
        }

        public float Monto {
            get => float.TryParse(fieldMonto.Text, out var total) ? total : 0;
            set => fieldMonto.Text = value.ToString("0.00", CultureInfo.CurrentCulture);
        }

        public List<string[]> Pagos { get; private set; }

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnRegistrar.Text = value ? "Actualizar pagos" : "Registrar pagos";
                _modoEdicion = value;
            }
        }

        public int AlturaContenedorVistas {
            get => contenedorVistas.Height;
        }

        public int TuplasMaximasContenedor {
            get => AlturaContenedorVistas / VariablesGlobales.AlturaTuplaPredeterminada;
        }

        public IRepositorioVista Vistas { get; private set; }

        public float Total {
            get => _total;
            set {
                _total = value;

                ActualizarPendiente();
            }
        }

        public float Suma {
            get => float.TryParse(fieldSuma.Text, out var total) ? total : 0;
            set => fieldSuma.Text = value.ToString("0.00", CultureInfo.CurrentCulture);
        }

        public float Pendiente {
            get => float.TryParse(fieldPendiente.Text, out var total) ? total : 0;
            set => fieldPendiente.Text = value.ToString("0.00", CultureInfo.CurrentCulture);
        }

        public float Devolucion {
            get => float.TryParse(fieldDevolucion.Text, out var total) ? total : 0;
            set => fieldDevolucion.Text = value.ToString("0.00", CultureInfo.CurrentCulture);
        }

        public event EventHandler? EfectuarTransferencia;
        public event EventHandler? PagoAgregado;
        public event EventHandler? PagoEliminado;
        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        public void Inicializar() {
            Pagos = new List<string[]>();
            Vistas = new RepositorioVistaBase(contenedorVistas);

            CargarMetodosPago();

            // Eventos
            btnCerrar.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
            fieldMetodoPago.SelectedIndexChanged += delegate (object? sender, EventArgs args) {
                if (fieldMetodoPago.SelectedIndex == 1) {
                    EfectuarTransferencia?.Invoke(sender, args);

                    fieldMonto.Focus();
                }
            };
            fieldMonto.TextChanged += delegate {
                btnAdicionarPago.Enabled = Monto > 0;
            };
            fieldMonto.KeyDown += delegate (object? sender, KeyEventArgs args) {
                if (args.KeyCode == Keys.Enter) {
                    AdicionarPago();

                    args.SuppressKeyPress = true;
                }
            };
            btnAdicionarPago.Click += delegate (object? sender, EventArgs args) {
                AdicionarPago();
            };
            PagoEliminado += delegate (object? sender, EventArgs args) {
                ActualizarTuplasPagos();
                ActualizarSuma();
            };
            btnRegistrar.Click += delegate (object? sender, EventArgs args) {
                if (ModoEdicionDatos)
                    EditarDatos?.Invoke(sender, args);
                else
                    Salir?.Invoke(sender, args);
            };
            btnSalir.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
        }

        public void CargarMetodosPago() {
            fieldMetodoPago.Items.Clear();
            fieldMetodoPago.Items.AddRange(new string[] {
                "Efectivo",
                "Transferencia bancaria"
            });
            fieldMetodoPago.SelectedIndex = 0;
        }

        public void AdicionarPago(string metodoPago = "", float monto = -1f) {
            var adMetodoPago = string.IsNullOrEmpty(metodoPago) ? MetodoPago : metodoPago;
            var adMonto = monto < 0f ? Monto : monto;
            var tuplaPago = new string[] {
                    adMetodoPago,
                    adMonto.ToString("0.00", CultureInfo.CurrentCulture)
                };

            Pagos.Add(tuplaPago);

            ActualizarTuplasPagos();
            ActualizarSuma();

            if (adMetodoPago.Contains("Transferencia"))
                fieldMetodoPago.Items.Remove(adMetodoPago);

            fieldMetodoPago.SelectedIndex = 0;
            fieldMonto.Text = string.Empty;
        }

        private void ActualizarTuplasPagos() {
            foreach (var tupla in contenedorVistas.Controls) {
                if (tupla is IVistaTuplaPago vistaTupla) {
                    vistaTupla.Cerrar();
                }
            }
            contenedorVistas.Controls.Clear();

            // Restablecer útima coordenada Y de la tupla
            VariablesGlobales.CoordenadaYUltimaTupla = 0;

            for (int i = 0; i < Pagos.Count; i++) {
                var pago = Pagos[i];
                var tuplaPago = new VistaTuplaPago();

                tuplaPago.MetodoPago = pago[0];
                tuplaPago.Monto = pago[1];
                tuplaPago.EliminarDatosTupla += delegate (object? sender, EventArgs args) {
                    Pagos.Remove(pago);
                    PagoEliminado?.Invoke(pago, args);
                };

                // Registro y muestra
                Vistas.Registrar(
                    $"vistaTupla{tuplaPago.GetType().Name}{i}",
                    tuplaPago,
                    new Point(0, VariablesGlobales.CoordenadaYUltimaTupla),
                    new Size(contenedorVistas.Width - 20, VariablesGlobales.AlturaTuplaPredeterminada), "N");
                tuplaPago.Mostrar();

                // Incremento de la útima coordenada Y de la tupla
                VariablesGlobales.CoordenadaYUltimaTupla += VariablesGlobales.AlturaTuplaPredeterminada;
            }
        }

        private void ActualizarSuma() {
            Suma = 0f;

            foreach (var pago in Pagos) {
                Suma += (float.TryParse(pago[1], NumberStyles.Float, CultureInfo.CurrentCulture, out var pagoParcial) ? pagoParcial : 0);
            }

            ActualizarPendiente();
        }

        private void ActualizarPendiente() {
            var pendiente = Total - Suma;

            Pendiente = pendiente < 0 ? 0 : pendiente;

            if (!ModoEdicionDatos)
                btnRegistrar.Enabled = Pendiente == 0;

            ActualizarDevolucion();
        }

        private void ActualizarDevolucion() {
            var pendiente = Total - Suma;

            Devolucion = pendiente < 0 ? pendiente * -1f : 0f;
        }

        public void Mostrar() {
            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            ModoEdicionDatos = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
