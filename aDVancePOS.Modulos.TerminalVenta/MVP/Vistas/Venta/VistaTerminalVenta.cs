using System.Globalization;

using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaArticulo.Plantillas;

using aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta.Plantillas;

namespace aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta {
    public partial class VistaTerminalVenta : Form, IVistaTerminalVenta, IVistaGestionDetallesCompraventaArticulos {
        private bool _modoEdicion;

        public VistaTerminalVenta() {
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

        public DateTime Fecha {
            get => DateTime.Now;
            set { }
        }

        public string? CriterioArticulo {
            get => fieldCriterioArticulo.Text;
            set => fieldCriterioArticulo.Text = value;
        }

        public List<string[]>? Articulos { get; private set; }

        public decimal Subtotal {
            get => decimal.TryParse(fieldSubtotal.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var total)
               ? total
               : 0;
            set => fieldSubtotal.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public decimal Descuento {
            get => decimal.TryParse(fieldDescuento.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var total)
               ? total
               : 0;
            set => fieldSubtotal.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public decimal Total {
            get => decimal.TryParse(fieldTotal.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var total)
                ? total
                : 0;
            set => fieldTotal.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public long IdTipoEntrega { get; set; } = 0;

        public int AlturaContenedorVistas {
            get => contenedorVistas.Height;
        }

        public int TuplasMaximasContenedor {
            get => AlturaContenedorVistas / VariablesGlobales.AlturaTuplaPredeterminada;
        }

        public IRepositorioVista? Vistas { get; private set; }

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set => _modoEdicion = value;
        }

        
        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? BuscarDatos;
        public event EventHandler? ArticuloAgregado;
        public event EventHandler? ArticuloEliminado;
        public event EventHandler? EfectuarPago;
        public event EventHandler? AsignarMensajeria;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
                        
        }

        public void Mostrar() {
            Habilitada = true;
            BringToFront();
            Show();
        }

        public void Restaurar() {
            Habilitada = true;

            fieldCriterioBusqueda.SelectedIndex = -1;
        }

        public void Ocultar() {
            Habilitada = false;
            Hide();
        }

        public void Cerrar() {
            // ...
        }

        public void CargarCriteriosBusqueda(object[] criteriosBusqueda) {
            throw new NotImplementedException();
        }

        public void CargarNombresArticulos(string[] nombresArticulos) {
            throw new NotImplementedException();
        }

        public void AdicionarArticulo(string nombreAlmacen = "", string nombreArticulo = "", string cantidad = "") {
            throw new NotImplementedException();
        }
    }
}
