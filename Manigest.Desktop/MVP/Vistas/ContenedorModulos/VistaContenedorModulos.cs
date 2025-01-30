using Manigest.Core.MVP.Modelos.Repositorios;
using Manigest.Core.MVP.Modelos.Repositorios.Plantillas;
using Manigest.Desktop.MVP.Vistas.ContenedorModulos.Plantillas;

namespace Manigest.Desktop.MVP.Vistas.ContenedorModulos {
    public partial class VistaContenedorModulos : Form, IVistaContenedorModulos {
        public VistaContenedorModulos() {
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

        public int AlturaContenedorVistas {
            get => contenedorVistas.Height;
        }

        //public bool BtnModuloAdministracionVisible {
        //    get => btnModuloAdministracion.Visible;
        //    set => btnModuloAdministracion.Visible = value;
        //}

        public IRepositorioVista Vistas { get; private set; }

        public event EventHandler? MostrarVistaInicio;
        public event EventHandler? MostrarMenuEstadisticas;
        public event EventHandler? CambioModulo;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Propiedades locales
            Vistas = new RepositorioVistaBase(contenedorVistas);
            btnInicio.Checked = true;

            // Eventos
            btnInicio.Click += delegate (object? sender, EventArgs e) {
                CambioModulo?.Invoke(sender, e);
                MostrarVistaInicio?.Invoke(sender, e);
            };
            btnModuloEstadisticas.Click += delegate (object? sender, EventArgs e) {
                CambioModulo?.Invoke(sender, e);
                MostrarMenuEstadisticas?.Invoke(sender, e);
            };
            CambioModulo += delegate { Restaurar(); };
        }

        public void Mostrar() {
            BringToFront();
            Show();
        }

        public void Restaurar() {
            Vistas.Ocultar(true);
        }

        public void Ocultar() {
            btnInicio.Checked = true;

            Hide();
        }

        public void Cerrar() {
            Vistas.Cerrar();
        }
    }
}
