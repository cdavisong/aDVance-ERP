using aDVanceERP.Core.ClienteFTP.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.ClienteFTP.MVP.Vistas; 

public partial class VistaConfServidorFTP : Form, IVistaConfServidorFTP {
    public VistaConfServidorFTP() {
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

    public string Servidor {
        get => fieldServidor.Text;
        set => fieldServidor.Text = value;
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
        btnAlmacenarConfiguracion.Click += delegate(object? sender, EventArgs args) {
            AlmacenarConfiguracion?.Invoke(sender, args);
        };
        btnSalir.Click += delegate(object? sender, EventArgs args) {
            Salir?.Invoke(sender, args);
            Ocultar();
        };
    }

    public void Mostrar() {
        BringToFront();
        Show();
    }

    public void Restaurar() {
        //var confServidorFTP = UtilesConfServidores.ObtenerConfServidorFTP();

        //if (confServidorFTP == null)
        //    return;

        //Servidor = confServidorFTP.ElementAt(0);
        //Usuario = confServidorFTP.ElementAt(1);
        //Password = confServidorFTP.ElementAt(2);
    }

    public void Ocultar() {
        Hide();
    }

    public void Dispose() {
        // ...
    }
}