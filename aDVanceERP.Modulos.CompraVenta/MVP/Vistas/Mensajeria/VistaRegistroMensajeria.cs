using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Mensajeria.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Mensajeria {
    public partial class VistaRegistroMensajeria : Form, IVistaRegistroMensajeria {
        private bool _modoEdicion;
        private string _nombreCliente = string.Empty;
        private string _telefonosCliente = string.Empty;
        private string[] _descripcionesTiposEntrega = Array.Empty<string>();
        private List<string[]>? _articulosVenta = new();

        public VistaRegistroMensajeria() {
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

        public string? NombreMensajero {
            get => fieldNombreMensajero.Text;
            set => fieldNombreMensajero.Text = value;
        }

        public string? TipoEntrega {
            get => fieldTipoEntrega.Text;
            set => fieldTipoEntrega.Text = value;
        }

        public string DescripcionTipoEntrega {
            get => fieldDescripcionTipoEntrega.Text;
            set => fieldDescripcionTipoEntrega.Text = value;
        }

        public string Direccion {
            get => fieldDireccion.Text;
            set {
                fieldDireccion.Text = value;
                fieldDireccion.Margin = new Padding(1, value?.Length > 43 ? 10 : 1, 1, 1);
            }
        }

        public string ResumenEntrega {
            get => fieldResumenEntrega.Text;
            set => fieldResumenEntrega.Text = value;
        }

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnRegistrar.Text = value ? "Actualizar contacto" : "Registrar contacto";
                _modoEdicion = value;
            }
        }

        public List<string[]> DatosMensajeria { get; private set; }

        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        public void Inicializar() {
            DatosMensajeria = new List<string[]>();

            // Eventos
            btnCerrar.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
            fieldNombreMensajero.SelectedIndexChanged += delegate {
                ActualizarResumenEntrega();
            };
            fieldTipoEntrega.SelectedIndexChanged += delegate {
                DescripcionTipoEntrega = _descripcionesTiposEntrega[fieldTipoEntrega.SelectedIndex];

                ActualizarResumenEntrega();
            };
            btnRegistrar.Click += delegate (object? sender, EventArgs args) {
                if (string.IsNullOrEmpty(TipoEntrega) || TipoEntrega.Equals("Presencial")) {
                    CentroNotificaciones.Mostrar(
                        "El tipo de entrega para una mensajería no puede ser nulo o del tipo presencial, rectifique los datos proporcionados.");

                    return;
                }

                if (ModoEdicionDatos)
                    EditarDatos?.Invoke(sender, args);
                else
                    Salir?.Invoke(sender, args);
            };
            btnSalir.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
        }

        public void CargarNombresMensajeros(object[] nombresMensajeros) {
            fieldNombreMensajero.Items.Clear();
            fieldNombreMensajero.Items.AddRange(nombresMensajeros);
            fieldNombreMensajero.SelectedIndex = -1;
        }

        public void CargarTiposEntrega(object[] tiposEntrega, string[] descripciones) {
            fieldTipoEntrega.Items.Clear();
            fieldTipoEntrega.Items.AddRange(tiposEntrega);
            fieldTipoEntrega.SelectedIndex = -1;

            _descripcionesTiposEntrega = descripciones;
        }

        public void PopularDatosCliente(string[]? datosCliente) {
            _nombreCliente = datosCliente[0];
            _telefonosCliente = datosCliente[1];

            Direccion = datosCliente[2];
        }

        public void PopularArticulosVenta(List<string[]>? datosArticulos) {
            _articulosVenta = datosArticulos;

            ActualizarResumenEntrega();
        }

        private void ActualizarResumenEntrega() {
            string resumenHtml = $@"
<div class='resumen-entrega'>
    <h3>Entrega #{UtilesBD.ObtenerUltimoIdTabla("seguimiento_entrega") + 1:000}</h3>
    <p><strong>Fecha:</strong> {DateTime.Now:yyyy-MM-dd}</p>
    
    <div class='seccion-cliente' style='margin-bottom: 10px;'>
        <h4 style='margin-bottom: 5px;'>Datos del cliente</h4>
        <hr style='margin: 5px 0;'>
        <p style='margin: 2px 0;'><strong>Nombre:</strong> {_nombreCliente}</p>
        <p style='margin: 2px 0;'><strong>Teléfonos:</strong> {_telefonosCliente}</p>
        <p style='margin: 2px 0;'><strong>Dirección:</strong> {Direccion}</p>
    </div>
    
    <div class='seccion-articulos'>
        <h4 style='margin-bottom: 5px;'>Artículos</h4>
        <hr style='margin: 5px 0;'>";

            if (_articulosVenta != null) {
                resumenHtml = _articulosVenta.Aggregate(resumenHtml,
                    (current, articulo) => current + $@"
        <p style='margin: 2px 0;'><strong>{articulo[4]}</strong> - {articulo[1]}</p>");
            }

            resumenHtml += @"
    </div>
</div>";

            ResumenEntrega = resumenHtml;

            ActualizarDatosMensajeria();
        }

        private void ActualizarDatosMensajeria() {
            DatosMensajeria.Clear();
            DatosMensajeria.Add(new[]{ NombreMensajero ?? string.Empty });
            DatosMensajeria.Add(new[] { TipoEntrega ?? string.Empty });
            DatosMensajeria.Add(new[] { _nombreCliente, _telefonosCliente, Direccion });
        }

        public void Mostrar() {
            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            NombreMensajero = string.Empty;
            fieldNombreMensajero.SelectedIndex = -1;
            TipoEntrega = string.Empty;
            fieldTipoEntrega.SelectedIndex = -1;
            DescripcionTipoEntrega = "...";
            Direccion = string.Empty;
            ResumenEntrega = "...";
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
