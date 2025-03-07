using aDVanceERP.Desktop.MVP.Vistas.ContenedorEstadisticas.Plantillas;
using aDVanceERP.Desktop.Properties;

using System.Globalization;

namespace aDVanceERP.Desktop.MVP.Vistas.ContenedorEstadisticas {
    public partial class VistaContenedorEstadísticas : Form, IVistaContenedorEstadisticas {
        public VistaContenedorEstadísticas() {
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

        public int CantidadArticulosRegistrados {
            get => int.TryParse(fieldCantArticulosRegistrados.Text, out var cantidad) ? cantidad : 0;
            set => fieldCantArticulosRegistrados.Text = value.ToString();
        }

        public decimal MontoInversionArticulos {
            get => decimal.TryParse(fieldMontoInversionArticuloss.Text.Remove(1, 2), out var monto) ? monto : 0;
            set => fieldMontoInversionArticuloss.Text = $"$ {value.ToString("N2", CultureInfo.InvariantCulture)}";
        }

        public int CantidadArticulosVendidos {
            get => int.TryParse(fieldCantArticulosVendidos.Text, out var cantidad) ? cantidad : 0;
            set => fieldCantArticulosVendidos.Text = value.ToString();
        }

        public decimal MontoVentaArticulosVendidos {
            get => decimal.TryParse(fieldMontoVentaArticulosVendidos.Text.Remove(1, 2), out var monto) ? monto : 0;
            set => fieldMontoVentaArticulosVendidos.Text = $"$ {value.ToString("N2", CultureInfo.InvariantCulture)}";
        }

        public decimal MontoGananciaTotalNegocio {
            get => decimal.TryParse(fieldGananciaTotalNegocio.Text.Remove(1, 2), out var monto) ? monto : 0;
            set => fieldGananciaTotalNegocio.Text = $"$ {value.ToString("N2", CultureInfo.InvariantCulture)}";
        }

        public event EventHandler? MostrarVistaGestionArticulos;
        public event EventHandler? MostrarVistaGestionVentas;
        public event EventHandler? Salir;

        public void Inicializar() {            
            subLayout1EstadisticasProducto.Paint += (sender, e) => {
                e.Graphics.Clear(Color.PeachPuff);
                e.Graphics.DrawImageUnscaled(Resources.productE_96px,
                    subLayout1EstadisticasProducto.Width - 96,
                    subLayout1EstadisticasProducto.Height - 96);
            };
            subLayout1EstadisticasVentaProducto.Paint += (sender, e) => {
                e.Graphics.Clear(Color.PaleGoldenrod);
                e.Graphics.DrawImageUnscaled(Resources.best_sales_96px,
                    subLayout1EstadisticasProducto.Width - 96,
                    subLayout1EstadisticasProducto.Height - 96);
            };
            subLayout1EstadisticasGanancia.Paint += (sender, e) => {
                e.Graphics.Clear(Color.PaleTurquoise);
                e.Graphics.DrawImageUnscaled(Resources.accountF_96px,
                    subLayout1EstadisticasGanancia.Width - 96,
                    subLayout1EstadisticasGanancia.Height - 96);
            };
            btnGestionarArticulos.Click += delegate (object? sender, EventArgs e) {
                MostrarVistaGestionArticulos?.Invoke(sender, e);
            };
            btnGestionarVentas.Click += delegate (object? sender, EventArgs e) {
                MostrarVistaGestionVentas?.Invoke(sender, e);
            };
        }

        public void Mostrar() {
            fieldTituloArticulosVendidos.Text = $"Artículos vendidos hoy {DateTime.Now.ToString("dd/MM/yyyy")}";

            BringToFront();
            Show();
        }

        public void Restaurar() {

        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {

        }
    }
}
