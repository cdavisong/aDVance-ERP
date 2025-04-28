using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.IO;

namespace aDVanceERP.Core.MVP.Vistas.Componentes {
    public partial class Boton : Button {
        private int _grosorBorde = 0;
        private int _radioBorde = 20;
        private Color _colorBorde = Color.PeachPuff;

        public Boton() {
            InitializeComponent();
            InitializeConfiguration();
        }

        public Boton(IContainer container) {
            container.Add(this);

            InitializeComponent();
            InitializeConfiguration();
        }

        public int GrosorBorde { 
            get => _grosorBorde; 
            set {  
                _grosorBorde = value;
                Invalidate();
            } 
        }

        public int RadioBorde {
            get => _radioBorde;
            set {
                _radioBorde = value;
                Invalidate();
            }
        }

        public Color ColorBorde {
            get => _colorBorde;
            set {
                _colorBorde = value;
                Invalidate();
            }
        }

        private void InitializeConfiguration() {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.PeachPuff;
            ForeColor = Color.Black;
            Resize += new EventHandler(Boton_Resize);
        }

        private GraphicsPath ObtenerCaminoFigura(Rectangle rect, int radio) {
            var camino = new GraphicsPath();
            var dimensionesCurva = radio * 2;

            camino.StartFigure();
            camino.AddArc(rect.X, rect.Y, dimensionesCurva, dimensionesCurva, 180, 90);
            camino.AddArc(rect.Right - dimensionesCurva, rect.Y, dimensionesCurva, dimensionesCurva, 270, 90);
            camino.AddArc(rect.Right - dimensionesCurva, rect.Bottom - dimensionesCurva, dimensionesCurva, dimensionesCurva, 0, 90);
            camino.AddArc(rect.X, rect.Bottom - dimensionesCurva, dimensionesCurva, dimensionesCurva, 90, 90);
            camino.CloseFigure();

            return camino;
        }

        protected override void OnPaint(PaintEventArgs pevent) {
            base.OnPaint(pevent);

            var superficieRectangulo = this.ClientRectangle;
            var bordeRectangulo = Rectangle.Inflate(superficieRectangulo, -GrosorBorde, -GrosorBorde);
            var grosorSuavizado = 2;

            if (GrosorBorde > 0)
                grosorSuavizado = GrosorBorde;

            if (RadioBorde > 2) {
                using (GraphicsPath pathSurface = ObtenerCaminoFigura(superficieRectangulo, RadioBorde))
                using (GraphicsPath pathBorder = ObtenerCaminoFigura(bordeRectangulo, RadioBorde - GrosorBorde))
                using (Pen penSurface = new Pen(Parent?.BackColor ?? BackColor, grosorSuavizado))
                using (Pen penBorder = new Pen(ColorBorde, GrosorBorde)) {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    // Superficie del botón
                    this.Region = new Region(pathSurface);
                    // Dibujar superficie del borde para HD
                    pevent.Graphics.DrawPath(penSurface, pathSurface);
                    // Borde del botón
                    if (GrosorBorde >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            } 
            else {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                // Superficie del botón
                this.Region = new Region(superficieRectangulo);
                // Borde del botón
                if (GrosorBorde >= 1) {
                    using (Pen penBorder = new Pen(ColorBorde, GrosorBorde)) {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                    }
                }
            }
        }

        private void Boton_Resize(object? sender, EventArgs e) {
            if (RadioBorde > Height)
                RadioBorde = Height;
        }
    }
}
