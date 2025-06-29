
using System.Globalization;

namespace aDVanceERP.Modulos.Taller.Vistas.ActividadProduccion {
    public partial class VistaRegistroActividadProduccion : Form {
        private bool _modoEdicion;

        public VistaRegistroActividadProduccion() {
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

        public string Nombre {
            get => fieldNombre.Text;
            set => fieldNombre.Text = value;
        }

        public string Descripcion {
            get => fieldDescripcion.Text;
            set => fieldDescripcion.Text = value;
        }

        public decimal Costo {
            get => decimal.TryParse(fieldCosto.Text, NumberStyles.Any, CultureInfo.InvariantCulture,
                 out var value)
                 ? value
                 : 0;
            set => fieldCosto.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnRegistrar.Text = value ? "Actualizar actividad" : "Registrar actividad";
                _modoEdicion = value;
            }
        }

        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
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
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Costo = 0;
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
