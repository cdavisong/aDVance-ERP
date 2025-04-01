using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero.Plantillas;
using aDVanceERP.Modulos.Contactos.Properties;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero {
    public partial class VistaTuplaMensajero : Form, IVistaTuplaMensajero {
        private bool _activo;

        public VistaTuplaMensajero() {
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

        public string Nombre {
            get => fieldNombre.Text;
            set => fieldNombre.Text = value;
        }

        public string Telefonos {
            get => fieldTelefonos.Text;
            set => fieldTelefonos.Text = value;
        }

        public string Direccion {
            get => fieldDireccion.Text;
            set {
                fieldDireccion.Text = value;
                fieldDireccion.Margin = new Padding(1, value?.Length > 43 ? 10 : 1, 1, 1);
            }
        }

        public bool Activo {
            get => _activo;
            set {
                _activo = value;
                fieldActivo.Image = value ? Resources.active_state_20px : Resources.inactive_state_20px;
            }
        }

        public Color ColorFondoTupla {
            get => layoutVista.BackColor;
            set => layoutVista.BackColor = value;
        }

        public event EventHandler? TuplaSeleccionada;
        public event EventHandler? EditarDatosTupla;
        public event EventHandler? EliminarDatosTupla;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            fieldId.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldNombre.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldTelefonos.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldDireccion.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldActivo.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };

            btnEditar.Click += delegate (object? sender, EventArgs e) {
                EditarDatosTupla?.Invoke(this, e);
            };
            btnEliminar.Click += delegate (object? sender, EventArgs e) {
                EliminarDatosTupla?.Invoke(this, e);
            };
        }

        public void Mostrar() {
            VerificarPermisos();
            BringToFront();
            Show();
        }

        private void VerificarPermisos() {
            if (UtilesCuentaUsuario.UsuarioAutenticado == null || UtilesCuentaUsuario.PermisosUsuario == null) {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                return;
            }

            btnEditar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_CONTACTO_MENSAJEROS_EDITAR")
                                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_CONTACTO_MENSAJEROS_TODOS")
                                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_CONTACTO_TODOS");
            btnEliminar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                                  || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_CONTACTO_MENSAJEROS_ELIMINAR")
                                  || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_CONTACTO_MENSAJEROS_TODOS")
                                  || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_CONTACTO_TODOS");
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
