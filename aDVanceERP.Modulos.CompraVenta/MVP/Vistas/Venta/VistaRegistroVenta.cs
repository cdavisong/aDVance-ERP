using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta.Plantillas;

using System.Globalization;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaArticulo.Plantillas;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaArticulo;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta {
    public partial class VistaRegistroVenta : Form, IVistaRegistroVenta, IVistaGestionDetallesCompraventaArticulos {
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
                btnRegistrar.Text = value ? "Actualizar venta" : "Registrar venta";
                _modoEdicion = value;
            }
        }

        public string? RazonSocialCliente {
            get => fieldNombreCliente.Text;
            set => fieldNombreCliente.Text = value;
        }

        public string? NombreAlmacen {
            get => fieldNombreAlmacen.Text;
            set => fieldNombreAlmacen.Text = value;
        }

        public string? NombreArticulo {
            get => fieldNombreArticulo.Text;
            set => fieldNombreArticulo.Text = value;
        }

        public List<string[]>? Articulos { get; private set; }

        public int Cantidad {
            get => int.TryParse(fieldCantidad.Text, out var cantidad) ? cantidad : 0;
            set => fieldCantidad.Text = value > 0 ? value.ToString() : string.Empty;
        }

        public decimal Total {
            get => decimal.TryParse(fieldTotalVenta.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var total) ? total : 0;
            set => fieldTotalVenta.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public long IdTipoEntrega { get; set; } = 0;

        public string Direccion { get; set; } = string.Empty;

        public bool PagoConfirmado {
            get => btnRegistrar.Enabled;
            set {
                if (!ModoEdicionDatos) {
                    fieldNombreArticulo.ReadOnly = value;
                    fieldCantidad.ReadOnly = value;
                    btnEfectuarPago.Enabled = !value;
                    btnRegistrar.Enabled = value;
                }
            }
        }

        public string EstadoEntrega { get; set; }

        public int AlturaContenedorVistas {
            get => contenedorVistas.Height;
        }

        public int TuplasMaximasContenedor {
            get => AlturaContenedorVistas / VariablesGlobales.AlturaTuplaPredeterminada;
        }

        public IRepositorioVista? Vistas { get; private set; }

        public event EventHandler? ArticuloAgregado;
        public event EventHandler? ArticuloEliminado;
        public event EventHandler? EfectuarPago;
        public event EventHandler? AsignarMensajeria;
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
            fieldNombreAlmacen.SelectedIndexChanged += async delegate {
                var idAlmacen = UtilesAlmacen.ObtenerIdAlmacen(NombreAlmacen).Result;

                CargarNombresArticulos(await UtilesArticulo.ObtenerNombresArticulos(idAlmacen));
            };
            fieldCantidad.TextChanged += delegate {
                btnAdicionarArticulo.Enabled = Cantidad > 0;
            };
            fieldCantidad.KeyDown += delegate (object? sender, KeyEventArgs args) {
                if (args.KeyCode != Keys.Enter) 
                    return;

                AdicionarArticulo();

                args.SuppressKeyPress = true;
            };
            btnAdicionarArticulo.Click += delegate {
                AdicionarArticulo();
            };
            ArticuloEliminado += delegate {
                ActualizarTuplasArticulos();
                ActualizarTotal();
            };
            btnEfectuarPago.Click += delegate (object? sender, EventArgs args) {
                EfectuarPago?.Invoke(sender, args);
            };
            btnAsignarMensajería.Click += delegate (object? sender, EventArgs args) {
                AsignarMensajeria?.Invoke(sender, args);
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

        public void CargarRazonesSocialesClientes(object[] nombresClientes) {
            fieldNombreCliente.Items.Clear();
            fieldNombreCliente.Items.Add("Anónimo");
            fieldNombreCliente.Items.AddRange(nombresClientes);
            fieldNombreCliente.SelectedIndex = 0;
        }

        public void CargarNombresAlmacenes(object[] nombresAlmacenes) {
            fieldNombreAlmacen.Items.Clear();
            fieldNombreAlmacen.Items.AddRange(nombresAlmacenes);
            fieldNombreAlmacen.SelectedIndex = 0;
        }

        public void CargarNombresArticulos(string[] nombresArticulos) {
            fieldNombreArticulo.AutoCompleteCustomSource.Clear();
            fieldNombreArticulo.AutoCompleteCustomSource.AddRange(nombresArticulos);
            fieldNombreArticulo.AutoCompleteMode = AutoCompleteMode.Suggest;
            fieldNombreArticulo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public async void AdicionarArticulo(string nombreAlmacen = "", string nombreArticulo = "", string cantidad = "") {
            var adNombreAlmacen = string.IsNullOrEmpty(nombreAlmacen) ? NombreAlmacen : nombreAlmacen;
            var idAlmacen = await UtilesAlmacen.ObtenerIdAlmacen(adNombreAlmacen);
            var adNombreArticulo = string.IsNullOrEmpty(nombreArticulo) ? NombreArticulo : nombreArticulo;
            var idArticulo = await UtilesArticulo.ObtenerIdArticulo(adNombreArticulo);
            var adCantidad = string.IsNullOrEmpty(cantidad) ? Cantidad.ToString() : cantidad;
            var stockArticulo = await UtilesArticulo.ObtenerStockArticulo(adNombreArticulo, adNombreAlmacen);

            if (!ModoEdicionDatos) {
                // Verificar ID y stock del artículo
                if (idArticulo == 0 || stockArticulo == 0) {
                    NombreArticulo = string.Empty;

                    fieldCantidad.Text = string.Empty;
                    fieldNombreArticulo.Focus();

                    return;
                }

                // Verificar que la cantidad no exceda el stock del artículo
                if (Articulos != null) {
                    var stockComprometido = Articulos.Where(a => a[0].Equals(idArticulo.ToString()) && a[5].Equals(idAlmacen.ToString())).Sum(a => int.Parse(a[4]));
                    if (int.Parse(adCantidad) + stockComprometido > stockArticulo) {
                        fieldCantidad.ForeColor = Color.Firebrick;
                        fieldCantidad.Font = new Font(fieldCantidad.Font, FontStyle.Bold);
                        fieldCantidad.Margin = new Padding(3);
                        return;
                    } else {
                        fieldCantidad.ForeColor = Color.Black;
                        fieldCantidad.Font = new Font(fieldCantidad.Font, FontStyle.Regular);
                        fieldCantidad.Margin = new Padding(3);
                    }
                }
            } else {
                fieldNombreArticulo.ReadOnly = true;
                fieldCantidad.ReadOnly = true;
            }

            var precioCompraVigenteArticulo = await UtilesArticulo.ObtenerPrecioCompraBase(idArticulo);
            var precioVentaBaseArticulo = await UtilesArticulo.ObtenerPrecioVentaBase(idArticulo);
            var tuplaArticulo = new string[] {
                    idArticulo.ToString(),
                    adNombreArticulo,
                    precioCompraVigenteArticulo.ToString("N2", CultureInfo.InvariantCulture),
                    precioVentaBaseArticulo.ToString("N2", CultureInfo.InvariantCulture),
                    adCantidad,
                    idAlmacen.ToString()
                };

            // Verificar que el articulo ya se encuentre registrado
            if (Articulos != null) {
                var indiceArticulo = Articulos.FindIndex(a => a[0].Equals(idArticulo.ToString()) && a[5].Equals(idAlmacen.ToString()));
                if (indiceArticulo != -1)
                    Articulos[indiceArticulo][4] = (int.Parse(Articulos[indiceArticulo][4]) + int.Parse(adCantidad)).ToString();
                else {
                    Articulos.Add(tuplaArticulo);
                    ArticuloAgregado?.Invoke(tuplaArticulo, EventArgs.Empty);
                }
            }

            NombreArticulo = string.Empty;
            Cantidad = 0;

            ActualizarTuplasArticulos();
            ActualizarTotal();

            fieldNombreArticulo.Focus();
        }

        private void ActualizarTuplasArticulos() {
            foreach (var tupla in contenedorVistas.Controls) {
                if (tupla is IVistaTuplaDetalleCompraventaArticulo vistaTupla) {
                    vistaTupla.Cerrar();
                }
            }
            contenedorVistas.Controls.Clear();

            // Restablecer útima coordenada Y de la tupla
            VariablesGlobales.CoordenadaYUltimaTupla = 0;

            for (var i = 0; i < Articulos?.Count; i++) {
                var articulo = Articulos[i];
                var tuplaDetallesVentaArticulo = new VistaTuplaDetalleCompraventaArticulo();

                tuplaDetallesVentaArticulo.IdArticulo = articulo[0];
                tuplaDetallesVentaArticulo.NombreArticulo = articulo[1];
                tuplaDetallesVentaArticulo.Precio = articulo[3];
                tuplaDetallesVentaArticulo.Cantidad = articulo[4];
                tuplaDetallesVentaArticulo.Habilitada = !ModoEdicionDatos;
                tuplaDetallesVentaArticulo.MontoModificado += delegate (object? sender, EventArgs args) {
                    if (sender is not IVistaTuplaDetalleCompraventaArticulo vista) 
                        return;

                    var indiceArticulo = Articulos.FindIndex(a => a[0].Equals(vista.IdArticulo));
                    
                    if (indiceArticulo == -1)
                        return;
                    
                    Articulos[indiceArticulo][3] = vista.Precio; // Actualizar precio de venta del artículo

                    ActualizarTotal();
                };
                tuplaDetallesVentaArticulo.EliminarDatosTupla += delegate (object? sender, EventArgs args) {
                    articulo = sender as string[];

                    Articulos.RemoveAt(Articulos.FindIndex(p => p[0].Equals(articulo?[0])));
                    ArticuloEliminado?.Invoke(articulo, args);
                };

                // Registro y muestra
                Vistas?.Registrar(
                    $"vistaTupla{tuplaDetallesVentaArticulo.GetType().Name}{i}",
                    tuplaDetallesVentaArticulo,
                    new Point(0, VariablesGlobales.CoordenadaYUltimaTupla),
                    new Size(contenedorVistas.Width - 20, VariablesGlobales.AlturaTuplaPredeterminada), "N");
                tuplaDetallesVentaArticulo.Mostrar();

                // Incremento de la útima coordenada Y de la tupla
                VariablesGlobales.CoordenadaYUltimaTupla += VariablesGlobales.AlturaTuplaPredeterminada;
            }
        }

        private void ActualizarTotal() {
            Total = 0;

            if (Articulos != null)
                foreach (var articulo in Articulos) {
                    var cantidad = int.TryParse(articulo[4], out var cantArticulos) ? cantArticulos : 0;

                    Total += (decimal.TryParse(articulo[3], NumberStyles.Any, CultureInfo.InvariantCulture, out var precioVentaTotal) ? precioVentaTotal * cantidad : 0);
                }

            btnEfectuarPago.Enabled = Total > 0;
            btnAsignarMensajería.Enabled = Total > 0;
        }

        public void Mostrar() {
            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            Fecha = DateTime.Now;
            RazonSocialCliente = string.Empty;
            fieldNombreCliente.SelectedIndex = 0;
            NombreAlmacen = string.Empty;
            fieldNombreAlmacen.SelectedIndex = 0;
            NombreArticulo = string.Empty;
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
