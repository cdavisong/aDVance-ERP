using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Desktop.MVP.Vistas.ContenedorModulos.Plantillas;

using TheArtOfDevHtmlRenderer.Core.Entities;

namespace aDVanceERP.Desktop.MVP.Vistas.ContenedorModulos {
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

        public int TuplasMaximasContenedor {
            get => AlturaContenedorVistas / VariablesGlobales.AlturaTuplaPredeterminada;
        }

        //public bool BtnModuloAdministracionVisible {
        //    get => btnModuloAdministracion.Visible;
        //    set => btnModuloAdministracion.Visible = value;
        //}

        public IRepositorioVista Vistas { get; private set; }

        public event EventHandler? MostrarVistaInicio;
        public event EventHandler? MostrarMenuEstadisticas;
        public event EventHandler? MostrarMenuContactos;
        public event EventHandler? MostrarMenuFinanzas;
        public event EventHandler? MostrarMenuInventario;
        public event EventHandler? MostrarMenuVentas;
        public event EventHandler? CambioModulo;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Propiedades locales
            Vistas = new RepositorioVistaBase(contenedorVistas);
            btnInicio.Checked = true;

            // Eventos
            fieldTextoBienvenida.LinkClicked += delegate (object? sender, HtmlLinkClickedEventArgs e) {
                CambioModulo?.Invoke(sender, e);
                MostrarMenuVentas?.Invoke(sender, e);
                btnModuloVentas.Checked = true;
            };
            btnInicio.Click += delegate (object? sender, EventArgs e) {
                CambioModulo?.Invoke(sender, e);
                MostrarVistaInicio?.Invoke(sender, e);
            };
            btnModuloEstadisticas.Click += delegate (object? sender, EventArgs e) {
                CambioModulo?.Invoke(sender, e);
                MostrarMenuEstadisticas?.Invoke(sender, e);
            };
            btnModuloContactos.Click += delegate (object? sender, EventArgs e) {
                CambioModulo?.Invoke(sender, e);
                MostrarMenuContactos?.Invoke(sender, e);
            };
            btnModuloFinanzas.Click += delegate (object? sender, EventArgs e) {
                CambioModulo?.Invoke(sender, e);
                MostrarMenuFinanzas?.Invoke(sender, e);
            };
            btnModuloInventario.Click += delegate (object? sender, EventArgs e) {
                CambioModulo?.Invoke(sender, e);
                MostrarMenuInventario?.Invoke(sender, e);
            };
            btnModuloVentas.Click += delegate (object? sender, EventArgs e) {
                CambioModulo?.Invoke(sender, e);
                MostrarMenuVentas?.Invoke(sender, e);
            };
            CambioModulo += delegate {
                Restaurar();
            };
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
