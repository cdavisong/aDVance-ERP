using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;
using System.Globalization;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento; 

public partial class VistaRegistroMovimiento : Form, IVistaRegistroMovimiento {
    private bool _modoEdicion;

    public VistaRegistroMovimiento() {
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

    public string NombreProducto {
        get => fieldNombreProducto.Text;
        set => fieldNombreProducto.Text = value;
    }

    public string? NombreAlmacenOrigen {
        get => fieldNombreAlmacenOrigen.Text;
        set => fieldNombreAlmacenOrigen.Text = value;
    }

    public string? NombreAlmacenDestino {
        get => fieldNombreAlmacenDestino.Text;
        set => fieldNombreAlmacenDestino.Text = value;
    }

    public DateTime Fecha {
        get => DateTime.Now;
        set { }
    }

    public decimal CantidadMovida {
        get => decimal.TryParse(fieldCantidadMovida.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var value) ? value : 0m;
        set => fieldCantidadMovida.Text = value.ToString("N2", CultureInfo.InvariantCulture);
    }

    public string TipoMovimiento {
        get => fieldTipoMovimiento.Text;
        set => fieldTipoMovimiento.Text = value;
    }

    public bool ModoEdicionDatos {
        get => _modoEdicion;
        set {
            fieldSubtitulo.Text = value
                ? $"Visualización del registro con fecha {Fecha:yyyy-MM-dd}"
                : $"Registro con fecha {Fecha:yyyy-MM-dd}";
            fieldNombreProducto.ReadOnly = value;
            fieldTipoMovimiento.Enabled = !value;
            btnAdicionarTipoMovimiento.Enabled = !value;
            btnEliminarTipoMovimiento.Enabled = !value;
            fieldNombreAlmacenOrigen.Enabled = !value;
            fieldNombreAlmacenDestino.Enabled = !value;
            fieldCantidadMovida.ReadOnly = value;
            btnRegistrar.Visible = !value;
            _modoEdicion = value;
        }
    }

    public event EventHandler? RegistrarTipoMovimiento;
    public event EventHandler? EliminarTipoMovimiento;
    public event EventHandler? RegistrarDatos;
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarDatos;
    

    public void Inicializar() {
        // Propiedades
        ModoEdicionDatos = false;

        // Eventos
        fieldTipoMovimiento.SelectedIndexChanged += delegate { 
            ActualizarCamposAlmacenes(); 
        };
        btnCerrar.Click += delegate(object? sender, EventArgs args) {
            Close();
        };
        btnAdicionarTipoMovimiento.Click += delegate(object? sender, EventArgs args) {
            RegistrarTipoMovimiento?.Invoke(sender, args);
        };
        btnEliminarTipoMovimiento.Click += delegate(object? sender, EventArgs args) {
            EliminarTipoMovimiento?.Invoke(TipoMovimiento, args);
        };
        btnRegistrar.Click += delegate(object? sender, EventArgs args) {
            if (ModoEdicionDatos)
                EditarDatos?.Invoke(sender, args);
            else
                RegistrarDatos?.Invoke(sender, args);
        };
        btnSalir.Click += delegate(object? sender, EventArgs args) { Close(); };

        // Enlace de scanner
        UtilesServidorScanner.Servidor.DatosRecibidos += ProcesarDatosScanner;
    }

    public void CargarNombresProductos(string[] nombresProductos) {
        fieldNombreProducto.AutoCompleteCustomSource.Clear();
        fieldNombreProducto.AutoCompleteCustomSource.AddRange(nombresProductos);
        fieldNombreProducto.AutoCompleteMode = AutoCompleteMode.Suggest;
        fieldNombreProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
    }

    public void CargarNombresAlmacenes(object[] nombresAlmacenes) {
        fieldNombreAlmacenOrigen.Items.Clear();
        fieldNombreAlmacenOrigen.Items.Add("Ninguno");
        fieldNombreAlmacenOrigen.Items.AddRange(nombresAlmacenes);
        fieldNombreAlmacenOrigen.SelectedIndex = nombresAlmacenes.Length > 0 ? 0 : -1;

        fieldNombreAlmacenDestino.Items.Clear();
        fieldNombreAlmacenDestino.Items.Add("Ninguno");
        fieldNombreAlmacenDestino.Items.AddRange(nombresAlmacenes);
        fieldNombreAlmacenDestino.SelectedIndex = nombresAlmacenes.Length > 0 ? 0 : -1;
    }

    public void CargarTiposMovimientos(object[] tiposMovimientos) {
        fieldTipoMovimiento.Items.Clear();

        foreach (var tipoMovimiento in tiposMovimientos) {
            var tipoMovimientoString = tipoMovimiento.ToString();

            if (string.IsNullOrEmpty(tipoMovimientoString) || 
                tipoMovimientoString.Equals("Compra") || 
                tipoMovimientoString.Equals("Venta") ||
                tipoMovimientoString.Equals("Gasto material") ||
                tipoMovimientoString.Equals("Producción"))
                continue;

            fieldTipoMovimiento.Items.Add(tipoMovimiento);
        }

        if (fieldTipoMovimiento.Items.Count > 0)
            fieldTipoMovimiento.SelectedIndex = tiposMovimientos.Length > 0 ? 0 : -1;
    }

    private void ProcesarDatosScanner(string codigo) {
        var nombreProducto = UtilesProducto.ObtenerNombreProducto(codigo.Replace("\0", "")).Result;

        if (string.IsNullOrEmpty(nombreProducto))
            return;

        Invoke((MethodInvoker) delegate {
            NombreProducto = nombreProducto;
        });
    }

    public void ActualizarCamposAlmacenes() {
        var idTipoMovimiento = UtilesMovimiento.ObtenerIdTipoMovimiento(TipoMovimiento);
                
        if (UtilesMovimiento.ObtenerEfectoTipoMovimiento(idTipoMovimiento).Equals("Carga")) {
            fieldNombreAlmacenOrigen.SelectedIndex = 0;
            fieldNombreAlmacenOrigen.Enabled = false;
            fieldNombreAlmacenDestino.Enabled = !ModoEdicionDatos;
        }
        else if (UtilesMovimiento.ObtenerEfectoTipoMovimiento(idTipoMovimiento).Equals("Descarga")) {
            fieldNombreAlmacenDestino.SelectedIndex = 0;
            fieldNombreAlmacenDestino.Enabled = false;
            fieldNombreAlmacenOrigen.Enabled = !ModoEdicionDatos;
        }
        else {
            fieldNombreAlmacenOrigen.Enabled = !ModoEdicionDatos;
            fieldNombreAlmacenDestino.Enabled = !ModoEdicionDatos;
        }
    }

    public void Mostrar() {
        BringToFront();
        ShowDialog();
    }

    public void Restaurar() {
        NombreProducto = string.Empty;
        NombreAlmacenOrigen = string.Empty;
        fieldNombreAlmacenOrigen.SelectedIndex = 0;
        NombreAlmacenDestino = string.Empty;
        fieldNombreAlmacenDestino.SelectedIndex = 0;
        CantidadMovida = 0;
        TipoMovimiento = string.Empty;
        fieldTipoMovimiento.SelectedIndex = 0;
        Fecha = DateTime.Now;
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