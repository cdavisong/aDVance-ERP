using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Empresa.Plantillas;
using aDVanceERP.Modulos.Contactos.Properties;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Empresa {
    public partial class VistaRegistroEmpresa : Form, IVistaRegistroEmpresa {
        private bool _modoEdicion;

        public VistaRegistroEmpresa() {
            InitializeComponent();
            Inicializar();
        }

        public bool Habilitar {
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

        public Image? Logotipo {
            get => fieldLogotipo.BackgroundImage;
            set {
                var imagen = new Bitmap(100, 100);
                var logotipo = value.ObtenerRecorteImagen100x100();

                using (var g = Graphics.FromImage(imagen)) {
                    g.Clear(Color.White);
                    g.DrawImage(logotipo, 0, 0, 100, 100);
                    g.DrawImage(Resources.mascara, 0, 0, 100, 100);
                }
                
                fieldLogotipo.BackgroundImage = imagen; 
            }
        }

        public string Nombre {
            get => fieldNombre.Text;
            set => fieldNombre.Text = value;
        }

        public string TelefonoMovil {
            get => fieldTelefonoMovil.Text;
            set => fieldTelefonoMovil.Text = value;
        }

        public string TelefonoFijo {
            get => fieldTelefonoFijo.Text;
            set => fieldTelefonoFijo.Text = value;
        }

        public string CorreoElectronico {
            get => fieldCorreoElectronico.Text;
            set => fieldCorreoElectronico.Text = value;
        }

        public string Direccion {
            get => fieldDireccion.Text;
            set {
                fieldDireccion.Text = value;
                fieldDireccion.Margin = new Padding(1, value?.Length > 43 ? 10 : 1, 1, 1);
            }
        }

        public bool ModoEdicion {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnRegistrar.Text = value ? "Actualizar empresa" : "Registrar empresa";
                _modoEdicion = value;
            }
        }

        public event EventHandler? Registrar;
        public event EventHandler? Editar;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            btnCerrar.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
            fieldLogotipo.Click += delegate {
                buscadorImagen.ShowDialog();

                if (!string.IsNullOrEmpty(buscadorImagen.FileName))
                    Logotipo = Image.FromFile(buscadorImagen.FileName);
            };
            btnRegistrar.Click += delegate (object? sender, EventArgs args) {
                if (ModoEdicion)
                    Editar?.Invoke(sender, args);
                else
                    Registrar?.Invoke(sender, args);
            };
            btnSalir.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
        }

        public void Mostrar() {
            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            Nombre = string.Empty;
            TelefonoMovil = string.Empty;
            TelefonoFijo = string.Empty;
            CorreoElectronico = string.Empty;
            Direccion = string.Empty;
            ModoEdicion = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Dispose() {
            base.Dispose();
        }
    }
}
