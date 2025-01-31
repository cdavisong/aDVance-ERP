using Manigest.Core.ClienteMySQL.MVP.Presentadores;
using Manigest.Core.ClienteMySQL.MVP.Vistas.Plantillas;
using Manigest.Core.Utiles;

namespace Manigest.Core.ClienteMySQL.MVP.Vistas {
    public partial class VistaConfServidorMySQL : Form, IVistaConfServidorMySQL {
        public VistaConfServidorMySQL() {
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

        public string Servidor {
            get => fieldServidor.Text;
            set => fieldServidor.Text = value;
        }

        public string BaseDatos {
            get => fieldBaseDatos.Text;
            set => fieldBaseDatos.Text = value;
        }

        public string Usuario {
            get => fieldNombreUsuario.Text;
            set => fieldNombreUsuario.Text = value;
        }

        public string Password {
            get => fieldPassword.Text;
            set => fieldPassword.Text = value;
        }

        public event EventHandler? AlmacenarConfiguracion;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            btnAlmacenarConfiguracion.Click += delegate (object? sender, EventArgs args) { 
                AlmacenarConfiguracion?.Invoke(sender, args); 
            };
            btnSalir.Click += delegate (object? sender, EventArgs args) { 
                Salir?.Invoke(sender, args); 
                Ocultar(); 
            };
        }

        public void Mostrar() {
            BringToFront();
            Show();
        }

        public void Restaurar() {
            var confServidorMySQL = UtilesConfServidores.ObtenerConfServidorMySQL();

            if (confServidorMySQL == null)
                return;

            Servidor = confServidorMySQL.ElementAt(0);
            BaseDatos = confServidorMySQL.ElementAt(1);
            Usuario = confServidorMySQL.ElementAt(2);
            Password = confServidorMySQL.ElementAt(3);
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            // ...
        }
    }
}
