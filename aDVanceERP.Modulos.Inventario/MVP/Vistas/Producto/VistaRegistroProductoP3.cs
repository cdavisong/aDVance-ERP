using System.Globalization;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto;

public partial class VistaRegistroProductoP3 : Form {
    private bool _modoEdicion;

    public VistaRegistroProductoP3() {
        InitializeComponent();
        Inicializar();
    }

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

    private void Inicializar() {
        fieldNombreAlmacen.SelectedIndexChanged += delegate {
            StockInicial = 0;

            fieldStockInicial.Focus();
        };
    }

    public void CargarNombresAlmacenes(object[] nombresAlmacenes) {
        fieldNombreAlmacen.Items.Clear();
        fieldNombreAlmacen.Items.AddRange(nombresAlmacenes);
        fieldNombreAlmacen.SelectedIndex = 0;
    }

    public void ConfigurarVisibilidadCamposPrecios(bool mostrarCompra, bool mostrarVenta) {
        // Ajustar visibilidad y altura de fila para precio de compra
        layoutPrecioCompraBase.Visible = mostrarCompra;
        layoutBase.RowStyles[1].Height = mostrarCompra ? 45F : 0F;

        // Ajustar visibilidad y altura de fila para precio de venta
        layoutPrecioVentaBase.Visible = mostrarVenta;
        layoutBase.RowStyles[2].Height = mostrarVenta ? 45F : 0F;

        // Ajustar el separador según si hay algún campo visible
        bool algunCampoVisible = mostrarCompra || mostrarVenta;

        separador1.Visible = algunCampoVisible;
        layoutBase.RowStyles[3].Height = algunCampoVisible ? 20F : 0F;

        // Forzar el redibujado del layout
        layoutBase.PerformLayout();
    }

    public void ConfigurarVisibilidadCamposAlmacenStock(bool mostrarAlmacenStock) {
        // Ajustar visibilidad y altura de filas para almacén y stock inicial
        layoutTituloAlmacenStock.Visible = mostrarAlmacenStock;
        layoutBase.RowStyles[4].Height = mostrarAlmacenStock ? 35F : 0F;

        layoutAlmacenStock.Visible = mostrarAlmacenStock;
        layoutBase.RowStyles[5].Height = mostrarAlmacenStock ? 45F : 0F;

        // Ajustar el separador según si el campo de almacén y stock está visible
        separador1.Visible = mostrarAlmacenStock;
        layoutBase.RowStyles[3].Height = mostrarAlmacenStock ? 20F : 0F;

        // Forzar el redibujado del layout
        layoutBase.PerformLayout();
    }

    public void Restaurar() {
        PrecioCompraBase = 0;
        PrecioVentaBase = 0;
        NombreAlmacen = string.Empty;
        fieldNombreAlmacen.SelectedIndex = 0;
        StockInicial = 0;
        ModoEdicionDatos = false;
    }
}
