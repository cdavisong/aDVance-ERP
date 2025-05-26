using System.Globalization;
using System.Windows.Forms;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto {
    public partial class VistaRegistroProductoP6 : Form {
        public VistaRegistroProductoP6() {
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
    }
}
