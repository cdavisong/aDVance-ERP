using aDVanceERP.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas;

using System.Globalization;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Articulo {
    public partial class VistaRegistroArticulo : Form, IVistaRegistroArticulo {
        private bool _modoEdicion;

        public VistaRegistroArticulo() {
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

        public string Nombre {
            get => fieldNombre.Text;
            set => fieldNombre.Text = value;
        }

        public string Codigo {
            get => fieldCodigo.Text;
            set => fieldCodigo.Text = value;
        }

        public string Descripcion {
            get => fieldDescripcion.Text;
            set => fieldDescripcion.Text = value;
        }

        public string RazonSocialProveedor {
            get => fieldNombreProveedor.Text;
            set => fieldNombreProveedor.Text = value;
        }

        public decimal PrecioAdquisicion {
            get => decimal.TryParse(fieldPrecioAdquisicion.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var value) ? value : 0;
            set => fieldPrecioAdquisicion.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public decimal PrecioCesion {
            get => decimal.TryParse(fieldPrecioCesion.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var value) ? value : 0;
            set => fieldPrecioCesion.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public int StockMinimo {
            get => int.TryParse(fieldStockMinimo.Text, out var value) ? value : 0;
            set => fieldStockMinimo.Text = value.ToString();
        }

        public int PedidoMinimo {
            get => int.TryParse(fieldPedidoMinimo.Text, out var value) ? value : 0;
            set => fieldPedidoMinimo.Text = value.ToString();
        }

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnRegistrar.Text = value ? "Actualizar artículo" : "Registrar artículo";
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

        public void CargarRazonesSocialesProveedores(string[] nombresProveedores) {
            fieldNombreProveedor.Items.Add("Ninguno");
            fieldNombreProveedor.Items.AddRange(nombresProveedores);
            fieldNombreProveedor.SelectedIndex = 0;
        }

        public void Mostrar() {
            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            Nombre = string.Empty;
            Codigo = string.Empty;
            Descripcion = string.Empty;
            RazonSocialProveedor = string.Empty;
            fieldNombreProveedor.SelectedIndex = 0;
            PrecioAdquisicion = 0;
            PrecioCesion = 0;
            StockMinimo = 0;
            PedidoMinimo = 0;
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
