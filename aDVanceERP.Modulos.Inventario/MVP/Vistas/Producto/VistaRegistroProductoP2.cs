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

    public string TipoMateriaPrima {
        get => fieldTipoMateriaPrima.Text;
        set => fieldTipoMateriaPrima.Text = value;
    }

    public string[] DescripcionesTiposMateriaPrima { get; private set; } = Array.Empty<string>();

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

    public float StockInicial {
        get => float.TryParse(fieldStockInicial.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var value)
                 ? value
                 : 0f;
        set => fieldStockInicial.Text = value.ToString("0.00", CultureInfo.InvariantCulture);
    }

    public bool ModoEdicionDatos {
        get => _modoEdicion;
        set {
            ConfigurarVisibilidadCamposAlmacenStock(!value);

            _modoEdicion = value;
        }
    }

    public event EventHandler? RegistrarUnidadMedida;
    public event EventHandler? RegistrarTipoMateriaPrima;
    public event EventHandler? EliminarUnidadMedida;
    public event EventHandler? EliminarTipoMateriaPrima;

    private void Inicializar() {
        // Configuracion de los campos de tipo de materia prima
        ConfigurarVisibilidadCamposTipoMateriaPrima(false);

        // Eventos
        fieldUnidadMedida.SelectedIndexChanged += delegate (object? sender, EventArgs args) {
            fieldDescripcionUnidadMedida.Text = DescripcionesUnidadMedida[fieldUnidadMedida.SelectedIndex];
        };
        fieldTipoMateriaPrima.SelectedIndexChanged += delegate (object? sender, EventArgs args) {
            fieldDescripcionTipoMateriaPrima.Text = DescripcionesTiposMateriaPrima[fieldTipoMateriaPrima.SelectedIndex];
        };
        btnAdicionarUnidadMedida.Click += delegate (object? sender, EventArgs args) {
            RegistrarUnidadMedida?.Invoke(sender, args);
        };
        btnAdicionarTipoMateriaPrima.Click += delegate (object? sender, EventArgs args) {
            RegistrarTipoMateriaPrima?.Invoke(sender, args);
        };
        btnEliminarUnidadMedida.Click += delegate (object? sender, EventArgs args) {
            EliminarUnidadMedida?.Invoke(UnidadMedida, args);
        };
        btnEliminarTipoMateriaPrima.Click += delegate (object? sender, EventArgs args) {
            EliminarTipoMateriaPrima?.Invoke(TipoMateriaPrima, args);
        };
        fieldNombreAlmacen.SelectedIndexChanged += delegate {
            StockInicial = 0;

            fieldStockInicial.Focus();
        };
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

    public void CargarTiposMateriaPrima(object[] nombresTiposMateriaPrima) {
        fieldTipoMateriaPrima.Items.Clear();
        fieldTipoMateriaPrima.Items.AddRange(nombresTiposMateriaPrima);
        fieldTipoMateriaPrima.SelectedIndex = nombresTiposMateriaPrima.Length > 0 ? 0 : -1;
    }

    public void CargarDescripcionesTiposMateriaPrima(string[] descripcionesTiposMateriaPrima) {
        Array.Clear(DescripcionesTiposMateriaPrima);
        DescripcionesTiposMateriaPrima = descripcionesTiposMateriaPrima;
    }

    public void CargarNombresAlmacenes(object[] nombresAlmacenes) {
        fieldNombreAlmacen.Items.Clear();
        fieldNombreAlmacen.Items.AddRange(nombresAlmacenes);
        fieldNombreAlmacen.SelectedIndex = nombresAlmacenes.Length > 0 ? 0 : -1;
    }

    public void ConfigurarVisibilidadCamposTipoMateriaPrima(bool mostrarTipoMateriaPrima) {
        // Ajustar visibilidad y altura de filas para tipo de materia prima
        fieldTituloTipoMateriaPrima.Visible = mostrarTipoMateriaPrima;
        layoutBase.RowStyles[4].Height = mostrarTipoMateriaPrima ? 35F : 0F;

        layoutTipoMateriaPrima.Visible = mostrarTipoMateriaPrima;
        layoutBase.RowStyles[5].Height = mostrarTipoMateriaPrima ? 45F : 0F;

        fieldDescripcionTipoMateriaPrima.Visible = mostrarTipoMateriaPrima;
        layoutBase.RowStyles[6].Height = mostrarTipoMateriaPrima ? 25F : 0F;

        // Ajustar el separador según si el producto es materia prima
        separador1.Visible = mostrarTipoMateriaPrima;
        layoutBase.RowStyles[3].Height = mostrarTipoMateriaPrima ? 20F : 0F;

        // Forzar el redibujado del layout
        layoutBase.PerformLayout();

        // Limpiar datos:
        if (fieldTipoMateriaPrima.Items.Count > 0 && !mostrarTipoMateriaPrima)
            fieldTipoMateriaPrima.SelectedIndex = 0;
    }

    public void ConfigurarVisibilidadCamposPrecios(bool mostrarCompra, bool mostrarVenta) {
        // Ajustar visibilidad y altura de fila para precio de compra
        layoutPrecioCompraBase.Visible = mostrarCompra;
        layoutBase.RowStyles[9].Height = mostrarCompra ? 45F : 0F;

        // Ajustar visibilidad y altura de fila para precio de venta
        layoutPrecioVentaBase.Visible = mostrarVenta;
        layoutBase.RowStyles[10].Height = mostrarVenta ? 45F : 0F;

        bool algunCampoVisible = mostrarCompra || mostrarVenta;

        // Ajustar visibilidad y altura de fila para el titulo de compraventa
        fieldTituloPrecios.Visible = algunCampoVisible;
        layoutBase.RowStyles[8].Height = algunCampoVisible ? 35F : 0F;

        // Ajustar el separador según si hay algún campo visible
        separador2.Visible = algunCampoVisible;
        layoutBase.RowStyles[7].Height = algunCampoVisible ? 20F : 0F;

        // Forzar el redibujado del layout
        layoutBase.PerformLayout();
    }

    public void ConfigurarVisibilidadCamposAlmacenStock(bool mostrarAlmacenStock) {
        // Ajustar visibilidad y altura de filas para almacén y stock inicial
        layoutTituloAlmacenStock.Visible = mostrarAlmacenStock;
        layoutBase.RowStyles[12].Height = mostrarAlmacenStock ? 35F : 0F;

        layoutAlmacenStock.Visible = mostrarAlmacenStock;
        layoutBase.RowStyles[13].Height = mostrarAlmacenStock ? 45F : 0F;

        // Ajustar el separador según si el campo de almacén y stock está visible
        separador1.Visible = mostrarAlmacenStock;
        layoutBase.RowStyles[11].Height = mostrarAlmacenStock ? 20F : 0F;

        // Forzar el redibujado del layout
        layoutBase.PerformLayout();
    }

    public void Restaurar() {
        UnidadMedida = string.Empty;
        fieldUnidadMedida.SelectedIndex = 0;
        fieldDescripcionUnidadMedida.Text = "Seleccione o registre una unidad de medida";
        fieldTipoMateriaPrima.SelectedIndex = 0;
        fieldDescripcionTipoMateriaPrima.Text = "Seleccione o registre un tipo de materia prima";
        PrecioCompraBase = 0;
        PrecioVentaBase = 0;
        NombreAlmacen = string.Empty;
        fieldNombreAlmacen.SelectedIndex = 0;
        StockInicial = 0;
        ModoEdicionDatos = false;
    }
}
