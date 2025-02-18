using Guna.UI2.WinForms;

using Manigest.Modulos.Finanzas.MVP.Vistas.Menu.Plantillas;

namespace Manigest.Modulos.Finanzas.MVP.Vistas.Menu {
    public partial class VistaMenuFinanzas : Form, IVistaMenuFinanzas {
        public VistaMenuFinanzas() {
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

        public event EventHandler? VerCuentas;
        public event EventHandler? CambioMenu;
        public event EventHandler? Salir;        

        public void Inicializar() {
            // Eventos
            btnCuentas.Click += delegate (object? sender, EventArgs e) {
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
                    VerCuentas?.Invoke(btnCuentas, e);
                    if (!btnCuentas.Checked)
                        btnCuentas.Checked = true;
                    break;
            }
        }

        public void Mostrar() {
            BringToFront();
            Show();
        }

        public void Restaurar() {
            btnCuentas.Checked = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
