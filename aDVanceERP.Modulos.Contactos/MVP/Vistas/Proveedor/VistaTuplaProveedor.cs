using aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor {
    public partial class VistaTuplaProveedor : Form, IVistaTuplaProveedor {
        public VistaTuplaProveedor() {
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

        public string NumeroIdentificacionTributaria {
            get => fieldNumeroIdentificacionTributaria.Text;
            set => fieldNumeroIdentificacionTributaria.Text = value;
        }

        public string RazonSocial {
            get => fieldRazonSocial.Text;
            set => fieldRazonSocial.Text = value;
        }

        public string NombreRepresentante {
            get => fieldNombreRepresentante.Text;
            set => fieldNombreRepresentante.Text = value;
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
            fieldNumeroIdentificacionTributaria.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldRazonSocial.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldNombreRepresentante.Click += delegate (object? sender, EventArgs e) {
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
