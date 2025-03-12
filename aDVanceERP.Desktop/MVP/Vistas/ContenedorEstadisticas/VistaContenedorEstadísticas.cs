using aDVanceERP.Desktop.MVP.Vistas.ContenedorEstadisticas.Plantillas;
using aDVanceERP.Desktop.Properties;
using aDVanceERP.Modulos.Ventas.MVP.Modelos;

using System.Drawing.Drawing2D;
using System.Globalization;

namespace aDVanceERP.Desktop.MVP.Vistas.ContenedorEstadisticas {
    public partial class VistaContenedorEstadísticas : Form, IVistaContenedorEstadisticas {
        private DatosEstadisticosVentas _datosEstadisticosVentas;

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
            fieldCriterioBusqueda.Items.AddRange(new object[] {
                "Diario",
                "Mensual",
                "Anual"
            });

            // Eventos
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
            fieldCriterioBusqueda.SelectedIndexChanged += delegate {
                fieldDatoBusquedaFecha.Format = DateTimePickerFormat.Custom;

                switch (fieldCriterioBusqueda.SelectedItem.ToString()) {
                    case "Diario":
                        fieldDatoBusquedaFecha.CustomFormat = "yyyy-MM-dd";
                        break;
                    case "Mensual":
                        fieldDatoBusquedaFecha.CustomFormat = "yyyy-MM";
                        break;
                    case "Anual":
                        fieldDatoBusquedaFecha.CustomFormat = "yyyy";
                        break;
                    default:
                        break;
                }

                fieldGraficoVentas.Invalidate();
            };
            fieldGraficoVentas.Paint += RenderizarGraficoVentas;
        }

        private void RenderizarGraficoVentas(object? sender, PaintEventArgs e) {
            if (fieldCriterioBusqueda.SelectedIndex == -1)
                return;

            var g = e.Graphics;
            
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(fieldGraficoVentas.BackColor);

            // Configuración inicial
            var margen = 40;
            var ancho = fieldGraficoVentas.Width - 2 * margen;
            var altura = fieldGraficoVentas.Height - 2 * margen;

            // Dibujar ejes
            g.DrawLine(Pens.Gray, margen, margen, margen, margen + altura);
            g.DrawLine(Pens.Gray, margen, margen + altura, margen + ancho, margen + altura);

            // Obtiene datos según selección
            var tipoGrafico = fieldCriterioBusqueda.SelectedItem.ToString();
            var fechaSeleccionada = fieldDatoBusquedaFecha.Value;

            // Datos
            var datosGrafico = ObtenerDatosGrafico(tipoGrafico, fechaSeleccionada);

            // Calcular escalas
            var valorMaximo = datosGrafico.Values.Max();
            var escalaY = altura / (float)valorMaximo;
            var pasoX = ancho / (float)datosGrafico.Count;

            // Dibujar barras
            var i = 0;
            foreach (var dato in datosGrafico) {
                var alturaBarra = (float) dato.Value * escalaY;
                var barra = new RectangleF(
                        margen * i * pasoX + 2,
                        margen + altura - alturaBarra,
                        pasoX - 4,
                        alturaBarra
                    );

                g.FillRectangle(Brushes.DarkGray, barra);
                i++;
            }

            // Dibujar etiquetas
            i = 0;
            foreach (var dato in datosGrafico) {
                var posX = margen + i * pasoX + pasoX / 2;

                g.DrawString(dato.Key, Font, Brushes.Black, posX, margen + altura + 5);
            }
        }

        private Dictionary<string, decimal> ObtenerDatosGrafico(string? tipoGrafico, DateTime fechaSeleccionada) {
            var resultado = new Dictionary<string, decimal>();

            switch (fieldCriterioBusqueda.SelectedItem.ToString()) {
                case "Diario":
                    foreach (var dato in _datosEstadisticosVentas.VentasPorHora.Where(x => x.Key.Date == fechaSeleccionada.Date))
                        resultado.Add(dato.Key.ToString("HH:00"), dato.Value);
                    break;
                case "Mensual":
                    foreach (var dato in _datosEstadisticosVentas.VentasPorDia.Where(x => x.Key.Date.Month == fechaSeleccionada.Month && x.Key.Year == fechaSeleccionada.Year))
                        resultado.Add(dato.Key.ToString("00"), dato.Value);
                    break;
                case "Anual":
                    foreach (var dato in _datosEstadisticosVentas.VentasPorMes.Where(x => x.Key.Date.Year == fechaSeleccionada.Year))
                        resultado.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dato.Key.Date.Month), dato.Value);
                    break;
                default:
                    break;
            }

            return resultado;
        }

        public void Mostrar() {
            fieldTituloArticulosVendidos.Text = $"Artículos vendidos hoy {DateTime.Now.ToString("dd/MM/yyyy")}";
            fieldCriterioBusqueda.SelectedIndex = 0 ;

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
