using aDVanceERP.Core.MVP.Vistas.PanelTransparente.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Utiles;

namespace aDVanceERP.Core.MVP.Vistas.PanelTransparente {
    public partial class VistaPanelTransparente : Form, IVistaPanelTransparente {
        public VistaPanelTransparente(IVista parent) {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.Black;
            Opacity = 0.7;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;

            var resolucionPantalla = Screen.PrimaryScreen?.Bounds.Size ?? Size.Empty;

            Size = new Size(resolucionPantalla.Width, resolucionPantalla.Height - VariablesGlobales.AlturaBarraTituloPredeterminada);
            Location = new Point(0, VariablesGlobales.AlturaBarraTituloPredeterminada);

            var parentControl = parent as Control;

            if (parentControl != null) {
                parentControl.Disposed += delegate {
                    if (!parentControl.IsDisposed)
                        Cerrar();
                };                
            }

            parent.Salir += delegate {
                if (parentControl != null && !parentControl.IsDisposed)
                    Cerrar();
                else if (parentControl == null)
                    Cerrar();
            };

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

        public event EventHandler? Salir;

        public void Inicializar() {
            
        }

        public void Mostrar() {
            BringToFront();
            Show();
        }

        public void Restaurar() {
            //...
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
