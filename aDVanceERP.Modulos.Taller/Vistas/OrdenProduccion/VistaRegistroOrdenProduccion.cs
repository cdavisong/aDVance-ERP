using aDVanceERP.Modulos.Taller.Interfaces;

namespace aDVanceERP.Modulos.Taller.Vistas.OrdenProduccion {
    public partial class VistaRegistroOrdenProduccion : Form, IVistaRegistroOrdenProduccion {
        private bool _modoEdicion;

        public VistaRegistroOrdenProduccion() {
            InitializeComponent();
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

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnAbrirCerrarOrdenProduccion.Text = value ? "Cerrar orden de producción" : "Abrir orden de producción";
                _modoEdicion = value;
            }
        }

        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            btnAbrirCerrarOrdenProduccion.Click += delegate (object? sender, EventArgs args) {
                //if (ModoEdicionDatos)
                //    EditarDatos?.Invoke(sender, args);
                //else
                //    RegistrarDatos?.Invoke(sender, args);
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
