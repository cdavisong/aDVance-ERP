using Manigest.Modulos.PuntoVenta.MVP.Vistas.Venta.Plantillas;

using System.Globalization;

namespace Manigest.Modulos.PuntoVenta.MVP.Vistas.Venta {
    public partial class VistaRegistroVenta : Form, IVistaRegistroVenta {
        private bool _modoEdicion;

        public VistaRegistroVenta() {
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
                btnRegistrar.Text = value ? "Actualizar movimiento" : "Registrar movimiento";
                _modoEdicion = value;
            }
        }

        public string NombreCliente {
            get => fieldNombreCliente.Text;
            set => fieldNombreCliente.Text = value;
        }

        public string NombreAlmacen {
            get => fieldNombreAlmacen.Text;
            set => fieldNombreAlmacen.Text = value;
        }

        public List<string> Productos {
            get => fieldNombreProducto.Items.Cast<string>().ToList();
            set {
                fieldNombreProducto.Items.Clear();
                fieldNombreProducto.Items.AddRange(value.ToArray());
                fieldNombreProducto.SelectedIndex = -1;
            }
        }

        public float Total {
            get => float.TryParse(fieldTotalVenta.Text, out var total) ? total : 0;
            set => fieldTotalVenta.Text = value.ToString("0.00", CultureInfo.CurrentCulture);
        }

        public event EventHandler? AgregarProducto;
        public event EventHandler? EliminarProducto;
        public event EventHandler? EfectuarPago;
        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;        

        public void Inicializar() {
            Productos = new List<string>();

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

        public void CargarNombresClientes(string[] nombresClientes) {
            fieldNombreCliente.Items.Add("Ninguno");
            fieldNombreCliente.Items.AddRange(nombresClientes);
            fieldNombreCliente.SelectedIndex = 0;
        }

        public void CargarNombresAlmacenes(string[] nombresAlmacenes) {
            fieldNombreAlmacen.Items.AddRange(nombresAlmacenes);
            fieldNombreAlmacen.SelectedIndex = 0;
        }

        public void CargarNombresProductos(string[] nombresProductos) {
            fieldNombreProducto.Items.AddRange(nombresProductos);
            fieldNombreProducto.SelectedIndex = -1;
        }

        public void ActualizarTotal(float total) {
            fieldTotalVenta.Text = (total < 0 ? 0 : total).ToString();
        }

        public void Mostrar() {
            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            Fecha = DateTime.Now;
            NombreCliente = string.Empty;
            fieldNombreCliente.SelectedIndex = 0;
            NombreAlmacen = string.Empty;
            fieldNombreAlmacen.SelectedIndex = 0;
            fieldNombreProducto.SelectedIndex = -1;
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
