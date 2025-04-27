using System.Globalization;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra.Plantillas;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaArticulo;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaArticulo.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra; 

public partial class VistaRegistroCompra : Form, IVistaRegistroCompra, IVistaGestionDetallesCompraventaArticulos {
    private bool _modoEdicion;

    public VistaRegistroCompra() {
        InitializeComponent();
        Inicializar();
    }

    public DateTime Fecha {
        get => DateTime.Now;
        set { }
    }

    public int AlturaContenedorVistas {
        get => contenedorVistas.Height;
    }

    public int TuplasMaximasContenedor {
        get => AlturaContenedorVistas / VariablesGlobales.AlturaTuplaPredeterminada;
    }

    public IRepositorioVista? Vistas { get; private set; }
    
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

    public List<string[]>? Articulos { get; private set; }

    public int Cantidad {
        get => int.TryParse(fieldCantidad.Text, out var cantidad) ? cantidad : 0;
        set {
            fieldCantidad.Text = value > 0 ? value.ToString() : string.Empty;
            fieldCantidad.Text = value > 0 ? value.ToString() : "0";
        }
    }

    public decimal Total {
        get => decimal.TryParse(fieldTotalCompra.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var total)
            ? total
            : 0;
        set => fieldTotalCompra.Text = value.ToString("N2", CultureInfo.InvariantCulture);
    }

    public event EventHandler? AlturaContenedorTuplasModificada;
    public event EventHandler? ArticuloAgregado;
    public event EventHandler? ArticuloEliminado;
    public event EventHandler? RegistrarDatos;
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarDatos;
    public event EventHandler? Salir;

    public void Inicializar() {
        Articulos = new List<string[]>();
        Vistas = new RepositorioVistaBase(contenedorVistas);

        // Eventos
        btnCerrar.Click += delegate(object? sender, EventArgs args) {
            Salir?.Invoke("exit", args);
        };
        fieldNombreAlmacen.SelectedIndexChanged += async delegate {
            var idAlmacen = UtilesAlmacen.ObtenerIdAlmacen(NombreAlmacen).Result;

            CargarNombresArticulos(await UtilesArticulo.ObtenerNombresArticulos(idAlmacen));

            fieldNombreArticulo.Focus();
        };
        fieldCantidad.TextChanged += delegate {
            btnAdicionarArticulo.Enabled = Cantidad > 0;
        };
        fieldNombreArticulo.KeyDown += delegate (object? sender, KeyEventArgs args) {
            if (args.KeyCode != Keys.Enter)
                return;

            fieldCantidad.Focus();

            args.SuppressKeyPress = true;
        };
        fieldCantidad.KeyDown += delegate(object? sender, KeyEventArgs args) {
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
        btnRegistrar.Click += delegate(object? sender, EventArgs args) {
            if (ModoEdicionDatos)
                EditarDatos?.Invoke(sender, args);
            else
                RegistrarDatos?.Invoke(sender, args);
        };
        btnSalir.Click += delegate(object? sender, EventArgs args) {
            Salir?.Invoke("exit", args);
        };
        contenedorVistas.Resize += delegate {
            AlturaContenedorTuplasModificada?.Invoke(this, EventArgs.Empty);
        };

        // Enlace de scanner
        UtilesServidorScanner.Servidor.DatosRecibidos += ProcesarDatosScanner;
    }

    public void CargarRazonesSocialesProveedores(object[] nombresProveedores) {
        fieldNombreProveedor.Items.Clear();
        fieldNombreProveedor.Items.Add("Anónimo");
        fieldNombreProveedor.Items.AddRange(nombresProveedores);
        fieldNombreProveedor.SelectedIndex = 0;
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

            fieldCantidad.Focus();
        });
    }

    public async void AdicionarArticulo(string nombreAlmacen = "", string nombreArticulo = "", string cantidad = "") {
        var adNombreAlmacen = string.IsNullOrEmpty(nombreAlmacen) ? NombreAlmacen : nombreAlmacen;
        var idAlmacen = await UtilesAlmacen.ObtenerIdAlmacen(adNombreAlmacen);
        var adNombreArticulo = string.IsNullOrEmpty(nombreArticulo) ? NombreArticulo : nombreArticulo;
        var idArticulo = await UtilesArticulo.ObtenerIdArticulo(adNombreArticulo);
        var adCantidad = string.IsNullOrEmpty(cantidad) ? Cantidad.ToString() : cantidad;

        if (!ModoEdicionDatos) {
            // Verificar ID del artículo
            if (idArticulo == 0) {
                NombreArticulo = string.Empty;

                fieldCantidad.Text = string.Empty;
                fieldNombreArticulo.Focus();

                return;
            }
        } else {
            fieldNombreArticulo.ReadOnly = true;
            fieldCantidad.ReadOnly = true;
        }

        var precioCompraBaseArticulo = await UtilesArticulo.ObtenerPrecioCompraBase(idArticulo);
        var tuplaArticulo = new[] {
            idArticulo.ToString(),
            adNombreArticulo,
            precioCompraBaseArticulo.ToString("N2", CultureInfo.InvariantCulture),
            adCantidad,
            idAlmacen.ToString()
        };

        // Verificar que el articulo ya se encuentre registrado
        if (Articulos != null) {
            var indiceArticulo =
                Articulos.FindIndex(a => a[0].Equals(idArticulo.ToString()) && a[4].Equals(idAlmacen.ToString()));
            if (indiceArticulo != -1) {
                Articulos[indiceArticulo][3] =
                    (int.Parse(Articulos[indiceArticulo][3]) + int.Parse(adCantidad)).ToString();
            } else {
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
        foreach (var tupla in contenedorVistas.Controls)
            if (tupla is IVistaTuplaDetalleCompraventaArticulo vistaTupla)
                vistaTupla.Cerrar();
        contenedorVistas.Controls.Clear();

        // Restablecer útima coordenada Y de la tupla
        VariablesGlobales.CoordenadaYUltimaTupla = 0;

        for (var i = 0; i < Articulos?.Count; i++) {
            var articulo = Articulos[i];
            var tuplaDetallesVentaArticulo = new VistaTuplaDetalleCompraventaArticulo();

            tuplaDetallesVentaArticulo.IdArticulo = articulo[0];
            tuplaDetallesVentaArticulo.NombreArticulo = articulo[1];
            tuplaDetallesVentaArticulo.PrecioCompraventaFinal = articulo[2];
            tuplaDetallesVentaArticulo.Cantidad = articulo[3];
            tuplaDetallesVentaArticulo.Habilitada = !ModoEdicionDatos;
            tuplaDetallesVentaArticulo.PrecioCompraventaModificado += delegate (object? sender, EventArgs args) {
                if (sender is not IVistaTuplaDetalleCompraventaArticulo vista)
                    return;

                var indiceArticulo = Articulos.FindIndex(a => a[0].Equals(vista.IdArticulo));

                if (indiceArticulo == -1)
                    return;

                Articulos[indiceArticulo][2] = vista.PrecioCompraventaFinal; // Actualizar precio de compra

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

        if (Articulos == null)
            return;

        foreach (var articulo in Articulos) {
            var cantidad = int.TryParse(articulo[3], out var cantArticulos) ? cantArticulos : 0;

            Total += decimal.TryParse(articulo[2], NumberStyles.Any, CultureInfo.InvariantCulture,
                out var precioCompraTotal)
                ? precioCompraTotal * cantidad
                : 0;
        }
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
        UtilesServidorScanner.Servidor.DatosRecibidos -= ProcesarDatosScanner;

        Dispose();
    }
}