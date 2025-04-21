using System.Globalization;

using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaArticulo.Plantillas;

using aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta.Plantillas;

namespace aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta {
    public partial class VistaTerminalVenta : Form, IVistaTerminalVenta, IVistaGestionDetallesCompraventaArticulos {
        private int _cantidad = 0;

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
            get => _cantidad;
            set {
                _cantidad = value;

                btnCantidadArticulo.Text = $@"Cantidad ({_cantidad})";
            }
        }

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

        public bool PagoConfirmado { get; set; }

        #region Mensajería

        public long IdTipoEntrega { get; set; } = 0;

        public string? RazonSocialCliente { get; set; }

        public string? Direccion { get; set; }

        public string? EstadoEntrega { get; set; } = "Completada";

        #endregion

        public int AlturaContenedorVistas {
            get => contenedorVistas.Height;
        }

        public int TuplasMaximasContenedor {
            get => AlturaContenedorVistas / VariablesGlobales.AlturaTuplaPredeterminada;
        }

        public IRepositorioVista? Vistas { get; private set; }

        public bool ModoEdicionDatos { get; set; }

        public event EventHandler? AlturaContenedorTuplasModificada;
        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? ArticuloAgregado;
        public event EventHandler? ArticuloEliminado;
        public event EventHandler? ModificarCantidadArticulos;
        public event EventHandler? EfectuarPago;
        public event EventHandler? AsignarMensajeria;
        public event EventHandler? Salir;

        public void Inicializar() {
            Articulos = new List<string[]>();
            Vistas = new RepositorioVistaBase(contenedorVistas);

            // Eventos
            fieldNombreAlmacen.SelectedIndexChanged += async delegate {
                var idAlmacen = UtilesAlmacen.ObtenerIdAlmacen(NombreAlmacen).Result;

                CargarNombresArticulos(await UtilesArticulo.ObtenerNombresArticulos(idAlmacen));
            };
            fieldNombreArticulo.KeyDown += delegate (object? sender, KeyEventArgs args) {
                switch (args.KeyCode) {
                    case Keys.Enter:
                        AdicionarArticulo();

                        args.SuppressKeyPress = true;
                        break;
                    case Keys.F3:
                        ModificarCantidadArticulos?.Invoke(sender, args);

                        args.SuppressKeyPress = true;
                        break;
                }

                fieldNombreArticulo.Focus();
            };
            btnAdicionarArticulo.Click += delegate {
                AdicionarArticulo();
            };
            ArticuloEliminado += delegate {
                ActualizarTuplasArticulos();
                ActualizarSubtotal();

                fieldNombreArticulo.Focus();
            };
            btnEliminarArticulos.Click += delegate (object? sender, EventArgs args) {
                EliminarArticulosVenta(sender, args);

                fieldNombreArticulo.Focus();
            };
            btnCantidadArticulo.Click += delegate (object? sender, EventArgs args) {
                ModificarCantidadArticulos?.Invoke(sender, args);

                fieldNombreArticulo.Focus();
            };
            btnGestionarPago.Click += delegate (object? sender, EventArgs args) {
                EfectuarPago?.Invoke(sender, args);
                RegistrarDatos?.Invoke(sender, args);

                EliminarArticulosVenta(sender, args);

                fieldNombreArticulo.Focus();
            };
            btnAsignarMensajeria.Click += delegate (object? sender, EventArgs args) {
                AsignarMensajeria?.Invoke(sender, args);
                RegistrarDatos?.Invoke(sender, args);

                EliminarArticulosVenta(sender, args);

                fieldNombreArticulo.Focus();
            };
            contenedorVistas.Resize += delegate {
                AlturaContenedorTuplasModificada?.Invoke(this, EventArgs.Empty);
            };

            // Enlace de scanner
            UtilesServidorScanner.Servidor.DatosRecibidos += ProcesarDatosScanner;
        }

        private void EliminarArticulosVenta(object? sender, EventArgs args) {
            Articulos?.Clear();
            ArticuloEliminado?.Invoke(sender, args);
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

        private void ProcesarDatosScanner(string codigo) {
            var nombreArticulo = UtilesArticulo.ObtenerNombreArticulo(codigo.Replace("\0", "")).Result;

            if (string.IsNullOrEmpty(nombreArticulo))
                return;

            Invoke((MethodInvoker) delegate {
                NombreArticulo = nombreArticulo;

                AdicionarArticulo();
            });
        }

        public async void AdicionarArticulo(string nombreAlmacen = "", string nombreArticulo = "", string cantidad = "") {
            var adNombreAlmacen = string.IsNullOrEmpty(nombreAlmacen) ? NombreAlmacen : nombreAlmacen;
            var idAlmacen = await UtilesAlmacen.ObtenerIdAlmacen(adNombreAlmacen);
            var adNombreArticulo = string.IsNullOrEmpty(nombreArticulo) ? NombreArticulo : nombreArticulo;

            if (adNombreArticulo != null) {
                var idArticulo = await UtilesArticulo.ObtenerIdArticulo(adNombreArticulo);
                var adCantidad = string.IsNullOrEmpty(cantidad) ? Cantidad.ToString() : cantidad;
                var stockArticulo = await UtilesArticulo.ObtenerStockArticulo(adNombreArticulo, adNombreAlmacen);

                // Verificar ID y stock del artículo
                if (idArticulo == 0 || stockArticulo == 0) {
                    CentroNotificaciones.Mostrar($"El artículo {adNombreArticulo} no existe o no tiene stock disponible en el almacén {adNombreAlmacen}. Rectifique los datos.", TipoNotificacion.Advertencia);

                    NombreArticulo = string.Empty;

                    fieldNombreArticulo.Focus();

                    return;
                }

                // Verificar que la cantidad no exceda el stock del artículo
                if (Articulos != null) {
                    var stockComprometido = Articulos
                        .Where(a => a[0].Equals(idArticulo.ToString()) && a[5].Equals(idAlmacen.ToString()))
                        .Sum(a => int.Parse(a[4]));
                    if (int.Parse(adCantidad) + stockComprometido > stockArticulo) {
                        btnCantidadArticulo.ForeColor = Color.Firebrick;
                        btnCantidadArticulo.Font = new Font(btnCantidadArticulo.Font, FontStyle.Bold);
                        btnCantidadArticulo.Margin = new Padding(3);

                        CentroNotificaciones.Mostrar($"La cantidad del artículo {adNombreArticulo} excede el stock disponible ({stockArticulo}). Rectifique los datos o aumente la cantidad disponible en almacén.", TipoNotificacion.Advertencia);
                        return;
                    }

                    btnCantidadArticulo.ForeColor = Color.Black;
                    btnCantidadArticulo.Font = new Font(btnCantidadArticulo.Font, FontStyle.Regular);
                    btnCantidadArticulo.Margin = new Padding(3);
                }

                var precioCompraVigenteArticulo = await UtilesArticulo.ObtenerPrecioCompraBase(idArticulo);
                var precioVentaBaseArticulo = await UtilesArticulo.ObtenerPrecioVentaBase(idArticulo);
                var tuplaArticulo = new[] {
                    idArticulo.ToString(),
                    adNombreArticulo,
                    precioCompraVigenteArticulo.ToString("N2", CultureInfo.InvariantCulture),
                    precioVentaBaseArticulo.ToString("N2", CultureInfo.InvariantCulture),
                    adCantidad,
                    idAlmacen.ToString()
                };

                // Verificar que el articulo ya se encuentre registrado
                if (Articulos != null) {
                    var indiceArticulo =
                        Articulos.FindIndex(a => a[0].Equals(idArticulo.ToString()) && a[5].Equals(idAlmacen.ToString()));
                    if (indiceArticulo != -1) {
                        Articulos[indiceArticulo][4] =
                            (int.Parse(Articulos[indiceArticulo][4]) + int.Parse(adCantidad)).ToString();
                    } else {
                        Articulos.Add(tuplaArticulo);
                        ArticuloAgregado?.Invoke(tuplaArticulo, EventArgs.Empty);
                    }
                }
            }

            NombreArticulo = string.Empty;
            Cantidad = 1;

            ActualizarTuplasArticulos();
            ActualizarSubtotal();

            fieldNombreArticulo.Focus();
        }

        private void ActualizarTuplasArticulos() {
            foreach (var tupla in contenedorVistas.Controls)
                if (tupla is IVistaTuplaDetalleCompraventaArticulo vistaTupla)
                    vistaTupla.Cerrar();
            contenedorVistas.Controls.Clear();

            // Restablecer útima coordenada Y de la tupla
            VariablesGlobales.CoordenadaYUltimaTupla = 0;

            for (var i = 0; i < Articulos?.Count; i++) {
                var articulo = Articulos[i];
                var tuplaDetallesVentaArticulo = new VistaTuplaVentaArticulo();
                var precioVentaFinal = decimal.TryParse(
                    articulo[3], NumberStyles.Any, CultureInfo.InvariantCulture,
                    out var pvf) ? pvf : 0;
                var cantidad = decimal.TryParse(
                    articulo[4],
                    NumberStyles.Any, CultureInfo.InvariantCulture,
                    out var c) ? c : 0;

                tuplaDetallesVentaArticulo.IdArticulo = articulo[0];
                tuplaDetallesVentaArticulo.NombreArticulo = articulo[1];
                tuplaDetallesVentaArticulo.PrecioVentaFinal = precioVentaFinal.ToString("N", CultureInfo.InvariantCulture);
                tuplaDetallesVentaArticulo.Cantidad = cantidad.ToString("N", CultureInfo.InvariantCulture);
                tuplaDetallesVentaArticulo.Subtotal = (precioVentaFinal * cantidad).ToString("N", CultureInfo.InvariantCulture);
                tuplaDetallesVentaArticulo.PrecioVentaModificado += delegate (object? sender, EventArgs args) {
                    if (sender is not IVistaTuplaVentaArticulo vista)
                        return;

                    var indiceArticulo = Articulos.FindIndex(a => a[0].Equals(vista.IdArticulo));

                    if (indiceArticulo == -1)
                        return;

                    Articulos[indiceArticulo][3] = vista.PrecioVentaFinal; // Actualizar precio de venta del artículo

                    ActualizarSubtotal();
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

        private void ActualizarSubtotal() {
            Subtotal = 0;

            if (Articulos != null)
                foreach (var articulo in Articulos) {
                    var cantidad = int.TryParse(articulo[4], out var cantArticulos) ? cantArticulos : 0;

                    Subtotal += decimal.TryParse(articulo[3], NumberStyles.Any, CultureInfo.InvariantCulture,
                        out var precioVentaTotal)
                        ? precioVentaTotal * cantidad
                        : 0;
                }

            btnGestionarPago.Enabled = Subtotal > 0;
            KeyPago.Visible = Subtotal > 0;
            btnAsignarMensajeria.Enabled = Subtotal > 0;

            ActualizarTotal();
        }

        private void ActualizarTotal() {
            Total = Subtotal - Descuento;
        }

        public void Mostrar() {
            Habilitada = true;
            BringToFront();
            Show();

            fieldNombreArticulo.Focus();
        }

        public void Restaurar() {
            Habilitada = true;
            Fecha = DateTime.Now;
            NombreAlmacen = string.Empty;
            fieldNombreAlmacen.SelectedIndex = 0;
            NombreArticulo = string.Empty;
            btnGestionarPago.Enabled = false;
            KeyPago.Visible = false;
            btnAsignarMensajeria.Enabled = false;
            Cantidad = 1;
            Subtotal = 0;
            Descuento = 0;
            Total = 0;
        }

        public void Ocultar() {
            Habilitada = false;
            Hide();
        }

        public void Cerrar() {
            UtilesServidorScanner.Servidor.DatosRecibidos -= ProcesarDatosScanner; // Mover a FormCLosing
        }
    }
}
