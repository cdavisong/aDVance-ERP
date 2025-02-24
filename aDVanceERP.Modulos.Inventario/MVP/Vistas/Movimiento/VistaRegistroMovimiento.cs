using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento {
    public partial class VistaRegistroMovimiento : Form, IVistaRegistroMovimiento {
        private bool _modoEdicion;

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

        public int CantidadInicialOrigen { get; set; }

        public int CantidadMovida {
            get => int.TryParse(fieldCantidadMovida.Text, out var value) ? value : 0;
            set => fieldCantidadMovida.Text = value.ToString();
        }

        public int CantidadFinalOrigen {
            get => CantidadInicialOrigen - CantidadMovida;
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
            fieldMotivo.SelectedIndexChanged += delegate (object? sender, EventArgs e) {
                ActualizarCamposAlmacenes();
            };
            btnCerrar.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
            btnRegistrar.Click += delegate (object? sender, EventArgs args) {
                if (!MovimientoStockCorrecto())
                    return;

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

        public void CargarMotivos(string[] motivos) {
            fieldMotivo.Items.AddRange(motivos);
            fieldMotivo.SelectedIndex = 0;
        }

        public void ActualizarCamposAlmacenes() {
            if (UtilesMovimientoArticuloAlmacen.MotivoMovimientoPositivo.Contains(Motivo) && !Motivo.Equals("Devolución")) {
                fieldNombreAlmacenOrigen.SelectedIndex = 0;
                fieldNombreAlmacenOrigen.Enabled = false;
                fieldNombreAlmacenDestino.Enabled = true;
            } else if (UtilesMovimientoArticuloAlmacen.MotivoMovimientoNegativo.Contains(Motivo) && !Motivo.Equals("Uso interno")) {
                fieldNombreAlmacenDestino.SelectedIndex = 0;
                fieldNombreAlmacenDestino.Enabled = false;
                fieldNombreAlmacenOrigen.Enabled = true;
            } else {
                fieldNombreAlmacenOrigen.Enabled = true;
                fieldNombreAlmacenDestino.Enabled = true;
            }
        }

        public bool MovimientoStockCorrecto() {
            if (string.IsNullOrEmpty(NombreArticulo))
                return false;

            if (UtilesMovimientoArticuloAlmacen.MotivoMovimientoPositivo.Contains(Motivo)) {
                if (string.Equals(NombreAlmacenDestino, "Ninguno"))
                    return false;
                else return true;
            }

            if (UtilesMovimientoArticuloAlmacen.MotivoMovimientoNegativo.Contains(Motivo) && string.Equals(NombreAlmacenOrigen, "Ninguno"))
                return false;

            CantidadInicialOrigen = UtilesArticulo.ObtenerStockArticulo(NombreArticulo, NombreAlmacenOrigen);

            if (CantidadFinalOrigen < 0) {
                fieldCantidadMovida.ForeColor = Color.Firebrick;
                fieldCantidadMovida.Font = new Font(fieldCantidadMovida.Font, FontStyle.Bold);

                return false;
            }

            return true;
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
            CantidadInicialOrigen = 0;
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
