using aDVanceERP.Core.MVP.Vistas.UnidadMedida.Plantillas;

namespace aDVanceERP.Core.MVP.Vistas.UnidadMedida {
    public partial class VistaRegistroUnidadMedida : Form, IVistaRegistroUnidadMedida {
        private bool _modoEdicion;

        public VistaRegistroUnidadMedida() {
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

        public string Nombre {
            get => fieldNombre.Text;
            set => fieldNombre.Text = value;
        }

        public string Abreviatura {
            get => fieldAbreviatura.Text;
            set => fieldAbreviatura.Text = value;
        }

        public string? Descripcion {
            get => fieldDescripcion.Text;
            set => fieldDescripcion.Text = value;
        }

        public bool ModoEdicion {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnRegistrar.Text = value ? "Actualizar unidad de medida" : "Registrar unidad de medida";
                _modoEdicion = value;
            }
        }

        public event EventHandler? Registrar;
        public event EventHandler? Editar;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        public void Inicializar() {
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
            Nombre = string.Empty;
            Abreviatura = string.Empty;
            Descripcion = string.Empty;
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
