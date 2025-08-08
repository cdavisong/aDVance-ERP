using aDVanceERP.Core.Interfaces;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.Taller.Interfaces;
using aDVanceERP.Modulos.Taller.Modelos;

namespace aDVanceERP.Modulos.Taller.Vistas.OrdenProduccion
{
    public partial class VistaGestionOrdenesProduccion : Form, IVistaGestionOrdenesProduccion {
        private int _paginaActual = 1;
        private int _paginasTotales = 1;

        public VistaGestionOrdenesProduccion() {
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

        public CriterioBusquedaOrdenProduccion CriterioBusqueda {
            get => fieldCriterioBusqueda.SelectedIndex >= 0 ? (CriterioBusquedaOrdenProduccion) fieldCriterioBusqueda.SelectedIndex : default;
            set => fieldCriterioBusqueda.SelectedIndex = (int) value;
        }

        public string DatoBusqueda {
            get => fieldDatoBusqueda.Text;
            set => fieldDatoBusqueda.Text = value;
        }

        public bool HabilitarBtnCierreOrdenProduccion {
            get => btnCerrarOrdenProduccion.Visible;
            set => btnCerrarOrdenProduccion.Visible = value;
        }

        public int AlturaContenedorVistas {
            get => contenedorVistas.Height;
        }

        public int TuplasMaximasContenedor {
            get => AlturaContenedorVistas / VariablesGlobales.AlturaTuplaPredeterminada;
        }

        public int PaginaActual {
            get => _paginaActual;
            set {
                _paginaActual = value;
                fieldPaginaActual.Text = $"Página {value}";
            }
        }

        public int PaginasTotales {
            get => _paginasTotales;
            set {
                _paginasTotales = value;
                fieldPaginasTotales.Text = $"de {value}";
                HabilitarBotonesPaginacion();
            }
        }

        public IRepositorioVista Vistas { get; private set; }

        public event EventHandler? AlturaContenedorTuplasModificada;
        public event EventHandler? MostrarPrimeraPagina;
        public event EventHandler? MostrarPaginaAnterior;
        public event EventHandler? MostrarPaginaSiguiente;
        public event EventHandler? MostrarUltimaPagina;
        public event EventHandler? SincronizarDatos;
        public event EventHandler? Salir;
        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? BuscarDatos;
        public event EventHandler? CerrarOrdenProduccionSeleccionada;

        public void Inicializar() {
            // Variables locales
            Vistas = new PanelContenedorVistas(contenedorVistas);

            // Eventos
            fieldCriterioBusqueda.SelectedIndexChanged += delegate {
                if (CriterioBusqueda == CriterioBusquedaOrdenProduccion.FechaApertura || CriterioBusqueda == CriterioBusquedaOrdenProduccion.FechaCierre) {
                    fieldDatoBusquedaFecha.Value = DateTime.Now;
                    fieldDatoBusquedaFecha.Focus();
                } else {
                    fieldDatoBusqueda.Text = string.Empty;
                    fieldDatoBusqueda.Focus();
                }

                fieldDatoBusqueda.Visible = CriterioBusqueda != CriterioBusquedaOrdenProduccion.FechaApertura &&
                                            CriterioBusqueda != CriterioBusquedaOrdenProduccion.FechaCierre &&
                                            fieldCriterioBusqueda.SelectedIndex != 0;
                fieldDatoBusquedaFecha.Visible = (CriterioBusqueda == CriterioBusquedaOrdenProduccion.FechaApertura ||
                                                 CriterioBusqueda == CriterioBusquedaOrdenProduccion.FechaCierre) &&
                                                 fieldCriterioBusqueda.SelectedIndex != 0;

                if (CriterioBusqueda != CriterioBusquedaOrdenProduccion.FechaApertura &&
                    CriterioBusqueda != CriterioBusquedaOrdenProduccion.FechaCierre)
                    BuscarDatos?.Invoke(new object[] { CriterioBusqueda, string.Empty }, EventArgs.Empty);

                // Ir a la primera página al cambiar el criterio de búsqueda
                PaginaActual = 1;
                HabilitarBotonesPaginacion();
            };
            fieldDatoBusqueda.TextChanged += delegate (object? sender, EventArgs e) {
                if (!string.IsNullOrEmpty(DatoBusqueda))
                    BuscarDatos?.Invoke(new object[] { CriterioBusqueda, DatoBusqueda }, e);
                else SincronizarDatos?.Invoke(sender, e);
            };
            fieldDatoBusquedaFecha.ValueChanged += delegate (object? sender, EventArgs e) {
                BuscarDatos?.Invoke(new object[] { CriterioBusqueda, fieldDatoBusquedaFecha.Value.ToString("yyyy-MM-dd") },
                    e);
            };
            btnCerrarOrdenProduccion.Click += delegate (object? sender, EventArgs e) {
                CerrarOrdenProduccionSeleccionada?.Invoke(sender, e);
            };
            btnRegistrar.Click += delegate (object? sender, EventArgs e) {
                RegistrarDatos?.Invoke(sender, e);
            };
            btnPrimeraPagina.Click += delegate (object? sender, EventArgs e) {
                PaginaActual = 1;
                MostrarPrimeraPagina?.Invoke(sender, e);
                SincronizarDatos?.Invoke(sender, e);
                HabilitarBotonesPaginacion();
            };
            btnPaginaAnterior.Click += delegate (object? sender, EventArgs e) {
                PaginaActual--;
                MostrarPaginaAnterior?.Invoke(sender, e);
                SincronizarDatos?.Invoke(sender, e);
                HabilitarBotonesPaginacion();
            };
            btnPaginaSiguiente.Click += delegate (object? sender, EventArgs e) {
                PaginaActual++;
                MostrarPaginaSiguiente?.Invoke(sender, e);
                SincronizarDatos?.Invoke(sender, e);
                HabilitarBotonesPaginacion();
            };
            btnUltimaPagina.Click += delegate (object? sender, EventArgs e) {
                PaginaActual = PaginasTotales;
                MostrarUltimaPagina?.Invoke(sender, e);
                SincronizarDatos?.Invoke(sender, e);
                HabilitarBotonesPaginacion();
            };
            btnSincronizarDatos.Click += delegate (object? sender, EventArgs e) {
                SincronizarDatos?.Invoke(sender, e);
            };
            contenedorVistas.Resize += delegate {
                AlturaContenedorTuplasModificada?.Invoke(this, EventArgs.Empty);
            };
        }

        public void CargarCriteriosBusqueda(object[] criteriosBusqueda) {
            fieldCriterioBusqueda.Items.Clear();
            fieldCriterioBusqueda.Items.AddRange(criteriosBusqueda);

            fieldCriterioBusqueda.SelectedIndex = 0;
        }

        public void Mostrar() {
            Habilitar = true;
            BringToFront();
            Show();
        }

        public void Restaurar() {
            Habilitar = true;
            PaginaActual = 1;
            PaginasTotales = 1;
            HabilitarBtnCierreOrdenProduccion = false;


            fieldCriterioBusqueda.SelectedIndex = 0;
        }

        public void Ocultar() {
            Habilitar = false;
            Hide();
        }

        public void Dispose() {
            // ...
        }

        private void HabilitarBotonesPaginacion() {
            btnPrimeraPagina.Enabled = PaginaActual > 1;
            btnPaginaAnterior.Enabled = PaginaActual > 1;
            btnUltimaPagina.Enabled = PaginaActual < PaginasTotales;
            btnPaginaSiguiente.Enabled = PaginaActual < PaginasTotales;
        }
    }
}
