using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Articulo {
    public partial class VistaTuplaArticulo : Form, IVistaTuplaArticulo {
        public VistaTuplaArticulo() {
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

        public string Id {
            get => fieldId.Text;
            set => fieldId.Text = value;
        }

        public string NombreAlmacen {
            get => fieldNombreAlmacen.Text;
            set => fieldNombreAlmacen.Text = value;
        }

        public string Codigo {
            get => fieldCodigo.Text;
            set => fieldCodigo.Text = value;
        }

        public string Nombre {
            get => fieldNombre.Text;
            set => fieldNombre.Text = value;
        }

        public string Descripcion {
            get => fieldDescripcion.Text;
            set => fieldDescripcion.Text = value;
        }

        public float PrecioAdquisicion {
            get => float.TryParse(fieldPrecioAdquisicion.Text, out var value) ? value : 0;
            set => fieldPrecioAdquisicion.Text = value.ToString();
        }

        public float PrecioCesion {
            get => float.TryParse(fieldPrecioCesion.Text, out var value) ? value : 0;
            set => fieldPrecioCesion.Text = value.ToString();
        }

        public int Stock {
            get => int.TryParse(fieldStock.Text, out var value) ? value : 0;
            set {
                fieldStock.ForeColor = value == 0 ? Color.Firebrick : Color.FromArgb(115, 109, 106);
                fieldStock.Font = new Font(fieldStock.Font, value == 0 ? FontStyle.Bold : FontStyle.Regular);
                fieldStock.Text = value.ToString();
            }
        }

        public Color ColorFondoTupla {
            get => layoutVista.BackColor;
            set => layoutVista.BackColor = value;
        }

        public event EventHandler? TuplaSeleccionada;
        public event EventHandler? MovimientoPositivoStock;
        public event EventHandler? MovimientoNegativoStock;
        public event EventHandler? EditarDatosTupla;
        public event EventHandler? EliminarDatosTupla;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            fieldId.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldNombreAlmacen.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldCodigo.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldNombre.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldDescripcion.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldPrecioAdquisicion.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldPrecioCesion.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldStock.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };

            btnEditar.Click += delegate (object? sender, EventArgs e) {
                EditarDatosTupla?.Invoke(this, e);
            };
            btnMovimientoPositivo.Click += delegate (object? sender, EventArgs e) {
                MovimientoPositivoStock?.Invoke(NombreAlmacen, e);
            };
            btnMovimientoNegativo.Click += delegate (object? sender, EventArgs e) {
                MovimientoNegativoStock?.Invoke(NombreAlmacen, e);
            };
            btnEliminar.Click += async delegate (object? sender, EventArgs e) {
                if (await UtilesArticulo.PuedeEliminarArticulo(long.Parse(Id))) {
                    EliminarDatosTupla?.Invoke(this, e); 
                } else
                    CentroNotificaciones.Mostrar($"No se puede eliminar el artículo {Nombre}, existen registros de movimientos asociados al mismo y podría dañar la integridad y trazabilidad de los datos.", TipoNotificacion.Advertencia);
            };
        }

        public void Mostrar() {
            VerificarPermisos();
            BringToFront();
            Show();
        }

        private void VerificarPermisos() {
            btnMovimientoPositivo.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_MOVIMIENTOS_ADICIONAR")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_MOVIMIENTOS_TODOS")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_TODOS");
            btnMovimientoNegativo.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_MOVIMIENTOS_ADICIONAR")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_MOVIMIENTOS_TODOS")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_TODOS");
            btnEditar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_ARTICULOS_EDITAR")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_ARTICULOS_TODOS")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_TODOS");
        }

        public void Restaurar() {
            ColorFondoTupla = BackColor;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
