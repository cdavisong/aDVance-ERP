using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra.Plantillas;

using System.Globalization;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra {
    public partial class VistaRegistroCompra : Form, IVistaRegistroCompra {
        private bool _modoEdicion;
        private bool _articuloValido;

        public VistaRegistroCompra() {
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

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnRegistrar.Text = value ? "Actualizar venta" : "Registrar venta";
                _modoEdicion = value;
            }
        }

        public string? RazonSocialProveedor {
            get => fieldNombreProveedor.Text;
            set => fieldNombreProveedor.Text = value;
        }

        public string? NombreAlmacen {
            get => fieldNombreAlmacen.Text;
            set => fieldNombreAlmacen.Text = value;
        }

        public string? NombreArticulo {
            get => fieldNombreArticulo.Text;
            set => fieldNombreArticulo.Text = value;
        }

        public int Cantidad {
            get => int.TryParse(fieldCantidadArticulos.Text, out var cantidad) ? cantidad : 0;
            set { 
                fieldCantidadArticulos.Text = value > 0 ? value.ToString() : string.Empty;
                fieldCantidad.Text = value > 0 ? value.ToString() : "0";
            }
        }

        public decimal PrecioUnitario {
            get => decimal.TryParse(fieldPrecioUnitario.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var total) ? total : 0;
            set => fieldPrecioUnitario.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public decimal Total {
            get => decimal.TryParse(fieldTotalCompra.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var total) ? total : 0;
            set => fieldTotalCompra.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public event EventHandler? RegistrarArticulo;
        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            btnCerrar.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke("exit", args);
            };
            fieldNombreAlmacen.SelectedIndexChanged += async delegate {
                var idAlmacen = UtilesAlmacen.ObtenerIdAlmacen(NombreAlmacen).Result;

                CargarNombresArticulos(await UtilesArticulo.ObtenerNombresArticulos(idAlmacen));
            };
            fieldNombreArticulo.TextChanged += delegate {
                _articuloValido = UtilesArticulo.ObtenerIdArticulo(NombreArticulo).Result != 0;

                if (_articuloValido)
                    fieldCantidadArticulos.Focus();

                ActualizarMontoTotalCompra();
            };
            btnAdicionarArticulo.Click += delegate (object? sender, EventArgs args) {
                RegistrarArticulo?.Invoke(sender, args);

                NombreArticulo = string.Empty;
                fieldNombreArticulo.Focus();
            };
            fieldCantidadArticulos.TextChanged += delegate {
                btnRegistrar.Enabled = Cantidad > 0 && _articuloValido;
                Cantidad = int.TryParse(fieldCantidadArticulos.Text, out var cantidad) ? cantidad : 0;

                ActualizarMontoTotalCompra();
            };
            fieldCantidadArticulos.KeyDown += delegate (object? sender, KeyEventArgs args) {
                if (args.KeyCode == Keys.Enter && _articuloValido) {
                    if (ModoEdicionDatos)
                        EditarDatos?.Invoke(sender, args);
                    else
                        RegistrarDatos?.Invoke(sender, args);

                    args.SuppressKeyPress = true;
                }
            };
            btnRegistrar.Click += delegate (object? sender, EventArgs args) {
                if (ModoEdicionDatos)
                    EditarDatos?.Invoke(sender, args);
                else
                    RegistrarDatos?.Invoke(sender, args);
            };
            btnSalir.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke("exit", args);
            };
        }

        private void ActualizarMontoTotalCompra() {
            if (_articuloValido && Cantidad > 0) {
                var precioUnitario = UtilesArticulo.ObtenerPrecioUnitarioArticulo(UtilesArticulo.ObtenerIdArticulo(NombreArticulo).Result).Result;

                PrecioUnitario = precioUnitario;
                Total = precioUnitario * Cantidad;                
            }
        }

        public void CargarRazonesSocialesProveedores(string[] nombresProveedores) {
            fieldNombreProveedor.Items.Add("Anónimo");
            fieldNombreProveedor.Items.AddRange(nombresProveedores);
            fieldNombreProveedor.SelectedIndex = 0;
        }

        public void CargarNombresAlmacenes(string[] nombresAlmacenes) {
            fieldNombreAlmacen.Items.AddRange(nombresAlmacenes);
            fieldNombreAlmacen.SelectedIndex = 0;
        }

        public void CargarNombresArticulos(string[] nombresArticulos) {
            fieldNombreArticulo.AutoCompleteCustomSource.Clear();
            fieldNombreArticulo.AutoCompleteCustomSource.AddRange(nombresArticulos);
            fieldNombreArticulo.AutoCompleteMode = AutoCompleteMode.Suggest;
            fieldNombreArticulo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public void Mostrar() {
            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            Fecha = DateTime.Now;
            RazonSocialProveedor = string.Empty;
            fieldNombreProveedor.SelectedIndex = 0;
            NombreAlmacen = string.Empty;
            fieldNombreAlmacen.SelectedIndex = 0;
            fieldNombreArticulo.AutoCompleteCustomSource.Clear();
            Total = 0;
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
