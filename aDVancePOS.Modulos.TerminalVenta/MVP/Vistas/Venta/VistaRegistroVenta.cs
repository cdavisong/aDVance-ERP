using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;

using aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta.Plantillas;

namespace aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta {
    public partial class VistaRegistroVenta : Form, IVistaRegistroVenta {
        public VistaRegistroVenta() {
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

        public string DatoBusqueda {
            get => fieldDatoBusqueda.Text;
            set => fieldDatoBusqueda.Text = value;
        }

        public CriterioBusquedaVenta CriterioBusqueda {
            get => fieldCriterioBusqueda.SelectedIndex >= 0
                ? (CriterioBusquedaVenta) fieldCriterioBusqueda.SelectedIndex
                : default;
            set => fieldCriterioBusqueda.SelectedIndex = (int) value;
        }

        public bool ModoEdicionDatos { get; set; }

        public event EventHandler? Salir;
        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? BuscarDatos;

        public void Inicializar() {
            // Eventos
            fieldDatoBusqueda.TextChanged += delegate (object? sender, EventArgs e) {
                if (!string.IsNullOrEmpty(DatoBusqueda))
                    BuscarDatos?.Invoke(new object[] { CriterioBusqueda, DatoBusqueda }, e);
                else SincronizarDatos?.Invoke(sender, e);
            };
            
        }

        public void CargarCriteriosBusqueda(string[] criteriosBusqueda) {
            fieldCriterioBusqueda.Items.AddRange(criteriosBusqueda);
            fieldCriterioBusqueda.SelectedIndexChanged += delegate {
                fieldDatoBusqueda.Text = string.Empty;
                fieldDatoBusqueda.Visible = fieldCriterioBusqueda.SelectedIndex != 0;
                fieldDatoBusqueda.Focus();

                BuscarDatos?.Invoke(new object[] { CriterioBusqueda, string.Empty }, EventArgs.Empty);
            };
            fieldCriterioBusqueda.SelectedIndex = 0;
        }

        public void Mostrar() {
            Habilitada = true;
            BringToFront();
            Show();
        }

        public void Restaurar() {
            Habilitada = true;

            fieldCriterioBusqueda.SelectedIndex = 0;
        }

        public void Ocultar() {
            Habilitada = false;
            Hide();
        }

        public void Cerrar() {
            // ...
        }

        public void CargarCriteriosBusqueda(object[] criteriosBusqueda) {
            throw new NotImplementedException();
        }
    }
}
