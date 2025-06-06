using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto;

public partial class VistaRegistroProducto : Form, IVistaRegistroProducto {
    private bool _modoEdicion;
    private int _paginaActual = 1;

    private VistaRegistroProductoP1 P1DatosGenerales = new VistaRegistroProductoP1();
    private VistaRegistroProductoP2 P2UmPreciosStock = new VistaRegistroProductoP2();

    public VistaRegistroProducto() {
        InitializeComponent();
        InicializarVistas();
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

    public CategoriaProducto CategoriaProducto {
        get => P1DatosGenerales.CategoriaProducto;
        set => P1DatosGenerales.CategoriaProducto = value;
    }

    public string Nombre {
        get => P1DatosGenerales.Nombre;
        set => P1DatosGenerales.Nombre = value;
    }

    public string Codigo {
        get => P1DatosGenerales.Codigo;
        set => P1DatosGenerales.Codigo = value;
    }

    public string Descripcion {
        get => P1DatosGenerales.Descripcion;
        set => P1DatosGenerales.Descripcion = value;
    }

    public string RazonSocialProveedor {
        get => P1DatosGenerales.RazonSocialProveedor;
        set => P1DatosGenerales.RazonSocialProveedor = value;
    }

    public bool EsVendible {
        get => P1DatosGenerales.EsVendible;
        set => P1DatosGenerales.EsVendible = value;
    }

    public string UnidadMedida {
        get => P2UmPreciosStock.UnidadMedida;
        set => P2UmPreciosStock.UnidadMedida = value;
    }

    public decimal PrecioCompraBase {
        get => P2UmPreciosStock.PrecioCompraBase;
        set => P2UmPreciosStock.PrecioCompraBase = value;
    }

    public decimal PrecioVentaBase {
        get => P2UmPreciosStock.PrecioVentaBase;
        set => P2UmPreciosStock.PrecioVentaBase = value;
    }

    public string? NombreAlmacen {
        get => P2UmPreciosStock.NombreAlmacen;
        set => P2UmPreciosStock.NombreAlmacen = value;
    }

    public float StockInicial {
        get => P2UmPreciosStock.StockInicial;
        set => P2UmPreciosStock.StockInicial = value;
    }

    public bool ModoEdicionDatos {
        get => _modoEdicion;
        set {
            fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
            btnRegistrar.Text = value ? "Actualizar producto" : "Registrar producto";
            _modoEdicion = value;

            // Actualizar modo en páginas
            P2UmPreciosStock.ModoEdicionDatos = value;
        }
    }

    public event EventHandler? RegistrarUnidadMedida;
    public event EventHandler? RegistrarTipoProducto;
    public event EventHandler? RegistrarDisenoProducto;
    public event EventHandler? RegistrarDatos;
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarUnidadMedida;
    public event EventHandler? EliminarTipoProducto;
    public event EventHandler? EliminarDisenoProducto;
    public event EventHandler? EliminarDatos;
    public event EventHandler? Salir;

    private void InicializarVistas() {
        // 1. Datos generales del producto
        P1DatosGenerales.Dock = DockStyle.Fill;
        P1DatosGenerales.TopLevel = false;
        // 3. Unidad de medida, precios de compra y venta, stock inicial
        P2UmPreciosStock.Dock = DockStyle.Fill;
        P2UmPreciosStock.TopLevel = false;

        contenedorVistas.Controls.Clear();
        contenedorVistas.Controls.Add(P1DatosGenerales);
        contenedorVistas.Controls.Add(P2UmPreciosStock);

        // Mostrar vista de datos generales
        P1DatosGenerales.Show();
        P1DatosGenerales.BringToFront();
    }

    public void Inicializar() {
        // Eventos
        btnCerrar.Click += delegate (object? sender, EventArgs args) {
            Salir?.Invoke(sender, args);
        };
        P1DatosGenerales.CategoriaProductoCambiada += delegate (object? sender, EventArgs args) {
            ActualizarVisibilidadCamposPrecios();
        };
        P1DatosGenerales.EsVendibleActualizado += delegate (object? sender, EventArgs args) {
            ActualizarVisibilidadCamposPrecios();
        };
        P2UmPreciosStock.RegistrarUnidadMedida += delegate (object? sender, EventArgs args) {
            RegistrarUnidadMedida?.Invoke(sender, args);
        };
        P2UmPreciosStock.EliminarUnidadMedida += delegate (object? sender, EventArgs args) {
            EliminarUnidadMedida?.Invoke(sender, args);
        };
        btnAnterior.Click += delegate (object? sender, EventArgs args) {
            if (_paginaActual > 1)
                RetrocederPagina();
        };
        btnRegistrar.Click += delegate (object? sender, EventArgs args) {
            if (ModoEdicionDatos)
                EditarDatos?.Invoke(sender, args);
            else
                RegistrarDatos?.Invoke(sender, args);
        };
        btnSiguiente.Click += delegate (object? sender, EventArgs args) {
            if (_paginaActual < 2)
                AvanzarPagina();
        };
        btnSalir.Click += delegate (object? sender, EventArgs args) {
            Salir?.Invoke(sender, args);
        };

        // Enlace de scanner
        UtilesServidorScanner.Servidor.DatosRecibidos += ProcesarDatosScanner;

        // Navegación
        ConfigurarParametrosBotonesNavegacion(false, true);
    }

    private void ActualizarVisibilidadCamposPrecios() {
        bool mostrarCompra = P1DatosGenerales.CategoriaProducto == CategoriaProducto.MateriaPrima ||
                             P1DatosGenerales.CategoriaProducto == CategoriaProducto.Mercancia;
        bool mostrarVenta = P1DatosGenerales.CategoriaProducto == CategoriaProducto.Mercancia ||
                            P1DatosGenerales.CategoriaProducto == CategoriaProducto.ProductoTerminado ||
                            P1DatosGenerales.CategoriaProducto == CategoriaProducto.MateriaPrima && P1DatosGenerales.EsVendible;

        // Limpiar los precios de compraventa segun visibilidad
        if (!mostrarCompra)
            P2UmPreciosStock.PrecioCompraBase = 0;
        if (!mostrarVenta)
            P2UmPreciosStock.PrecioVentaBase = 0;

        P2UmPreciosStock.ConfigurarVisibilidadCamposPrecios(mostrarCompra, mostrarVenta);
    }

    public void CargarRazonesSocialesProveedores(object[] nombresProveedores) {
        P1DatosGenerales.CargarRazonesSocialesProveedores(nombresProveedores);
    }

    public void CargarUnidadesMedida(object[] unidadesMedida) {
        P2UmPreciosStock.CargarUnidadesMedida(unidadesMedida);
    }

    public void CargarDescripcionesUnidadesMedida(string[] descripcionesUnidadesMedida) {
        P2UmPreciosStock.CargarDescripcionesUnidadesMedida(descripcionesUnidadesMedida);
    }

    public void CargarNombresAlmacenes(object[] almacenes) {
        P2UmPreciosStock.CargarNombresAlmacenes(almacenes);
    }

    private void ProcesarDatosScanner(string codigo) {
        if (string.IsNullOrEmpty(codigo))
            return;

        Invoke((MethodInvoker) delegate {
            Codigo = codigo.Replace("\0", "");
        });
    }

    private void AvanzarPagina() {
        // Mapeo de navegación: página actual -> siguiente página
        var navegacion = new Dictionary<int, Action> {
            [1] = () => MostrarOcultarFormularios(P2UmPreciosStock, [P1DatosGenerales])
        };

        if (navegacion.TryGetValue(_paginaActual, out var action)) {
            action.Invoke();
            _paginaActual++;
        }

        ActualizarBotones();
    }

    private void RetrocederPagina() {
        // Mapeo de navegación: página actual -> página anterior
        var navegacion = new Dictionary<int, Action> {
            [2] = () => MostrarOcultarFormularios(P1DatosGenerales, [P2UmPreciosStock])
        };

        if (navegacion.TryGetValue(_paginaActual, out var action)) {
            action.Invoke();
            _paginaActual--;
        }

        ActualizarBotones();
    }

    private void ActualizarBotones() {
        var mostrarBotonAnterior = _paginaActual > 1;
        var mostrarBotonSiguiente = _paginaActual < 2;

        ConfigurarParametrosBotonesNavegacion(mostrarBotonAnterior, mostrarBotonSiguiente);
    }

    private void MostrarOcultarFormularios(Form formularioMostrar, Form[] formulariosOcultar) {
        foreach (var form in formulariosOcultar)
            form.Hide();

        formularioMostrar.Show();
        formularioMostrar.BringToFront();
    }

    public void ConfigurarParametrosBotonesNavegacion(bool mostrarAnterior, bool mostrarSiguiente) {
        // Ajustar visibilidad y ancho de columna para botón anterior
        btnAnterior.Visible = mostrarAnterior;        
        layoutNavegacion.ColumnStyles[0].Width = mostrarAnterior ? 50F : 0F;

        // Ajustar visibilidad y ancho de columna para botón siguiente
        btnSiguiente.Visible = mostrarSiguiente;
        layoutNavegacion.ColumnStyles[2].Width = mostrarSiguiente ? 50F : 0F;

        // Ajustar bordes del botón registrar
        btnRegistrar.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges(
            !mostrarAnterior, 
            !mostrarSiguiente, 
            !mostrarAnterior, 
            !mostrarSiguiente
        );

        // Forzar el redibujado del layout
        layoutBotones.PerformLayout();
    }

    public void Mostrar() {
        BringToFront();
        ShowDialog();
    }

    public void Restaurar() {
        P1DatosGenerales.Restaurar();
        P2UmPreciosStock.Restaurar();

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