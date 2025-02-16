using Manigest.Core.MVP.Modelos.Repositorios;
using Manigest.Core.MVP.Modelos.Repositorios.Plantillas;
using Manigest.Core.Utiles;
using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Ventas.MVP.Vistas.Venta.Plantillas;

using System.Globalization;

namespace Manigest.Modulos.Ventas.MVP.Vistas.Venta {
    public partial class VistaRegistroVenta : Form, IVistaRegistroVenta, IVistaGestionDetallesVentaArticulos {
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

        public string NombreArticulo {
            get => fieldNombreArticulo.Text;
            set => fieldNombreArticulo.Text = value;
        }

        public List<string[]> Articulos { get; private set; }

        public int Cantidad {
            get => int.TryParse(fieldCantidad.Text, out var cantidad) ? cantidad : 0;
            set => fieldCantidad.Text = value > 0 ? value.ToString() : string.Empty;
        }

        public float Total {
            get => float.TryParse(fieldTotalVenta.Text, out var total) ? total : 0;
            set => fieldTotalVenta.Text = value.ToString("0.00", CultureInfo.CurrentCulture);
        }
        public int AlturaContenedorVistas {
            get => contenedorVistas.Height;
        }

        public IRepositorioVista Vistas { get; private set; }

        public event EventHandler? ArticuloAgregado;
        public event EventHandler? ArticuloEliminado;
        public event EventHandler? EfectuarPago;
        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;        
        public event EventHandler? AlturaContenedorTuplasModificada;
        public event EventHandler? Salir;

        public void Inicializar() {
            Articulos = new List<string[]>();
            Vistas = new RepositorioVistaBase(contenedorVistas);

            // Eventos            
            btnCerrar.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
            fieldNombreAlmacen.SelectedIndexChanged += delegate {
                var idAlmacen = UtilesAlmacen.ObtenerIdAlmacen(NombreAlmacen);

                CargarNombresArticulos(UtilesArticulo.ObtenerNombresArticulos(idAlmacen));
            };
            fieldCantidad.TextChanged += delegate {
                btnAdicionarArticulo.Enabled = Cantidad > 0;
            };
            fieldCantidad.KeyDown += delegate (object? sender, KeyEventArgs args) {
                if (args.KeyCode == Keys.Enter) {
                    AdicionarArticulo();

                    args.SuppressKeyPress = true;
                }
            };
            btnAdicionarArticulo.Click += delegate (object? sender, EventArgs args) {
                AdicionarArticulo();
            };
            ArticuloEliminado += delegate (object? sender, EventArgs args) {
                ActualizarTuplasArticulos();
                ActualizarTotal();
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
            contenedorVistas.Resize += delegate {
                AlturaContenedorTuplasModificada?.Invoke(this, EventArgs.Empty);
            };
        }

        public void CargarRazonesSocialesClientes(string[] nombresClientes) {
            fieldNombreCliente.Items.Add("Ninguno");
            fieldNombreCliente.Items.AddRange(nombresClientes);
            fieldNombreCliente.SelectedIndex = 0;
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

        private void AdicionarArticulo() {
            var idArticulo = UtilesArticulo.ObtenerIdArticulo(NombreArticulo);
            var precioUnitarioArticulo = UtilesArticulo.ObtenerPrecioUnitarioArticulo(idArticulo);
            var tuplaArticulo = new string[] {
                    idArticulo.ToString(),
                    NombreArticulo,
                    precioUnitarioArticulo.ToString("0.00", CultureInfo.CurrentCulture),
                    Cantidad.ToString()
                };

            Articulos.Add(tuplaArticulo);
            NombreArticulo = string.Empty;
            Cantidad = 0;

            ActualizarTuplasArticulos();
            ActualizarTotal();

            fieldNombreArticulo.Focus();
        }

        private void ActualizarTuplasArticulos() {
            foreach (var tupla in contenedorVistas.Controls) {
                if (tupla is IVistaTuplaDetalleVentaArticulo vistaTupla) {
                    vistaTupla.Cerrar();
                }
            }
            contenedorVistas.Controls.Clear();

            // Restablecer útima coordenada Y de la tupla
            VariablesGlobales.CoordenadaYUltimaTupla = 0;

            foreach (var articulo in Articulos) {
                var tuplaDetallesVentaArticulo = new VistaTuplaDetalleVentaArticulo();

                tuplaDetallesVentaArticulo.Id = articulo[0];
                tuplaDetallesVentaArticulo.NombreArticulo = articulo[1];
                tuplaDetallesVentaArticulo.Precio = articulo[2];
                tuplaDetallesVentaArticulo.Cantidad = articulo[3];
                tuplaDetallesVentaArticulo.EliminarDatosTupla += delegate (object? sender, EventArgs args) {
                    Articulos.Remove(articulo);                    
                    ArticuloEliminado?.Invoke(articulo, args);                    
                };

                // Registro y muestra
                Vistas.Registrar(
                    $"vistaTupla{tuplaDetallesVentaArticulo.GetType().Name}{tuplaDetallesVentaArticulo.Id}",
                    tuplaDetallesVentaArticulo,
                    new Point(0, VariablesGlobales.CoordenadaYUltimaTupla),
                    new Size(contenedorVistas.Width - 20, 42), "N");
                tuplaDetallesVentaArticulo.Mostrar();

                // Incremento de la útima coordenada Y de la tupla
                VariablesGlobales.CoordenadaYUltimaTupla += VariablesGlobales.AlturaTuplaPredeterminada;
            }
        }

        private void ActualizarTotal() {
            Total = 0f;
            
            foreach (var articulo in Articulos) {
                var cantidad = int.TryParse(articulo[3], out var cantArticulos) ? cantArticulos : 0;
                
                Total += (float.TryParse(articulo[2], NumberStyles.Float, CultureInfo.CurrentCulture, out var precioUnitario) ? precioUnitario * cantidad : 0);
            }

            btnEfectuarPago.Enabled = Total > 0f;
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
