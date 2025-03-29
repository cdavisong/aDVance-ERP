using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra.Plantillas;

using System.Globalization;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra {
    public partial class VistaRegistroCompra : Form, IVistaRegistroCompra {
        private bool _modoEdicion;

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
            get => int.TryParse(fieldCantidad.Text, out var cantidad) ? cantidad : 0;
            set {
                fieldCantidad.Text = value > 0 ? value.ToString() : string.Empty;
                fieldCantidad.Text = value > 0 ? value.ToString() : "0";
            }
        }

        public decimal Total {
            get => decimal.TryParse(fieldTotalCompra.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var total) ? total : 0;
            set => fieldTotalCompra.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }
        public List<string[]>? Articulos { get; }

        public event EventHandler? ArticuloAgregado;
        public event EventHandler? ArticuloEliminado;
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

        public void CargarRazonesSocialesProveedores(object[] nombresProveedores) {
            fieldNombreProveedor.Items.Add("Anónimo");
            fieldNombreProveedor.Items.AddRange(nombresProveedores);
            fieldNombreProveedor.SelectedIndex = 0;
        }

        public void CargarNombresAlmacenes(object[] nombresAlmacenes) {
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
