using aDVanceERP.Core.Seguridad.MVP.Vistas.Menu.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Menu {
    public partial class VistaMenuSeguridad : Form, IVistaMenuSeguridad {
        public VistaMenuSeguridad() {
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

        public event EventHandler? VerCuentasUsuarios;
        public event EventHandler? CambioMenu;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            btnUsuarios.Click += delegate (object? sender, EventArgs e) {
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
                    VerCuentasUsuarios?.Invoke(btnUsuarios, e);
                    if (!btnUsuarios.Checked)
                        btnUsuarios.Checked = true;
                    break;
            }
        }

        public void Mostrar() {
            BringToFront();
            Show();
        }

        public void Restaurar() {
            btnUsuarios.Checked = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
