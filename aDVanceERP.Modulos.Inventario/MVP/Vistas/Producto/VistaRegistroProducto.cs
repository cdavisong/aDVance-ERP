using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto;
//TODO: Seguir implementando el registro de productos con las diferentes vistas y funcionalidades
public partial class VistaRegistroProducto : Form, IVistaRegistroProducto {
    private bool _modoEdicion;
    private int _paginaActual = 1;

    private VistaRegistroProductoP1 P1DatosGenerales = new VistaRegistroProductoP1();
    private VistaRegistroProductoP2 P2Detalles = new VistaRegistroProductoP2();
    private VistaRegistroProductoP3 P3PrecioCompraventa = new VistaRegistroProductoP3();

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
        get => P2Detalles.UnidadMedida;
        set => P2Detalles.UnidadMedida = value;
    }

    public string? ColorPrimario {
        get => P2Detalles.ColorPrimario;
        set => P2Detalles.ColorPrimario = value;
    }

    public string? ColorSecundario {
        get => P2Detalles.ColorSecundario;
        set => P2Detalles.ColorSecundario = value;
    }

    public string? Tipo {
        get => P2Detalles.Tipo;
        set => P2Detalles.Tipo = value;
    }

    public string? Diseno {
        get => P2Detalles.Diseno;
        set => P2Detalles.Diseno = value;
    }

    public decimal PrecioCompraBase {
        get => P3PrecioCompraventa.PrecioCompraBase;
        set => P3PrecioCompraventa.PrecioCompraBase = value;
    }

    public decimal PrecioVentaBase {
        get => P3PrecioCompraventa.PrecioVentaBase;
        set => P3PrecioCompraventa.PrecioVentaBase = value;
    }

    public string? NombreAlmacen {
        get => P3PrecioCompraventa.NombreAlmacen;
        set => P3PrecioCompraventa.NombreAlmacen = value;
    }

    public int StockInicial {
        get => P3PrecioCompraventa.StockInicial;
        set => P3PrecioCompraventa.StockInicial = value;
    }

    public bool ModoEdicionDatos {
        get => _modoEdicion;
        set {
            fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
            btnRegistrar.Text = value ? "Actualizar producto" : "Registrar producto";
            _modoEdicion = value;

            // Actualizar modo en páginas
            P3PrecioCompraventa.ModoEdicionDatos = value;
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
        // 2. Detalles del producto
        P2Detalles.Dock = DockStyle.Fill;
        P2Detalles.TopLevel = false;
        // 3. Precio de compra y venta
        P3PrecioCompraventa.Dock = DockStyle.Fill;
        P3PrecioCompraventa.TopLevel = false;

        contenedorVistas.Controls.Clear();
        contenedorVistas.Controls.Add(P1DatosGenerales);
        contenedorVistas.Controls.Add(P2Detalles);
        contenedorVistas.Controls.Add(P3PrecioCompraventa);

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
        P2Detalles.RegistrarUnidadMedida += delegate (object? sender, EventArgs args) {
            RegistrarUnidadMedida?.Invoke(sender, args);
        };
        P2Detalles.RegistrarTipoProducto += delegate (object? sender, EventArgs args) {
            RegistrarTipoProducto?.Invoke(sender, args);
        };
        P2Detalles.RegistrarDisenoProducto += delegate (object? sender, EventArgs args) {
            RegistrarDisenoProducto?.Invoke(sender, args);
        };
        P2Detalles.EliminarUnidadMedida += delegate (object? sender, EventArgs args) {
            EliminarUnidadMedida?.Invoke(sender, args);
        };
        P2Detalles.EliminarTipoProducto += delegate (object? sender, EventArgs args) {
            EliminarTipoProducto?.Invoke(sender, args);
        };
        P2Detalles.EliminarDisenoProducto += delegate (object? sender, EventArgs args) {
            EliminarDisenoProducto?.Invoke(sender, args);
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
            if (_paginaActual < 3)
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

        P3PrecioCompraventa.ConfigurarVisibilidadCamposPrecios(mostrarCompra, mostrarVenta);
    }

    public void CargarRazonesSocialesProveedores(object[] nombresProveedores) {
        P1DatosGenerales.CargarRazonesSocialesProveedores(nombresProveedores);
    }

    public void CargarDescripcionesUnidadesMedida(string[] descripcionesUnidadesMedida) {
        P2Detalles.CargarDescripcionesUnidadesMedida(descripcionesUnidadesMedida);
    }

    public void CargarColores(string[] colores) {
        P2Detalles.CargarColores(colores);
    }

    public void CargarUnidadesMedida(object[] unidadesMedida) {
        P2Detalles.CargarUnidadesMedida(unidadesMedida);
    }   

    public void CargarTiposProductos(object[] tiposProducto) {
        P2Detalles.CargarTiposProducto(tiposProducto);
    }

    public void CargarDisenosProducto(object[] disenosProducto) {
        P2Detalles.CargarDisenosProducto(disenosProducto);
    }

    public void CargarNombresAlmacenes(object[] almacenes) {
        P3PrecioCompraventa.CargarNombresAlmacenes(almacenes);
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
            [1] = () => MostrarOcultarFormularios(P2Detalles, [P1DatosGenerales]),
            [2] = () => MostrarOcultarFormularios(P3PrecioCompraventa, [P2Detalles])
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
            [3] = () => MostrarOcultarFormularios(P2Detalles, [P3PrecioCompraventa]),
            [2] = () => MostrarOcultarFormularios(P1DatosGenerales, [P2Detalles])
        };

        if (navegacion.TryGetValue(_paginaActual, out var action)) {
            action.Invoke();
            _paginaActual--;
        }

        ActualizarBotones();
    }

    private void ActualizarBotones() {
        var mostrarBotonAnterior = _paginaActual > 1;
        var mostrarBotonSiguiente = _paginaActual < 3;

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
        P2Detalles.Restaurar();
        P3PrecioCompraventa.Restaurar();

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