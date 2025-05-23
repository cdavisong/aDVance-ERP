using System.Globalization;

using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto; 

public partial class VistaRegistroProducto : Form, IVistaRegistroProducto {
    private bool _modoEdicion;

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
        get => fieldNombre.Text;
        set => fieldNombre.Text = value;
    }

    public string Codigo {
        get => fieldCodigo.Text;
        set => fieldCodigo.Text = value;
    }

    public string Descripcion {
        get => fieldDescripcion.Text;
        set => fieldDescripcion.Text = value;
    }

    public string RazonSocialProveedor {
        get => fieldNombreProveedor.Text;
        set => fieldNombreProveedor.Text = value;
    }

    public decimal PrecioCompraBase {
        get => decimal.TryParse(fieldPrecioAdquisicion.Text, NumberStyles.Any, CultureInfo.InvariantCulture,
            out var value)
            ? value
            : 0;
        set => fieldPrecioAdquisicion.Text = value.ToString("N2", CultureInfo.InvariantCulture);
    }

    public decimal PrecioVentaBase {
        get => decimal.TryParse(fieldPrecioCesion.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var value)
            ? value
            : 0;
        set => fieldPrecioCesion.Text = value.ToString("N2", CultureInfo.InvariantCulture);
    }

    public bool ModoEdicionDatos {
        get => _modoEdicion;
        set {
            fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
            btnRegistrar.Text = value ? "Actualizar producto" : "Registrar producto";
            _modoEdicion = value;
        }
    }

    public event EventHandler? RegistrarDatos;
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarDatos;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Eventos
        btnCerrar.Click += delegate(object? sender, EventArgs args) { Salir?.Invoke(sender, args); };
        btnRegistrar.Click += delegate(object? sender, EventArgs args) {
            if (ModoEdicionDatos)
                EditarDatos?.Invoke(sender, args);
            else
                RegistrarDatos?.Invoke(sender, args);
        };
        btnSalir.Click += delegate(object? sender, EventArgs args) { Salir?.Invoke(sender, args); };

        // Enlace de scanner
        UtilesServidorScanner.Servidor.DatosRecibidos += ProcesarDatosScanner;
    }

    public void CargarRazonesSocialesProveedores(object[] nombresProveedores) {
        fieldNombreProveedor.Items.Clear();
        fieldNombreProveedor.Items.Add("Ninguno");
        fieldNombreProveedor.Items.AddRange(nombresProveedores);
        fieldNombreProveedor.SelectedIndex = 0;
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
        Nombre = string.Empty;
        Codigo = string.Empty;
        Descripcion = string.Empty;
        RazonSocialProveedor = string.Empty;
        fieldNombreProveedor.SelectedIndex = 0;
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