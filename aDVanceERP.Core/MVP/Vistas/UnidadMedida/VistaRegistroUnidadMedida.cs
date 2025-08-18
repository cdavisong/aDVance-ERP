using aDVanceERP.Core.MVP.Vistas.UnidadMedida.Plantillas;

namespace aDVanceERP.Core.MVP.Vistas.UnidadMedida {
    public partial class VistaRegistroUnidadMedida : Form, IVistaRegistroUnidadMedida {
        private bool _modoEdicion;

        public VistaRegistroUnidadMedida() {
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

        public string Abreviatura {
            get => fieldAbreviatura.Text;
            set => fieldAbreviatura.Text = value;
        }

        public string? Descripcion {
            get => fieldDescripcion.Text;
            set => fieldDescripcion.Text = value;
        }

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnRegistrar.Text = value ? "Actualizar unidad de medida" : "Registrar unidad de medida";
                _modoEdicion = value;
            }
        }

        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        

        public void Inicializar() {
            // Eventos
            btnCerrar.Click += delegate (object? sender, EventArgs args) {
                Close();
            };
            btnRegistrar.Click += delegate (object? sender, EventArgs args) {
                if (ModoEdicionDatos)
                    EditarDatos?.Invoke(sender, args);
                else
                    RegistrarDatos?.Invoke(sender, args);
            };
            btnSalir.Click += delegate (object? sender, EventArgs args) {
                Close();
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
