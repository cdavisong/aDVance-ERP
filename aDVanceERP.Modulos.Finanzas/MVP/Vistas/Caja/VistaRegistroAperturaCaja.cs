using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas;

using System.Globalization;

namespace aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja {
    public partial class VistaRegistroAperturaCaja : Form, IVistaRegistroAperturaCaja {
        private bool _modoEdicion;
        private DateTime _fechaApertura;

        public VistaRegistroAperturaCaja() {
            InitializeComponent();
            Inicializar();
        }

        public bool Habilitar {
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

        public DateTime Fecha {
            get => _fechaApertura;
            set {
                _fechaApertura = value;
                
                fieldSubtitulo.Text = ModoEdicion ?
                    $"Detalles de apertura en fecha {value:yyyy-MM-dd}" : 
                    $"Apertura en fecha {value:yyyy-MM-dd}";
            }
        }

        public decimal SaldoInicial {
            get => decimal.TryParse(fieldMontoInicial.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var total)
            ? total
            : 0;
            set => fieldMontoInicial.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }        

        public bool ModoEdicion {
            get => _modoEdicion;
            set {
                btnRegistrar.Text = value ? "Actualizar apertura" : "Abrir caja";
                _modoEdicion = value;
            }
        }

        public event EventHandler? Registrar;
        public event EventHandler? Editar;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Configuración de la ventana
            if (!ModoEdicion)
                Fecha = DateTime.Now;

            // Eventos
            btnCerrar.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
            btnRegistrar.Click += delegate (object? sender, EventArgs args) {
                if (ModoEdicion)
                    Editar?.Invoke(sender, args);
                else
                    Registrar?.Invoke(sender, args);
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
            ModoEdicion = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Dispose() {
            base.Dispose();
        }
    }
}
