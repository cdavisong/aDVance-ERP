using aDVanceERP.Core.Mensajes.MVP.Vistas.Notificacion.Plantillas;
using aDVanceERP.Core.Mensajes.Properties;

using static Guna.UI2.Native.WinApi;

using Timer = System.Windows.Forms.Timer;

namespace aDVanceERP.Core.Mensajes.MVP.Vistas.Notificacion {
    public partial class VistaNotificacion : Form, IVistaNotificacion {
        // Notificacion.
        private bool _esError;
        private Modelos.Notificacion _notificacion;

        // Temporizadores
        private Timer? _timerAnimacion;
        private Timer? _timerVisualizacion;

        // Animaciones
        private Point _posicionObjetivo;
        private int _pasoAnimacion = 10;
        private bool _estaCerrando = false;

        public VistaNotificacion(Modelos.Notificacion notificacion) {
            _notificacion = notificacion;

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

        public string? Mensaje {
            get => fieldMensaje.Text;
            set => fieldMensaje.Text = value;
        }

        public bool EsError {
            get => _esError;
            set { 
                _esError = value;

                //layoutDistribucion1.BackColor = value ? Color.LightSalmon : Color.White;
                fieldIcono.BackgroundImage = value ? Resources.error_96px : Resources.info_96px;
                //fieldMensaje.ForeColor = value ? Color.Firebrick : Color.Gray;                
            }
        }

        public event EventHandler? Salir;

        public void Inicializar() {
            if (_notificacion != null) {
                Mensaje = _notificacion.Mensaje;
                EsError = _notificacion.EsError;
            }

            // Temporizadores
            _timerAnimacion = new Timer();
            _timerAnimacion.Interval = 15; // Aproximadamente 60 FPS
            _timerAnimacion.Tick += delegate { 
                var dx = _posicionObjetivo.X - Left;
                var dy = _posicionObjetivo.Y - Top;
                bool xAlcanzado = false;
                bool yAlcanzado = false;

                // Movimiento horizontal
                if (Math.Abs(dx) >= _pasoAnimacion)
                    Left += (dx > 0 ? _pasoAnimacion : -_pasoAnimacion);
                else {
                    Left = _posicionObjetivo.X;
                    xAlcanzado = true;
                }

                // Movimiento vertical
                if (Math.Abs(dy) >= _pasoAnimacion)
                    Top += (dy > 0 ? _pasoAnimacion : -_pasoAnimacion);
                else {
                    Top = _posicionObjetivo.Y;
                    yAlcanzado = true;
                }

                // Posicion objetivo alcanzada
                if (xAlcanzado && yAlcanzado) {
                    _timerAnimacion.Stop();

                    if (_estaCerrando) {
                        Close();

                        Salir?.Invoke(this, EventArgs.Empty);
                    }
                }
            };

            _timerVisualizacion = new Timer();
            _timerVisualizacion.Interval = _notificacion?.Duracion ?? 3000;
            _timerVisualizacion.Tick += delegate {
                _timerVisualizacion?.Stop();

                Cerrar();
            };

            // Eventos
            Shown += delegate {
                _timerVisualizacion?.Start();
            };
            btnCerrar.Click += delegate (object? sender, EventArgs args) { 
                if (_timerVisualizacion.Enabled)
                    _timerVisualizacion.Stop();

                Cerrar();
            };
        }

        public void Mostrar() {
            BringToFront();
            Show();

            _timerAnimacion?.Start();
        }

        public void ActualizarPosicionObjetivo(Point objetivo) {
            _posicionObjetivo = objetivo;

            if (!(_timerAnimacion?.Enabled ?? false))
                _timerAnimacion?.Start();
        }

        public void EstablecerPosicionObjetivo(Point objetivo) {
            _posicionObjetivo = objetivo;
        }

        public void Ocultar() {
            Hide();
        }

        public void Restaurar() {
            throw new NotImplementedException();
        }

        public void Cerrar() {
            if (!_estaCerrando) {
                _estaCerrando = true;

                // Animamos la salida : deslizamos a la derecha (fuera del área de trabajo)
                var areaTrabajo = Screen.PrimaryScreen?.WorkingArea;

                EstablecerPosicionObjetivo(new Point(areaTrabajo?.Right ?? 1366, Top));

                _timerAnimacion?.Start();
            }
        }
    }
}
