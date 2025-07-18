using aDVanceERP.Modulos.Taller.Interfaces;
using System.Globalization;

namespace aDVanceERP.Modulos.Taller.Vistas.OrdenProduccion;

public partial class VistaTuplaDetalleMateriaPrima : Form, IVistaTuplaDetalleMateriaPrima {
    private bool _enabled = true;

    public VistaTuplaDetalleMateriaPrima() {
        InitializeComponent();
        Inicializar();
    }

    public bool Habilitada {
        get => _enabled;
        set {
            _enabled = value;
            fieldPrecioUnitario.ReadOnly = !value;
            btnEliminar.Enabled = value;
        }
    }

    public Point Coordenadas {
        get => Location;
        set => Location = value;
    }

    public Size Dimensiones {
        get => Size;
        set => Size = value;
    }

    public string IdProducto { get; set; }

    public string NombreProducto {
        get => fieldNombreProducto.Text;
        set {
            fieldNombreProducto.Text = value;
            fieldNombreProducto.Margin = new Padding(1, value?.Length > 20 ? 10 : 1, 1, 1);
        }
    }

    public string PrecioUnitario {
        get => fieldPrecioUnitario.Text;
        set => fieldPrecioUnitario.Text = value;
    }

    public string Cantidad {
        get => fieldCantidad.Text;
        set => fieldCantidad.Text = value;
    }

    public Color ColorFondoTupla {
        get => layoutVista.BackColor;
        set => layoutVista.BackColor = value;
    }

    public event EventHandler? PrecioUnitarioModificado;
    public event EventHandler? TuplaSeleccionada;
    public event EventHandler? EditarDatosTupla;
    public event EventHandler? EliminarDatosTupla;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Eventos
        fieldNombreProducto.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldPrecioUnitario.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldPrecioUnitario.LostFocus += delegate { FormatearMontoModificado(); };
        fieldPrecioUnitario.KeyDown += delegate(object? sender, KeyEventArgs args) {
            if (args.KeyCode != Keys.Enter)
                return;

            FormatearMontoModificado();

            args.SuppressKeyPress = true;
        };
        fieldCantidad.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };

        btnEliminar.Click += delegate(object? sender, EventArgs e) {
            EliminarDatosTupla?.Invoke(new[] { IdProducto, NombreProducto, PrecioUnitario, Cantidad }, e);
        };
    }

    public void Mostrar() {
        BringToFront();
        Show();
    }

    public void Restaurar() {
        ColorFondoTupla = BackColor;
    }

    public void Ocultar() {
        Hide();
    }

    public void Cerrar() {
        Dispose();
    }

    private void FormatearMontoModificado() {
        if (!decimal.TryParse(PrecioUnitario, NumberStyles.Any, CultureInfo.InvariantCulture, out var monto))
            return;

        PrecioUnitario = monto.ToString("N2", CultureInfo.InvariantCulture);
        PrecioUnitarioModificado?.Invoke(this,
            EventArgs.Empty); // Dispara el evento para notificar que se ha modificado el monto
    }
}