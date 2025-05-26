using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto;

public partial class VistaRegistroProducto : Form, IVistaRegistroProducto {
    private bool _modoEdicion;
    private int _paginaActual = 1;

    private VistaRegistroProductoP1 P1DatosGenerales = new VistaRegistroProductoP1();
    private VistaRegistroProductoP2 P2Detalles = new VistaRegistroProductoP2();
    private VistaRegistroProductoP3 P3MateriaPrima = new VistaRegistroProductoP3();
    private VistaRegistroProductoP4 P4Actividades = new VistaRegistroProductoP4();
    private VistaRegistroProductoP5 P5CostoProduccion = new VistaRegistroProductoP5();
    private VistaRegistroProductoP6 P6PrecioCompraventa = new VistaRegistroProductoP6();

    public VistaRegistroProducto() {
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

    public decimal PrecioCompraBase {
        get => P6PrecioCompraventa.PrecioCompraBase;
        set => P6PrecioCompraventa.PrecioCompraBase = value;
    }

    public decimal PrecioVentaBase {
        get => P6PrecioCompraventa.PrecioVentaBase;
        set => P6PrecioCompraventa.PrecioVentaBase = value;
    }

    public bool ModoEdicionDatos {
        get => _modoEdicion;
        set {
            fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
            _modoEdicion = value;
        }
    }

    public event EventHandler? RegistrarDatos;
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarDatos;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Inicializar vistas
        // 1. Datos generales del producto
        P1DatosGenerales.Dock = DockStyle.Fill;
        P1DatosGenerales.TopLevel = false;
        // 2. Detalles del producto
        P2Detalles.Dock = DockStyle.Fill;
        P2Detalles.TopLevel = false;
        // 3. Materia prima
        P3MateriaPrima.Dock = DockStyle.Fill;
        P3MateriaPrima.TopLevel = false;
        // 4. Actividades de producción
        P4Actividades.Dock = DockStyle.Fill;
        P4Actividades.TopLevel = false;
        // 5. Costo de producción
        P5CostoProduccion.Dock = DockStyle.Fill;
        P5CostoProduccion.TopLevel = false;
        // 6. Precio de compra y venta
        P6PrecioCompraventa.Dock = DockStyle.Fill;
        P6PrecioCompraventa.TopLevel = false;

        contenedorVistas.Controls.Clear();
        contenedorVistas.Controls.Add(P1DatosGenerales);
        contenedorVistas.Controls.Add(P2Detalles);
        contenedorVistas.Controls.Add(P3MateriaPrima);
        contenedorVistas.Controls.Add(P4Actividades);
        contenedorVistas.Controls.Add(P5CostoProduccion);
        contenedorVistas.Controls.Add(P6PrecioCompraventa);

        // Mostrar vista de datos generales
        P1DatosGenerales.Show();
        P1DatosGenerales.BringToFront();

        // Eventos
        btnCerrar.Click += delegate (object? sender, EventArgs args) { Salir?.Invoke(sender, args); };
        btnRegistrar.Click += delegate (object? sender, EventArgs args) {
            if (_paginaActual == 2 && P1DatosGenerales.CategoriaProducto != CategoriaProducto.ProductoTerminado) {
                _paginaActual = 6; // Salta a la página de precios de compraventa si no es un producto terminado
            } else _paginaActual++;

            if (_paginaActual == 2) {
                P1DatosGenerales.Hide();
                P2Detalles.Show();
                P2Detalles.BringToFront();
            } else if (_paginaActual == 3 && P1DatosGenerales.CategoriaProducto == CategoriaProducto.ProductoTerminado) {
                P2Detalles.Hide();
                P3MateriaPrima.Show();
                P3MateriaPrima.BringToFront();
            } else if (_paginaActual == 4 && P1DatosGenerales.CategoriaProducto == CategoriaProducto.ProductoTerminado) {
                P3MateriaPrima.Hide();
                P4Actividades.Show();
                P4Actividades.BringToFront();
            } else if (_paginaActual == 5 && P1DatosGenerales.CategoriaProducto == CategoriaProducto.ProductoTerminado) {
                P4Actividades.Hide();
                P5CostoProduccion.Show();
                P5CostoProduccion.BringToFront();
            } else if (_paginaActual == 6) {
                P5CostoProduccion.Hide();
                P6PrecioCompraventa.Show();
                P6PrecioCompraventa.BringToFront();
            } else if (_paginaActual == 7) {
                // Si es la última página, registrar datos
                if (ModoEdicionDatos)
                    EditarDatos?.Invoke(sender, args);
                else
                    RegistrarDatos?.Invoke(sender, args);
                return;
            }

            btnAtras.Visible = _paginaActual > 1;
            btnRegistrar.Text = _paginaActual == 6 ? "Registrar" : "Siguiente";
        };
        btnAtras.Click += delegate (object? sender, EventArgs args) {
            if (_paginaActual == 6 && P1DatosGenerales.CategoriaProducto != CategoriaProducto.ProductoTerminado) {
                _paginaActual = 2; // Salta a la página de detalles si no es un producto terminado
            } else _paginaActual--;

            if (_paginaActual == 1) {
                P2Detalles.Hide();
                P1DatosGenerales.Show();
                P1DatosGenerales.BringToFront();
            } else if (_paginaActual == 2) {
                P6PrecioCompraventa.Hide();
                P3MateriaPrima.Hide();                
                P2Detalles.Show();
                P2Detalles.BringToFront();
            } else if (_paginaActual == 3 && P1DatosGenerales.CategoriaProducto == CategoriaProducto.ProductoTerminado) {
                P4Actividades.Hide();
                P3MateriaPrima.Show();
                P3MateriaPrima.BringToFront();
            } else if (_paginaActual == 4 && P1DatosGenerales.CategoriaProducto == CategoriaProducto.ProductoTerminado) {
                P5CostoProduccion.Hide();
                P4Actividades.Show();
                P4Actividades.BringToFront();
            } else if (_paginaActual == 5 && P1DatosGenerales.CategoriaProducto == CategoriaProducto.ProductoTerminado) {
                P6PrecioCompraventa.Hide();
                P5CostoProduccion.Show();
                P5CostoProduccion.BringToFront();
            }

            btnAtras.Visible = _paginaActual > 1;
            btnRegistrar.Text = _paginaActual == 6 ? "Registrar" : "Siguiente";
        };
        btnSalir.Click += delegate (object? sender, EventArgs args) { Salir?.Invoke(sender, args); };

        // Enlace de scanner
        UtilesServidorScanner.Servidor.DatosRecibidos += ProcesarDatosScanner;
    }

    public void CargarRazonesSocialesProveedores(object[] nombresProveedores) {
        P1DatosGenerales.CargarRazonesSocialesProveedores(nombresProveedores);
    }

    private void ProcesarDatosScanner(string codigo) {
        if (string.IsNullOrEmpty(codigo))
            return;

        Invoke((MethodInvoker) delegate {
            Codigo = codigo.Replace("\0", "");
        });
    }

    public void Mostrar() {
        BringToFront();
        ShowDialog();
    }

    public void Restaurar() {
        P1DatosGenerales.Restaurar();

        PrecioCompraBase = 0;
        PrecioVentaBase = 0;
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