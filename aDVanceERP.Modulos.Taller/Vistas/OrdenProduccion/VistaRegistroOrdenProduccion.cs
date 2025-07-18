using aDVanceERP.Modulos.Taller.Interfaces;

using System.Globalization;

namespace aDVanceERP.Modulos.Taller.Vistas.OrdenProduccion {
    public partial class VistaRegistroOrdenProduccion : Form, IVistaRegistroOrdenProduccion {
        private bool _modoEdicion;
        private string _numeroOrden = "-";
        private DateTime _fechaApertura = DateTime.Now;

        public VistaRegistroOrdenProduccion() {
            InitializeComponent();
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

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnAbrirCerrarOrdenProduccion.Text = value ? "Cerrar orden de producción" : "Abrir orden de producción";
                _modoEdicion = value;
            }
        }

        public string NumeroOrden { 
            get => _numeroOrden;
            set {
                _numeroOrden = value;
                fieldSubtitulo.Text = $"Registro Nro. {_numeroOrden} del {FechaApertura:dd/MM/yyyy}";
            }
        }

        public DateTime FechaApertura {
            get => _fechaApertura;
            set {
                _fechaApertura = value;
                fieldSubtitulo.Text = $"Registro Nro. {NumeroOrden} del {FechaApertura:dd/MM/yyyy}";
            }
        }

        public string NombreProductoTerminado {
            get => fieldNombreProductoTerminado.Text;
            set => fieldNombreProductoTerminado.Text = value;
        }

        public decimal Cantidad {
            get => decimal.TryParse(fieldCantidadProducir.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var cantidad) ? cantidad : 0m;
            set => fieldCantidadProducir.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public decimal MargenGanancia {
            get => decimal.TryParse(fieldMargenGananciaDeseado.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var margen) ? margen : 0m;
            set => fieldMargenGananciaDeseado.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            btnAbrirCerrarOrdenProduccion.Click += delegate (object? sender, EventArgs args) {
                //if (ModoEdicionDatos)
                //    EditarDatos?.Invoke(sender, args);
                //else
                //    RegistrarDatos?.Invoke(sender, args);
            };
            btnSalir.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
        }

        public void Mostrar() {
            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            ModoEdicionDatos = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
