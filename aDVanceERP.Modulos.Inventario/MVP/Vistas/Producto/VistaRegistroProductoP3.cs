using System.Globalization;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto {
    public partial class VistaRegistroProductoP3 : Form {
        private bool _modoEdicion;

        public VistaRegistroProductoP3() {
            InitializeComponent();
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

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                ConfigurarVisibilidadCampoStockInicial(!value);

                _modoEdicion = value;
            }
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

        public void ConfigurarVisibilidadCampoStockInicial(bool mostrarStockInicial) {
            // Ajustar visibilidad y altura de fila para stock inicial
            layoutStockInicial.Visible = mostrarStockInicial;
            layoutBase.RowStyles[4].Height = mostrarStockInicial ? 45F : 0F;

            // Ajustar el separador
            separador1.Visible = mostrarStockInicial;
            layoutBase.RowStyles[3].Height = mostrarStockInicial ? 20F : 0F;

            // Forzar el redibujado del layout
            layoutBase.PerformLayout();
        }
    }
}
