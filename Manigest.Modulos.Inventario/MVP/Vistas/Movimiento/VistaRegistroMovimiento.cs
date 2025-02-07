using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Movimiento {
    public partial class VistaRegistroMovimiento : Form, IVistaRegistroMovimiento {
        private bool _modoEdicion;
        private int _cantidadInicial;
        private bool _movPositivo;

        public VistaRegistroMovimiento() {
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

        public string NombreArticulo {
            get => fieldNombreArticulo.Text;
            set => fieldNombreArticulo.Text = value;
        }

        public string NombreAlmacenOrigen {
            get => fieldNombreAlmacenOrigen.Text;
            set => fieldNombreAlmacenOrigen.Text = value;
        }

        public string NombreAlmacenDestino {
            get => fieldNombreAlmacenDestino.Text;
            set => fieldNombreAlmacenDestino.Text = value;
        }

        public int CantidadInicial {
            get => _cantidadInicial;
            set => _cantidadInicial = value;
        }

        public int CantidadMovida {
            get => int.TryParse(fieldCantidadMovida.Text, out var value) ? value : 0;
            set => fieldCantidadMovida.Text = value.ToString();
        }

        public int CantidadFinal {
            get {
                if (_movPositivo)
                    return CantidadInicial + CantidadMovida;
                return CantidadInicial - CantidadMovida;
            }
            set { }
        }

        public string Motivo {
            get => fieldMotivo.Text;
            set => fieldMotivo.Text = value;
        }

        public DateTime Fecha {
            get => DateTime.Now;
            set { }
        }

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnRegistrar.Text = value ? "Actualizar movimiento" : "Registrar movimiento";
                _modoEdicion = value;
            }
        }

        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            fieldCantidadMovida.TextChanged += delegate (object? sender, EventArgs e) {
                if (_movPositivo)
                    CantidadFinal = CantidadInicial + CantidadMovida;
                else
                    CantidadFinal = CantidadInicial - CantidadMovida;
            };
            btnCerrar.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
            btnRegistrar.Click += delegate (object? sender, EventArgs args) {
                if (ModoEdicionDatos)
                    EditarDatos?.Invoke(sender, args);
                else
                    RegistrarDatos?.Invoke(sender, args);
            };
            btnSalir.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
        }

        public void CargarNombresArticulos(string[] nombresArticulos) {
            fieldNombreArticulo.Items.AddRange(nombresArticulos);
            fieldNombreArticulo.SelectedIndex = -1;
        }

        public void CargarNombresAlmacenes(string[] nombresAlmacenes) {
            fieldNombreAlmacenOrigen.Items.Add("Ninguno");
            fieldNombreAlmacenOrigen.Items.AddRange(nombresAlmacenes);
            fieldNombreAlmacenOrigen.SelectedIndex = 0;

            fieldNombreAlmacenDestino.Items.Add("Ninguno");
            fieldNombreAlmacenDestino.Items.AddRange(nombresAlmacenes);
            fieldNombreAlmacenDestino.SelectedIndex = 0;
        }

        public void CargarMotivos(string[] motivos, bool movPositivo) {
            _movPositivo = movPositivo;

            fieldMotivo.Items.AddRange(motivos);
            fieldMotivo.SelectedIndex = 0;
        }

        public void Mostrar() {
            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            NombreArticulo = string.Empty;
            fieldNombreArticulo.SelectedIndex = -1;
            NombreAlmacenOrigen = string.Empty;
            fieldNombreAlmacenOrigen.SelectedIndex = 0;
            NombreAlmacenDestino = string.Empty;
            fieldNombreAlmacenDestino.SelectedIndex = 0;
            CantidadInicial = 0;
            CantidadMovida = 0;
            Motivo = string.Empty;
            fieldMotivo.SelectedIndex = 0;
            Fecha = DateTime.Now;
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
