using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Menu.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Menu {
    public partial class VistaMenuCompraventas : Form, IVistaMenuVentas {
        public VistaMenuCompraventas() {
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

        public event EventHandler? VerCompras;
        public event EventHandler? VerVentas;
        public event EventHandler? CambioMenu;
        public event EventHandler? Salir;


        public void Inicializar() {
            // Eventos
            btnCompra.Click += delegate (object? sender, EventArgs e) {
                PresionarBotonSeleccion(1, e);
            };
            btnVenta.Click += delegate (object? sender, EventArgs e) {
                PresionarBotonSeleccion(2, e);
            };
        }

        public void PresionarBotonSeleccion(object? sender, EventArgs e) {
            var indiceValido = int.TryParse(sender?.ToString() ?? string.Empty, out var indice);

            if (!indiceValido)
                return;

            CambioMenu?.Invoke(sender, e);

            switch (indice) {
                case 1:
                    VerCompras?.Invoke(btnCompra, e);
                    if (!btnCompra.Checked)
                        btnCompra.Checked = true;
                    break;
                case 2:
                    VerVentas?.Invoke(btnVenta, e);
                    if (!btnVenta.Checked)
                        btnVenta.Checked = true;
                    break;
            }
        }

        public void Mostrar() {
            VerificarPermisos();
            BringToFront();
            Show();
        }

        private void VerificarPermisos() {
            btnCompra.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoParcial("MOD_COMPRAVENTA_COMPRA")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_COMPRAVENTA_COMPRA");
            btnVenta.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoParcial("MOD_COMPRAVENTA_VENTA")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_COMPRAVENTA_TODOS");
        }

        public void Restaurar() {
            btnVenta.Checked = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
