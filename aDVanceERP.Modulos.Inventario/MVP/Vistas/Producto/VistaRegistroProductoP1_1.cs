using aDVanceERP.Modulos.Inventario.MVP.Modelos;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto {
    public partial class VistaRegistroProductoP1_1 : Form {
        public VistaRegistroProductoP1_1() {
            InitializeComponent();
        }

        public CategoriaProducto CategoriaProducto {
            set {
                separador1.Visible = value == CategoriaProducto.MateriaPrima;
                layoutEsVendible.Visible = value == CategoriaProducto.MateriaPrima;
            }
        }

        public string RazonSocialProveedor {
            get => fieldNombreProveedor.Text;
            set => fieldNombreProveedor.Text = value;
        }

        public bool EsVendible {
            get => fieldEsVendible.Checked;
            set => fieldEsVendible.Checked = value;
        }

        public void CargarRazonesSocialesProveedores(object[] nombresProveedores) {
            fieldNombreProveedor.Items.Clear();
            fieldNombreProveedor.Items.Add("Ninguno");
            fieldNombreProveedor.Items.AddRange(nombresProveedores);
            fieldNombreProveedor.SelectedIndex = 0;
        }

        public void Restaurar() {
            RazonSocialProveedor = string.Empty;
            fieldNombreProveedor.SelectedIndex = 0;
        }
    }
}
