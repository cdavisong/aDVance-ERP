using aDVanceERP.Modulos.Taller.Interfaces;

namespace aDVanceERP.Modulos.Taller.Vistas.CostosProduccion {
    public partial class VistaRegistroCostoProduccion : Form, IVistaRegistroCostoProduccion {
        private bool _modoEdicion;
        private int _paginaActual = 1;

        private VistaRegistroDatosGenerales P1DatosGenerales = new VistaRegistroDatosGenerales();
        private VistaRegistroMateriaPrima P2MateriasPrimas = new VistaRegistroMateriaPrima();

        public VistaRegistroCostoProduccion() {
            InitializeComponent();
            InicializarVistas();
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

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnRegistrar.Text = value ? "Actualizar costos" : "Registrar costos";
                _modoEdicion = value;
            }
        }

        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        private void InicializarVistas() {
            // 1. Datos generales del producto
            P1DatosGenerales.Dock = DockStyle.Fill;
            P1DatosGenerales.TopLevel = false;

            // 2. Materias primas
            P2MateriasPrimas.Dock = DockStyle.Fill;
            P2MateriasPrimas.TopLevel = false;

            contenedorVistas.Controls.Clear();
            contenedorVistas.Controls.Add(P1DatosGenerales);
            contenedorVistas.Controls.Add(P2MateriasPrimas);

            // Mostrar vista de datos generales
            P1DatosGenerales.Show();
            P1DatosGenerales.BringToFront();
        }

        public void Inicializar() {
            // Eventos
            btnRegistrar.Click += delegate (object? sender, EventArgs args) {
                if (ModoEdicionDatos)
                    EditarDatos?.Invoke(sender, args);
                else
                    RegistrarDatos?.Invoke(sender, args);
            };
            btnAnterior.Click += delegate (object? sender, EventArgs args) {
                if (_paginaActual > 1)
                    RetrocederPagina();
            };
            btnRegistrar.Click += delegate (object? sender, EventArgs args) {
                if (ModoEdicionDatos)
                    EditarDatos?.Invoke(sender, args);
                else
                    RegistrarDatos?.Invoke(sender, args);
            };
            btnSiguiente.Click += delegate (object? sender, EventArgs args) {
                if (_paginaActual < 2)
                    AvanzarPagina();
            };
            btnSalir.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };

            // Navegación
            ConfigurarParametrosBotonesNavegacion(false, true);
        }

        private void AvanzarPagina() {
            // Mapeo de navegación: página actual -> siguiente página
            var navegacion = new Dictionary<int, Action> {
                [1] = () => MostrarOcultarFormularios(P2MateriasPrimas, [P1DatosGenerales])
            };

            if (navegacion.TryGetValue(_paginaActual, out var action)) {
                action.Invoke();
                _paginaActual++;
            }

            ActualizarBotones();
        }

        private void RetrocederPagina() {
            // Mapeo de navegación: página actual -> página anterior
            var navegacion = new Dictionary<int, Action> {
                [2] = () => MostrarOcultarFormularios(P1DatosGenerales, [P2MateriasPrimas])
            };

            if (navegacion.TryGetValue(_paginaActual, out var action)) {
                action.Invoke();
                _paginaActual--;
            }

            ActualizarBotones();
        }

        private void ActualizarBotones() {
            var mostrarBotonAnterior = _paginaActual > 1;
            var mostrarBotonSiguiente = _paginaActual < 2;

            ConfigurarParametrosBotonesNavegacion(mostrarBotonAnterior, mostrarBotonSiguiente);
        }

        private void MostrarOcultarFormularios(Form formularioMostrar, Form[] formulariosOcultar) {
            foreach (var form in formulariosOcultar)
                form.Hide();

            formularioMostrar.Show();
            formularioMostrar.BringToFront();
        }

        public void ConfigurarParametrosBotonesNavegacion(bool mostrarAnterior, bool mostrarSiguiente) {
            // Ajustar visibilidad y ancho de columna para botón anterior
            btnAnterior.Visible = mostrarAnterior;
            layoutNavegacion.ColumnStyles[0].Width = mostrarAnterior ? 50F : 0F;

            // Ajustar visibilidad y ancho de columna para botón siguiente
            btnSiguiente.Visible = mostrarSiguiente;
            layoutNavegacion.ColumnStyles[2].Width = mostrarSiguiente ? 50F : 0F;

            // Ajustar bordes del botón registrar
            btnRegistrar.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges(
                !mostrarAnterior,
                !mostrarSiguiente,
                !mostrarAnterior,
                !mostrarSiguiente
            );

            // Forzar el redibujado del layout
            layoutBotones.PerformLayout();
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
