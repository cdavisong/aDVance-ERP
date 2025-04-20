using aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta.Plantillas;
using Guna.UI2.WinForms;

namespace aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta {
    public partial class VistaModificadorCantidadArticulo : Form, IVistaModificadorCantidadArticulo {
        public VistaModificadorCantidadArticulo() {
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

        public int CantidadArticulo {
            get => int.TryParse(fieldCantidad.Text, out var cantidad) ? cantidad : 1;
            set => fieldCantidad.Text = value.ToString();
        }

        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            fieldCantidad.Focus();
            btnNumero0.Click += delegate {
                AdicionarCaracterTeclado(btnNumero0);
            };
            btnNumero1.Click += delegate {
                AdicionarCaracterTeclado(btnNumero1);
            };
            btnNumero2.Click += delegate {
                AdicionarCaracterTeclado(btnNumero2);
            };
            btnNumero3.Click += delegate {
                AdicionarCaracterTeclado(btnNumero3);
            };
            btnNumero4.Click += delegate {
                AdicionarCaracterTeclado(btnNumero4);
            };
            btnNumero5.Click += delegate {
                AdicionarCaracterTeclado(btnNumero5);
            };
            btnNumero6.Click += delegate {
                AdicionarCaracterTeclado(btnNumero6);
            };
            btnNumero7.Click += delegate {
                AdicionarCaracterTeclado(btnNumero7);
            };
            btnNumero8.Click += delegate {
                AdicionarCaracterTeclado(btnNumero8);
            };
            btnNumero9.Click += delegate {
                AdicionarCaracterTeclado(btnNumero9);
            };
            btnEliminar.Click += delegate {
                AdicionarCaracterTeclado(btnEliminar);
            };
            btnEscape.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);

                Cerrar();
            };
        }

        private void AdicionarCaracterTeclado(Guna2Button btnCaracter) {
            var textoCantidad = fieldCantidad.Text;

            if (textoCantidad.Where(char.IsDigit).Count() <= 11)
                fieldCantidad.Text += btnCaracter.Text;

            switch (btnCaracter.Name) {
                case "btnEliminar":
                    fieldCantidad.Text = textoCantidad[..^1];
                    break;
            }

            fieldCantidad.Focus();
        }

        public void Mostrar() {
            fieldCantidad.Focus();

            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            CantidadArticulo = 1;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
