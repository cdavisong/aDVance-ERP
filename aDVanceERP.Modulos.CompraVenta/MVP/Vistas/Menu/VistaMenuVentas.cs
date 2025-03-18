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

        public event EventHandler? VerVentas;
        public event EventHandler? CambioMenu;
        public event EventHandler? Salir;


        public void Inicializar() {
            // Eventos
            btnVenta.Click += delegate (object? sender, EventArgs e) {
                PresionarBotonSeleccion(1, e);
            };
        }

        public void PresionarBotonSeleccion(object? sender, EventArgs e) {
            var indiceValido = int.TryParse(sender?.ToString() ?? string.Empty, out var indice);

            if (!indiceValido)
                return;

            CambioMenu?.Invoke(sender, e);

            switch (indice) {
                case 1:
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
            btnVenta.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoParcial("MOD_VENTAS_ARTICULOS")
                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_VENTAS_TODOS");
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
