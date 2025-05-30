using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

using Google.Protobuf.WellKnownTypes;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto {
    public partial class VistaRegistroProductoP1 : Form {
        private VistaRegistroProductoP1_1 P1DatosProveedorVentaDirecta = new VistaRegistroProductoP1_1();

        public VistaRegistroProductoP1() {
            InitializeComponent();
            InicializarVistas();
            Inicializar();
            
            CargarCategoriasProducto();
        }

        public event EventHandler? CategoriaProductoCambiada;
        public event EventHandler? EsVendibleActualizado;

        public CategoriaProducto CategoriaProducto {
            get => (CategoriaProducto) fieldCategoriaProducto.SelectedIndex;
            set { 
                fieldCategoriaProducto.SelectedIndex = (int) value;
                fieldDescripcionCategoriaProducto.Text = UtilesCategoriaProducto.DescripcionesProducto[(int) value];
            }
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
            get => P1DatosProveedorVentaDirecta.RazonSocialProveedor;
            set => P1DatosProveedorVentaDirecta.RazonSocialProveedor = value;
        }

        public bool EsVendible {
            get => P1DatosProveedorVentaDirecta.EsVendible;
            set => P1DatosProveedorVentaDirecta.EsVendible = value;
        }

        private void InicializarVistas() {
            // 1. Datos del proveedor y venta directa de materia prima
            P1DatosProveedorVentaDirecta.Dock = DockStyle.Fill;
            P1DatosProveedorVentaDirecta.TopLevel = false;

            contenedorVistas.Controls.Clear();
            contenedorVistas.Controls.Add(P1DatosProveedorVentaDirecta);
        }

        private void Inicializar() {
            // Eventos
            fieldCategoriaProducto.SelectedIndexChanged += delegate (object? sender, EventArgs args) {
                fieldDescripcionCategoriaProducto.Text = UtilesCategoriaProducto.DescripcionesProducto[fieldCategoriaProducto.SelectedIndex];

                // Actualizar visibilidad de campos según la categoría seleccionada
                P1DatosProveedorVentaDirecta.Visible =
                    CategoriaProducto == CategoriaProducto.Mercancia ||
                    CategoriaProducto == CategoriaProducto.MateriaPrima;
                P1DatosProveedorVentaDirecta.CategoriaProducto = CategoriaProducto;

                CategoriaProductoCambiada?.Invoke(this, EventArgs.Empty);

                // Actualizar la propiedad vendible del producto
                if (CategoriaProducto == CategoriaProducto.Mercancia || 
                    CategoriaProducto == CategoriaProducto.ProductoTerminado)
                    EsVendible = true;
            };
            btnGenerarCodigo.Click += delegate (object? sender, EventArgs args) {
                if (string.IsNullOrEmpty(Nombre))
                    CentroNotificaciones.Mostrar("Debe especificar un nombre único para el producto antes de generar un nuevo código de barras. Llene los campos correspondientes y presione nuevaente el botón.", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
                else 
                    Codigo = UtilesCodigoBarras.GenerarEan13(Nombre);
            };
            P1DatosProveedorVentaDirecta.EsVendibleActualizado += delegate (object? sender, EventArgs args) {
                EsVendibleActualizado?.Invoke(this, EventArgs.Empty);
            };
        }

        private void CargarCategoriasProducto() {
            fieldCategoriaProducto.Items.Clear();
            fieldCategoriaProducto.Items.AddRange(UtilesCategoriaProducto.CategoriaProducto);
            fieldCategoriaProducto.SelectedIndex = 0;
            fieldDescripcionCategoriaProducto.Text = UtilesCategoriaProducto.DescripcionesProducto[0];
        }

        public void CargarRazonesSocialesProveedores(object[] nombresProveedores) {
            P1DatosProveedorVentaDirecta.CargarRazonesSocialesProveedores(nombresProveedores);
        }

        public void Restaurar() {
            Nombre = string.Empty;
            Codigo = string.Empty;
            Descripcion = string.Empty;

            P1DatosProveedorVentaDirecta.Restaurar();
        }
    }
}
