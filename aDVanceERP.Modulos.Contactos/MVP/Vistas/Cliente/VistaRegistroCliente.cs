using aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente {
    public partial class VistaRegistroCliente : Form, IVistaRegistroCliente {
        private bool _modoEdicion;

        public VistaRegistroCliente() {
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
            get => fieldNumero.Text;
            set => fieldNumero.Text = value;
        }

        public string RazonSocial {
            get => fieldRazonSocial.Text;
            set => fieldRazonSocial.Text = value;
        }

        public string NombreContacto {
            get => fieldNombreContacto.Text;
            set {
                fieldNombreContacto.Text = value;
                fieldNombreContacto.Margin = new Padding(1, value?.Length > 43 ? 10 : 1, 1, 1);
            }
        }

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnRegistrar.Text = value ? "Actualizar cliente" : "Crear cliente";
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

        public void CargarNombresContactos(string[] nombresContactos) {
            fieldNombreContacto.Items.Add("Ninguno");
            fieldNombreContacto.Items.AddRange(nombresContactos);
            fieldNombreContacto.SelectedIndex = 0;
        }

        public void Mostrar() {
            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            Numero = string.Empty;
            RazonSocial = string.Empty;
            NombreContacto = string.Empty;
            fieldNombreContacto.SelectedIndex = -1;
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
