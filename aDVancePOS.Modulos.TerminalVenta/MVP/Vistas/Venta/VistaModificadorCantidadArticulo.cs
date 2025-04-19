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
            btnEliminar.Click += delegate(object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
            fieldCantidad.Leave += delegate {
                if (fieldCantidad.Text.StartsWith("."))
                    fieldCantidad.Text = @"0" + fieldCantidad.Text;
                else if (fieldCantidad.Text == @"-.") 
                    fieldCantidad.Text = @"-0.";
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
            btnSimboloMenos.Click += delegate {
                AdicionarCaracterTeclado(btnSimboloMenos);
            };
            btnPuntoDecimal.Click += delegate {
                AdicionarCaracterTeclado(btnPuntoDecimal);
            };
        }

        private void AdicionarCaracterTeclado(Guna2Button btnCaracter) {
            var textoCantidad = fieldCantidad.Text;

            if (textoCantidad.Where(char.IsDigit).Count() <= 11)
                fieldCantidad.Text += btnCaracter.Text;

            switch (btnCaracter.Name) {
                case "btnSimboloMenos":
                    fieldCantidad.Text = textoCantidad.StartsWith("-") ? textoCantidad[1..] : $@"-{textoCantidad}";
                    break;
                case "btnPuntoDecimal": {
                    if (textoCantidad.Contains('.') || string.IsNullOrEmpty(fieldCantidad.Text))
                        fieldCantidad.Text += @".";
                    break;
                }
            }
        }

        public void Mostrar() {
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
