using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas;

using System.Globalization;

namespace aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja {
    public partial class VistaRegistroAperturaCaja : Form, IVistaRegistroAperturaCaja {
        private bool _modoEdicion;

        public VistaRegistroAperturaCaja() {
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

        public decimal SaldoInicial {
            get => decimal.TryParse(fieldMontoInicial.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var total)
            ? total
            : 0;
            set => fieldMontoInicial.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }        

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles de apertura" : $"Apertura en fecha {DateTime.Today.ToString("yyyy-MM-dd")}";
                btnRegistrar.Text = value ? "Actualizar apertura" : "Abrir caja";
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
