using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra.Plantillas;

using System.Globalization;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra {
    public partial class VistaGestionCompras : Form, IVistaGestionCompras {
        private int _paginaActual = 1;
        private int _paginasTotales = 1;

        public VistaGestionCompras() {
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

        public string FormatoReporte {
            get => fieldFormatoReporte.Text;
            set => fieldFormatoReporte.Text = value;
        }

        public CriterioBusquedaCompra CriterioBusqueda {
            get => fieldCriterioBusqueda.SelectedIndex >= 0 ? (CriterioBusquedaCompra) fieldCriterioBusqueda.SelectedIndex : default;
            set => fieldCriterioBusqueda.SelectedIndex = (int) value;
        }

        public string? DatoBusqueda {
            get => fieldDatoBusqueda.Text;
            set => fieldDatoBusqueda.Text = value;
        }

        public string ValorBrutoCompra {
            get => fieldValorBrutoCompra.Text;
            set {
                layoutValorBrutoCompra.Visible = !value.Equals("0.00");
                fieldValorBrutoCompra.Text = value;
            }
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

        public IRepositorioVista? Vistas { get; private set; }

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
        public event EventHandler? DescargarReporte;
        public event EventHandler? ImprimirReporte;
        public event EventHandler? BuscarDatos;

        public void Inicializar() {
            // Vistas
            Vistas = new RepositorioVistaBase(contenedorVistas);

            // Eventos
            btnDescargar.Click += delegate {
                var tuplasCompras = contenedorVistas.Controls.OfType<IVistaTuplaCompra>();
                var filas = new List<string[]>();

                foreach (var tuplaCompra in tuplasCompras) {
                    var fila = new string[5];

                    fila[0] = tuplaCompra.NombreAlmacen;
                    fila[1] = tuplaCompra.NombreProveedor;
                    fila[2] = tuplaCompra.MontoTotal;

                    filas.Add(fila);
                }

                //TODO: Generar el reporte de compras
            };
            fieldDatoBusqueda.TextChanged += delegate (object? sender, EventArgs e) {
                if (!string.IsNullOrEmpty(DatoBusqueda))
                    BuscarDatos?.Invoke(new object[] { CriterioBusqueda, DatoBusqueda }, e);
                else SincronizarDatos?.Invoke(sender, e);
            };
            fieldDatoBusquedaFecha.ValueChanged += delegate (object? sender, EventArgs e) {
                BuscarDatos?.Invoke(new object[] { CriterioBusqueda, fieldDatoBusquedaFecha.Value.ToString("yyyy-MM-dd") }, e);

                ActualizarMontoCompra();
            };
            btnCerrar.Click += delegate (object? sender, EventArgs e) {
                Salir?.Invoke(sender, e);
                Ocultar();
            };
            btnRegistrar.Click += delegate (object? sender, EventArgs e) {
                RegistrarDatos?.Invoke(sender, e);

                ActualizarMontoCompra();
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

                ActualizarMontoCompra();
            };
            contenedorVistas.Resize += delegate {
                AlturaContenedorTuplasModificada?.Invoke(this, EventArgs.Empty);
            };
        }

        private void ActualizarMontoCompra() {
            ValorBrutoCompra = UtilesCompra.ObtenerValorBrutoCompraDia(fieldDatoBusquedaFecha.Value).ToString("N2", CultureInfo.InvariantCulture); ;
        }

        public void CargarCriteriosBusqueda(object[] criteriosBusqueda) {
            fieldCriterioBusqueda.Items.AddRange(criteriosBusqueda);
            fieldCriterioBusqueda.SelectedIndexChanged += delegate {
                if (CriterioBusqueda == CriterioBusquedaCompra.Fecha) {
                    fieldDatoBusquedaFecha.Value = DateTime.Now;
                    fieldDatoBusquedaFecha.Focus();

                    ActualizarMontoCompra();
                } else {
                    layoutValorBrutoCompra.Visible = false;

                    fieldDatoBusqueda.Text = string.Empty;
                    fieldDatoBusqueda.Focus();
                }

                fieldDatoBusqueda.Visible = CriterioBusqueda != CriterioBusquedaCompra.Fecha && fieldCriterioBusqueda.SelectedIndex != 0;
                fieldDatoBusquedaFecha.Visible = CriterioBusqueda == CriterioBusquedaCompra.Fecha && fieldCriterioBusqueda.SelectedIndex != 0;

                if (CriterioBusqueda != CriterioBusquedaCompra.Fecha)
                    BuscarDatos?.Invoke(new object[] { CriterioBusqueda, string.Empty }, EventArgs.Empty);

                // Ir a la primera página al cambiar el criterio de búsqueda
                PaginaActual = 1;
                HabilitarBotonesPaginacion();
            };
            fieldCriterioBusqueda.SelectedIndex = 5;
        }

        public void Mostrar() {
            Habilitada = true;
            VerificarPermisos();
            BringToFront();
            Show();
        }

        private void VerificarPermisos() {
            btnRegistrar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_COMPRAVENTA_COMPRA_ADICIONAR")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_COMPRAVENTA_COMPRA_TODOS")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_COMPRAVENTA_TODOS");
        }

        public void Restaurar() {
            Habilitada = true;
            PaginaActual = 1;
            PaginasTotales = 1;

            fieldCriterioBusqueda.SelectedIndex = 5;
        }

        public void Ocultar() {
            Habilitada = false;
            Hide();
        }

        public void Cerrar() {
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
