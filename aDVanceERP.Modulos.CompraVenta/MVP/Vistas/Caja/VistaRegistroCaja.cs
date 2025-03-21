using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Caja.Plantillas;

using System.Globalization;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Caja {
    public partial class VistaRegistroCaja : Form, IVIstaRegistroCaja {
        private bool _modoEdicion;

        public VistaRegistroCaja() {
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

        public string Numero {
            get => fieldNumeroCaja.Text;
            set => fieldNumeroCaja.Text = value;
        }

        public decimal SaldoInicial {
            get => decimal.TryParse(fieldSaldoInicial.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var total) ? total : 0;
            set => fieldSaldoInicial.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public string Notas {
            get => fieldNotas.Text;
            set => fieldNotas.Text = value;
        }

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Apertura";
                btnRegistrar.Text = value ? "Actualizar caja registradora" : "Abrir caja registradora";
                _modoEdicion = value;
            }
        }

        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            btnCerrar.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
            btnRegistrar.Click += delegate (object? sender, EventArgs args) {
                if (ModoEdicionDatos)
                    EditarDatos?.Invoke(sender, args);
                else
                    RegistrarDatos?.Invoke(sender, args);
            };
            btnSalir.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
        }

        public void Mostrar() {
            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            Numero = string.Empty;
            SaldoInicial = 0;
            Notas = string.Empty;
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
