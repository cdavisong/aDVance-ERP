using System.Globalization;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto;

public partial class VistaRegistroProductoP2 : Form {
    private bool _modoEdicion;

    public VistaRegistroProductoP2() {
        InitializeComponent();
        Inicializar();
    }

    public string UnidadMedida {
        get => fieldUnidadMedida.Text;
        set => fieldUnidadMedida.Text = value;
    }

    public string[] DescripcionesUnidadMedida { get; private set; } = Array.Empty<string>();

    public decimal PrecioCompraBase {
        get => decimal.TryParse(fieldPrecioCompraBase.Text, NumberStyles.Any, CultureInfo.InvariantCulture,
                 out var value)
                 ? value
                 : 0;
        set => fieldPrecioCompraBase.Text = value.ToString("N2", CultureInfo.InvariantCulture);
    }

    public decimal PrecioVentaBase {
        get => decimal.TryParse(fieldPrecioVentaBase.Text, NumberStyles.Any, CultureInfo.InvariantCulture,
                 out var value)
                 ? value
                 : 0;
        set => fieldPrecioVentaBase.Text = value.ToString("N2", CultureInfo.InvariantCulture);
    }

    public string? NombreAlmacen {
        get => fieldNombreAlmacen.Text;
        set => fieldNombreAlmacen.Text = value;
    }

    public int StockInicial {
        get => int.TryParse(fieldStockInicial.Text, out var value)
                 ? value
                 : 0;
        set => fieldStockInicial.Text = value.ToString();
    }

    public bool ModoEdicionDatos {
        get => _modoEdicion;
        set {
            ConfigurarVisibilidadCamposAlmacenStock(!value);

            _modoEdicion = value;
        }
    }

    public event EventHandler? RegistrarUnidadMedida;
    public event EventHandler? EliminarUnidadMedida;

    private void Inicializar() {
        fieldUnidadMedida.SelectedIndexChanged += delegate (object? sender, EventArgs args) {
            fieldDescripcionUnidadMedida.Text = DescripcionesUnidadMedida[fieldUnidadMedida.SelectedIndex];
        };
        btnAdicionarUnidadMedida.Click += delegate (object? sender, EventArgs args) {
            RegistrarUnidadMedida?.Invoke(sender, args);
        };
        btnEliminarUnidadMedida.Click += delegate (object? sender, EventArgs args) {
            EliminarUnidadMedida?.Invoke(UnidadMedida, args);
        };
        fieldNombreAlmacen.SelectedIndexChanged += delegate {
            StockInicial = 0;

            fieldStockInicial.Focus();
        };
    }

    public void CargarNombresAlmacenes(object[] nombresAlmacenes) {
        fieldNombreAlmacen.Items.Clear();
        fieldNombreAlmacen.Items.AddRange(nombresAlmacenes);
        fieldNombreAlmacen.SelectedIndex = nombresAlmacenes.Length > 0 ? 0 : -1;
    }

    public void CargarUnidadesMedida(object[] unidadesMedida) {
        fieldUnidadMedida.Items.Clear();
        fieldUnidadMedida.Items.AddRange(unidadesMedida);
        fieldUnidadMedida.SelectedIndex = unidadesMedida.Length > 0 ? 0 : -1;
    }

    public void CargarDescripcionesUnidadesMedida(string[] descripcionesUnidadesMedida) {
        Array.Clear(DescripcionesUnidadMedida);
        DescripcionesUnidadMedida = descripcionesUnidadesMedida;
    }

    public void ConfigurarVisibilidadCamposPrecios(bool mostrarCompra, bool mostrarVenta) {
        // Ajustar visibilidad y altura de fila para precio de compra
        layoutPrecioCompraBase.Visible = mostrarCompra;
        layoutBase.RowStyles[5].Height = mostrarCompra ? 45F : 0F;

        // Ajustar visibilidad y altura de fila para precio de venta
        layoutPrecioVentaBase.Visible = mostrarVenta;
        layoutBase.RowStyles[6].Height = mostrarVenta ? 45F : 0F;

        // Ajustar el separador según si hay algún campo visible
        bool algunCampoVisible = mostrarCompra || mostrarVenta;

        separador1.Visible = algunCampoVisible;
        layoutBase.RowStyles[7].Height = algunCampoVisible ? 20F : 0F;

        // Forzar el redibujado del layout
        layoutBase.PerformLayout();
    }

    public void ConfigurarVisibilidadCamposAlmacenStock(bool mostrarAlmacenStock) {
        // Ajustar visibilidad y altura de filas para almacén y stock inicial
        layoutTituloAlmacenStock.Visible = mostrarAlmacenStock;
        layoutBase.RowStyles[8].Height = mostrarAlmacenStock ? 35F : 0F;

        layoutAlmacenStock.Visible = mostrarAlmacenStock;
        layoutBase.RowStyles[9].Height = mostrarAlmacenStock ? 45F : 0F;

        // Ajustar el separador según si el campo de almacén y stock está visible
        separador1.Visible = mostrarAlmacenStock;
        layoutBase.RowStyles[7].Height = mostrarAlmacenStock ? 20F : 0F;

        // Forzar el redibujado del layout
        layoutBase.PerformLayout();
    }

    public void Restaurar() {
        UnidadMedida = string.Empty;
        fieldUnidadMedida.SelectedIndex = 0;
        fieldDescripcionUnidadMedida.Text = "Seleccione o registre una unidad de medida";
        PrecioCompraBase = 0;
        PrecioVentaBase = 0;
        NombreAlmacen = string.Empty;
        fieldNombreAlmacen.SelectedIndex = 0;
        StockInicial = 0;
        ModoEdicionDatos = false;
    }
}
