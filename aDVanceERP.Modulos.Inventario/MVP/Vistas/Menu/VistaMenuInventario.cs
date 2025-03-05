using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Menu.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Menu {
    public partial class VistaMenuInventario : Form, IVistaMenuInventario {
        public VistaMenuInventario() {
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

        public event EventHandler? VerArticulos;
        public event EventHandler? VerMovimientos;
        public event EventHandler? VerAlmacenes;
        public event EventHandler? CambioMenu;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            btnArticulos.Click += delegate (object? sender, EventArgs e) {
                PresionarBotonSeleccion(1, e);
            };
            btnMovimientos.Click += delegate (object? sender, EventArgs e) {
                PresionarBotonSeleccion(2, e);
            };
            btnAlmacenes.Click += delegate (object? sender, EventArgs e) {
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
                    VerArticulos?.Invoke(btnArticulos, e);
                    if (!btnArticulos.Checked)
                        btnArticulos.Checked = true;
                    break;
                case 2:
                    VerMovimientos?.Invoke(btnMovimientos, e);
                    if (!btnMovimientos.Checked)
                        btnMovimientos.Checked = true;
                    break;
                case 3:
                    VerAlmacenes?.Invoke(btnAlmacenes, e);
                    if (!btnAlmacenes.Checked)
                        btnAlmacenes.Checked = true;
                    break;
            }
        }

        public void Mostrar() {
            VerificarPermisos();
            BringToFront();
            Show();
        }

        private void VerificarPermisos() {
            btnArticulos.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoParcial("MOD_INVENTARIO_ARTICULOS")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_TODOS");
            btnMovimientos.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoParcial("MOD_INVENTARIO_MOVIMIENTOS")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_TODOS");
            btnAlmacenes.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoParcial("MOD_INVENTARIO_ALMACENES")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_TODOS");
        }

        public void Restaurar() {
            btnArticulos.Checked = false;
            btnAlmacenes.Checked = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
