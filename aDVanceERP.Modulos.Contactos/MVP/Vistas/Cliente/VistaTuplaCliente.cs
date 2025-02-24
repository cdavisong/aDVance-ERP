using aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente {
    public partial class VistaTuplaCliente : Form, IVistaTuplaCliente {
        public VistaTuplaCliente() {
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

        public string Id {
            get => fieldId.Text;
            set => fieldId.Text = value;
        }

        public string Numero {
            get => fieldNumero.Text;
            set => fieldNumero.Text = value;
        }

        public string RazonSocial {
            get => fieldRazonSocial.Text;
            set {
                fieldRazonSocial.Text = value;
                fieldRazonSocial.Margin = new Padding(1, value?.Length > 43 ? 10 : 1, 1, 1);
            }
        }

        public string NombreContacto {
            get => fieldNombreContacto.Text;
            set {
                fieldNombreContacto.Text = value;
                fieldNombreContacto.Margin = new Padding(1, value?.Length > 43 ? 10 : 1, 1, 1);
            }
        }

        public Color ColorFondoTupla {
            get => layoutVista.BackColor;
            set => layoutVista.BackColor = value;
        }


        public event EventHandler? TuplaSeleccionada;
        public event EventHandler? EditarDatosTupla;
        public event EventHandler? EliminarDatosTupla;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            fieldId.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldNumero.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldRazonSocial.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldNombreContacto.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };

            btnEditar.Click += delegate (object? sender, EventArgs e) {
                EditarDatosTupla?.Invoke(this, e);
            };
            btnEliminar.Click += delegate (object? sender, EventArgs e) {
                EliminarDatosTupla?.Invoke(this, e);
            };
        }

        public void Mostrar() {
            BringToFront();
            Show();
        }

        public void Restaurar() {
            ColorFondoTupla = BackColor;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
