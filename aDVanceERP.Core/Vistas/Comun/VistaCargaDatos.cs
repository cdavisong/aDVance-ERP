
using aDVanceERP.Core.Properties;
using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.Vistas.Comun {
    public partial class VistaCargaDatos : Form, IVistaBase {
        private const string _icono = "pX_48px";
        private int _iconoActual = 1;
        private System.Windows.Forms.Timer _timerIconoCarga;

        public VistaCargaDatos() {
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

        public void Inicializar() {
            _timerIconoCarga = new System.Windows.Forms.Timer();
            _timerIconoCarga.Interval = 42;
            _timerIconoCarga.Tick += ActualizarIconoCarga;
        }

        public void Mostrar() {
            Show();
            BringToFront();

            _timerIconoCarga.Start();
        }

        public void Ocultar() {
            _timerIconoCarga.Stop();

            Invoke(Hide);
        }

        public void Restaurar() {
            _timerIconoCarga.Stop();
        }

        public void Cerrar() {
            _timerIconoCarga.Stop();
            _timerIconoCarga.Tick -= ActualizarIconoCarga;
            Close();
        }

        private void ActualizarIconoCarga(object? sender, EventArgs e) {
            _iconoActual = _iconoActual == 8 ? 1 : ++_iconoActual;

            var numeroImagen = _iconoActual;
            var nombreImagen = _icono.Replace("X", numeroImagen.ToString());
            var imagen = (Image)Resources.ResourceManager.GetObject(nombreImagen);

            Invoke(new Action(() => {
                fieldIconoCarga.BackgroundImage = imagen;
            }));
        }
    }
}
