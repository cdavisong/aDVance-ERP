using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;

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

    public string NombreArticulo {
        get => fieldNombreArticulo.Text;
        set => fieldNombreArticulo.Text = value;
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

    public int CantidadMovida {
        get => int.TryParse(fieldCantidadMovida.Text, out var value) ? value : 0;
        set => fieldCantidadMovida.Text = value.ToString();
    }

    public string TipoMovimiento {
        get => fieldTipoMovimiento.Text;
        set => fieldTipoMovimiento.Text = value;
    }

    public bool ModoEdicionDatos {
        get => _modoEdicion;
        set {
            fieldSubtitulo.Text = value
                ? $"Detalles y actualización del registro con fecha {Fecha:yyyy-MM-dd}"
                : $"Registro con fecha {Fecha:yyyy-MM-dd}";
            btnRegistrar.Text = value ? "Actualizar movimiento" : "Registrar movimiento";
            _modoEdicion = value;
        }
    }

    public event EventHandler? RegistrarTipoMovimiento;
    public event EventHandler? EliminarTipoMovimiento;
    public event EventHandler? RegistrarDatos;
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarDatos;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Propiedades
        ModoEdicionDatos = false;

        // Eventos
        fieldTipoMovimiento.SelectedIndexChanged += delegate { ActualizarCamposAlmacenes(); };
        btnCerrar.Click += delegate(object? sender, EventArgs args) { Salir?.Invoke(sender, args); };
        btnAdicionarTipoMovimiento.Click += delegate(object? sender, EventArgs args) {
            RegistrarTipoMovimiento?.Invoke(sender, args);
        };
        btnEliminarTipoMovimiento.Click += delegate(object? sender, EventArgs args) {
            EliminarTipoMovimiento?.Invoke(TipoMovimiento, args);
        };
        btnRegistrar.Click += delegate(object? sender, EventArgs args) {
            if (!MovimientoStockCorrecto())
                return;

            if (ModoEdicionDatos)
                EditarDatos?.Invoke(sender, args);
            else
                RegistrarDatos?.Invoke(sender, args);
        };
        btnSalir.Click += delegate(object? sender, EventArgs args) { Salir?.Invoke(sender, args); };
    }

    public void CargarNombresArticulos(string[] nombresArticulos) {
        fieldNombreArticulo.AutoCompleteCustomSource.Clear();
        fieldNombreArticulo.AutoCompleteCustomSource.AddRange(nombresArticulos);
        fieldNombreArticulo.AutoCompleteMode = AutoCompleteMode.Suggest;
        fieldNombreArticulo.AutoCompleteSource = AutoCompleteSource.CustomSource;
    }

    public void CargarNombresAlmacenes(object[] nombresAlmacenes) {
        fieldNombreAlmacenOrigen.Items.Clear();
        fieldNombreAlmacenOrigen.Items.Add("Ninguno");
        fieldNombreAlmacenOrigen.Items.AddRange(nombresAlmacenes);
        fieldNombreAlmacenOrigen.SelectedIndex = 0;

        fieldNombreAlmacenDestino.Items.Clear();
        fieldNombreAlmacenDestino.Items.Add("Ninguno");
        fieldNombreAlmacenDestino.Items.AddRange(nombresAlmacenes);
        fieldNombreAlmacenDestino.SelectedIndex = 0;
    }

    public void CargarTiposMovimientos(object[] tiposMovimientos) {
        fieldTipoMovimiento.Items.Clear();
        fieldTipoMovimiento.Items.AddRange(tiposMovimientos);
        fieldTipoMovimiento.SelectedIndex = 0;
    }

    public void ActualizarCamposAlmacenes() {
        var idTipoMovimiento = UtilesMovimiento.ObtenerIdTipoMovimiento(TipoMovimiento);

        if (UtilesMovimiento.ObtenerEfectoTipoMovimiento(idTipoMovimiento).Equals("Carga")) {
            fieldNombreAlmacenOrigen.SelectedIndex = 0;
            fieldNombreAlmacenOrigen.Enabled = false;
            fieldNombreAlmacenDestino.Enabled = true;
        }
        else if (UtilesMovimiento.ObtenerEfectoTipoMovimiento(idTipoMovimiento).Equals("Descarga")) {
            fieldNombreAlmacenDestino.SelectedIndex = 0;
            fieldNombreAlmacenDestino.Enabled = false;
            fieldNombreAlmacenOrigen.Enabled = true;
        }
        else {
            fieldNombreAlmacenOrigen.Enabled = true;
            fieldNombreAlmacenDestino.Enabled = true;
        }
    }

    public void Mostrar() {
        BringToFront();
        ShowDialog();
    }

    public void Restaurar() {
        NombreArticulo = string.Empty;
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
        Dispose();
    }

    private bool MovimientoStockCorrecto() {
        if (string.IsNullOrEmpty(NombreArticulo))
            return false;

        var idTipoMovimiento = UtilesMovimiento.ObtenerIdTipoMovimiento(TipoMovimiento);

        if (UtilesMovimiento.ObtenerEfectoTipoMovimiento(idTipoMovimiento).Equals("Carga"))
            return !string.Equals(NombreAlmacenDestino, "Ninguno");

        if (UtilesMovimiento.ObtenerEfectoTipoMovimiento(idTipoMovimiento).Equals("Descarga") &&
            string.Equals(NombreAlmacenOrigen, "Ninguno"))
            return false;

        var cantidadInicialOrigen = UtilesArticulo.ObtenerStockArticulo(NombreArticulo, NombreAlmacenOrigen).Result;

        if (cantidadInicialOrigen - CantidadMovida >= 0)
            return true;

        fieldCantidadMovida.ForeColor = Color.Firebrick;
        fieldCantidadMovida.Font = new Font(fieldCantidadMovida.Font, FontStyle.Bold);

        CentroNotificaciones.Mostrar(
            $"No se puede mover una cantidad de artículos hacia el destino menor que la cantidad orígen ({cantidadInicialOrigen} unidades) en el almacén {NombreAlmacenOrigen}",
            TipoNotificacion.Advertencia);

        return false;
    }
}