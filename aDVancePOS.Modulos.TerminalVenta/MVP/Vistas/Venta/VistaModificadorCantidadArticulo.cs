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
            fieldCantidad.KeyDown += delegate (object? sender, KeyEventArgs args) {
                switch (args.KeyCode) {
                    case Keys.Enter or Keys.Escape:
                        if (args.KeyCode == Keys.Escape)
                            CantidadArticulo = 1;

                        Salir?.Invoke(sender, args);

                        Cerrar();
                        break;
                    case Keys.Back or Keys.Delete:
                        AdicionarCaracterTeclado(btnEliminar);
                        break;
                    case Keys.D0 or Keys.NumPad0:
                        AdicionarCaracterTeclado(btnNumero0);
                        break;
                    case Keys.D1 or Keys.NumPad1:
                        AdicionarCaracterTeclado(btnNumero1);
                        break;
                    case Keys.D2 or Keys.NumPad2:
                        AdicionarCaracterTeclado(btnNumero2);
                        break;
                    case Keys.D3 or Keys.NumPad3:
                        AdicionarCaracterTeclado(btnNumero3);
                        break;
                    case Keys.D4 or Keys.NumPad4:
                        AdicionarCaracterTeclado(btnNumero4);
                        break;
                    case Keys.D5 or Keys.NumPad5:
                        AdicionarCaracterTeclado(btnNumero5);
                        break;
                    case Keys.D6 or Keys.NumPad6:
                        AdicionarCaracterTeclado(btnNumero6);
                        break;
                    case Keys.D7 or Keys.NumPad7:
                        AdicionarCaracterTeclado(btnNumero7);
                        break;
                    case Keys.D8 or Keys.NumPad8:
                        AdicionarCaracterTeclado(btnNumero0);
                        break;
                    case Keys.D9 or Keys.NumPad9:
                        AdicionarCaracterTeclado(btnNumero9);
                        break;
                }

                args.SuppressKeyPress = true;
            };
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
            btnIntro.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);

                Cerrar();
            };

            fieldCantidad.Focus();
        }

        private void AdicionarCaracterTeclado(Guna2Button btnCaracter) {
            var textoCantidad = fieldCantidad.Text;

            if (textoCantidad.Length == 0)
                textoCantidad = "1";

            if (textoCantidad.Where(char.IsDigit).Count() <= 11)
                fieldCantidad.Text += btnCaracter.Text;

            switch (btnCaracter.Name) {
                case "btnEliminar":
                    fieldCantidad.Text = textoCantidad[..^1];
                    break;
            }

            // Enfocar el campo cantidad
            fieldCantidad.Focus();

            // Colocar el cursor al final
            fieldCantidad.SelectionStart = fieldCantidad.Text.Length;
            fieldCantidad.SelectionLength = 0; // Sin texto seleccionado
        }

        public void Mostrar() {
            fieldCantidad.Focus();

            Habilitada = true;
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
