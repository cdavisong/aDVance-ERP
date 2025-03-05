using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Menu.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Menu {
    public partial class VistaMenuContacto : Form, IVistaMenuContacto {
        public VistaMenuContacto() {
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

        public event EventHandler? VerProveedores;
        public event EventHandler? VerClientes;
        public event EventHandler? VerContactos;
        public event EventHandler? CambioMenu;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            btnProveedores.Click += delegate (object? sender, EventArgs e) {
                PresionarBotonSeleccion(1, e);
            };
            btnClientes.Click += delegate (object? sender, EventArgs e) {
                PresionarBotonSeleccion(2, e);
            };
            btnContactos.Click += delegate (object? sender, EventArgs e) {
                PresionarBotonSeleccion(3, e);
            };
        }

        public void PresionarBotonSeleccion(object? sender, EventArgs e) {
            var indiceValido = int.TryParse(sender?.ToString() ?? string.Empty, out var indice);

            if (!indiceValido)
                return;

            CambioMenu?.Invoke(sender, e);

            switch (indice) {
                case 1:
                    VerProveedores?.Invoke(btnProveedores, e);
                    if (!btnProveedores.Checked)
                        btnProveedores.Checked = true;
                    break;
                case 2:
                    VerClientes?.Invoke(btnClientes, e);
                    if (!btnClientes.Checked)
                        btnClientes.Checked = true;
                    break;
                case 3:
                    VerContactos?.Invoke(btnContactos, e);
                    if (!btnContactos.Checked)
                        btnContactos.Checked = true;
                    break;
            }
        }

        public void Mostrar() {
            VerificarPermisos();
            BringToFront();
            Show();
        }

        private void VerificarPermisos() {
            btnProveedores.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoParcial("MOD_CONTACTO_PROVEEDORES")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_CONTACTO_TODOS"); ;
            btnClientes.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoParcial("MOD_CONTACTO_CLIENTES")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_CONTACTO_TODOS"); ;
            btnContactos.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoParcial("MOD_CONTACTO_CONTACTOS")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_CONTACTO_TODOS"); ;
        }

        public void Restaurar() {
            btnProveedores.Checked = false;
            btnClientes.Checked = false;
            btnContactos.Checked = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
