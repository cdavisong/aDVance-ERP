using aDVanceERP.Core.Repositorios;
using aDVanceERP.Core.Repositorios.Plantillas;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Desktop.MVP.Vistas.ContenedorModulos.Plantillas;
using aDVanceERP.Modulos.CompraVenta;
using aDVanceERP.Modulos.Contactos;
using aDVanceERP.Modulos.Finanzas;
using aDVanceERP.Modulos.Inventario;
using aDVanceERP.Modulos.Taller;

namespace aDVanceERP.Desktop.MVP.Vistas.ContenedorModulos;

public partial class VistaContenedorModulos : Form, IVistaContenedorModulos {
    public VistaContenedorModulos() {
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

    public int AlturaContenedorVistas {
        get => contenedorVistas.Height;
    }

    public int TuplasMaximasContenedor {
        get => AlturaContenedorVistas / VariablesGlobales.AlturaTuplaPredeterminada;
    }

    //public bool BtnModuloAdministracionVisible {
    //    get => btnModuloAdministracion.Visible;
    //    set => btnModuloAdministracion.Visible = value;
    //}

    public IRepositorioVista? Vistas { get; private set; }

    public event EventHandler? MostrarVistaInicio;
    public event EventHandler? MostrarVistaEstadisticas;
    public event EventHandler? MostrarMenuContactos;
    public event EventHandler? MostrarMenuFinanzas;
    public event EventHandler? MostrarMenuInventario;
    public event EventHandler? MostrarMenuTaller;
    public event EventHandler? MostrarMenuVentas;
    public event EventHandler? MostrarMenuSeguridad;
    public event EventHandler? CambioModulo;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Propiedades locales
        Vistas = new RepositorioVistaBase(contenedorVistas);
        btnInicio.Checked = true;

        // Eventos
        btnInicio.Click += delegate (object? sender, EventArgs e) { PresionarBotonModulo(1, e); };
        btnEstadisticas.Click += delegate (object? sender, EventArgs e) { PresionarBotonModulo(2, e); };
        btnModuloContactos.Click += delegate (object? sender, EventArgs e) { PresionarBotonModulo(3, e); };
        btnModuloFinanzas.Click += delegate (object? sender, EventArgs e) { PresionarBotonModulo(4, e); };
        btnModuloInventario.Click += delegate (object? sender, EventArgs e) { PresionarBotonModulo(5, e); };
        btnModuloTaller.Click += delegate (object? sender, EventArgs e) { PresionarBotonModulo(8, e); };
        btnModuloVentas.Click += delegate (object? sender, EventArgs e) { PresionarBotonModulo(6, e); };
        btnModuloSeguridad.Click += delegate (object? sender, EventArgs e) { PresionarBotonModulo(7, e); };
        CambioModulo += delegate { Restaurar(); };

        MostrarMensajePortada();
    }

    public void PresionarBotonModulo(object? sender, EventArgs e) {
        var indiceValido = int.TryParse(sender?.ToString() ?? string.Empty, out var indice);

        if (!indiceValido)
            return;

        CambioModulo?.Invoke(sender, e);

        switch (indice) {
            case 1:
                MostrarVistaInicio?.Invoke(btnInicio, e);
                if (!btnInicio.Checked)
                    btnInicio.Checked = true;
                break;
            case 2:
                MostrarVistaEstadisticas?.Invoke(btnEstadisticas, e);
                if (!btnEstadisticas.Checked)
                    btnEstadisticas.Checked = true;
                break;
            case 3:
                MostrarMenuContactos?.Invoke(btnModuloContactos, e);
                if (!btnModuloContactos.Checked)
                    btnModuloContactos.Checked = true;
                break;
            case 4:
                MostrarMenuFinanzas?.Invoke(btnModuloFinanzas, e);
                if (!btnModuloFinanzas.Checked)
                    btnModuloFinanzas.Checked = true;
                break;
            case 5:
                MostrarMenuInventario?.Invoke(btnModuloInventario, e);
                if (!btnModuloInventario.Checked)
                    btnModuloInventario.Checked = true;
                break;
            case 6:
                MostrarMenuVentas?.Invoke(btnModuloVentas, e);
                if (!btnModuloVentas.Checked)
                    btnModuloVentas.Checked = true;
                break;
            case 7:
                MostrarMenuSeguridad?.Invoke(btnModuloSeguridad, e);
                if (!btnModuloSeguridad.Checked)
                    btnModuloSeguridad.Checked = true;
                break;
            case 8:
                MostrarMenuTaller?.Invoke(btnModuloTaller, e);
                if (!btnModuloTaller.Checked)
                    btnModuloTaller.Checked = true;
                break;
        }
    }

    public void Mostrar() {
        btnEstadisticas.Visible = false;//UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false;
        btnModuloContactos.Visible = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false) ||
                                     (UtilesCuentaUsuario.PermisosUsuario?.ContienePermisoParcial(ModuloContactos.Nombre) ?? false);
        btnModuloFinanzas.Visible = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false) ||
                                    (UtilesCuentaUsuario.PermisosUsuario?.ContienePermisoParcial(ModuloFinanzas.Nombre) ?? false);
        btnModuloInventario.Visible = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false) ||
                                      (UtilesCuentaUsuario.PermisosUsuario?.ContienePermisoParcial(ModuloInventario.Nombre) ?? false);
        btnModuloInventario.Visible = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false) ||
                                     (UtilesCuentaUsuario.PermisosUsuario?.ContienePermisoParcial(ModuloTaller.Nombre) ?? false);
        btnModuloVentas.Visible = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false) ||
                                  (UtilesCuentaUsuario.PermisosUsuario?.ContienePermisoParcial(ModuloCompraventa.Nombre) ?? false);
        btnModuloSeguridad.Visible = UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false;

        BringToFront();
        Show();
    }

    private void MostrarMensajePortada() {
        var version = "v0.0.0.1-alpha"; // Valor por defecto

        if (File.Exists(@".\app.ver"))
            using (var fs = new FileStream(@".\app.ver", FileMode.Open)) {
                using (var sr = new StreamReader(fs)) {
                    version = sr.ReadToEnd().Trim();
                }
            }

        var textoHTML = @"
            <!DOCTYPE html>
            <html lang=""es"">
            <head>
                <meta charset=""UTF-8"">
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <style>
                    body {
                        font-family: Segoe UI, sans-serif;
                        text-align: center;
                        padding: 10px;
                    }
                    .header {
                        color: #FFFFFF;
                        padding: 20px;
                        border-radius: 8px;
                    }
                    .logo {
                        font-family: Segoe UI, sans-serif;
                        font-size: 24px; /* Tamaño de fuente ajustado */
                    }
                    .dv {
                        color: Gray;
                        font-weight: bold;
                    }
                    .advance {
                        color: #333333;
                        font-weight: bold;
                    }
                    .erp {
                        background-color: Firebrick;
                        color: white;
                        font-weight: bold;
                        padding: 2px;
                    }
                    .version {
                        color: Gray;
                        font-size: 10px;
                    }
                    .welcome-text {
                        margin-top: 20px;
                        font-size: 24px;
                    }
                    .description {
                        margin-top: 10px;
                        font-size: 16px;
                    }
                    .trust-section {
                        margin-top: 40px;
                        padding: 20px;
                    }
                    .trust-title {
                        font-size: 20px;
                        font-weight: bold;
                        margin-bottom: 20px;
                        color: #333333;
                    }
                </style>
                </head>
                <body>
                    <div class=""header"">
                        <div class=""logo"">
                            <span class=""advance"">a</span><span class=""dv"">DV</span><span class=""advance"">ance</span> <span class=""erp"">ERP</span> <span class=""version"">" + version + @"</span>  
                        </div>
                    </div>
                    <div class=""welcome-text"">
                        <p>¡Estamos encantados de tenerte aquí!</p>
                        <p>La solución integral para la gestión de tus recursos empresariales comienza ahora.</p>
                    </div>
                    <div class=""description"">
                        <p>Con aDVance ERP, optimiza tus procesos, mejora la eficiencia y lleva tu negocio al siguiente nivel.</p>
                        <p>Explora nuestras funcionalidades y descubre cómo podemos ayudarte a alcanzar el éxito.</p>
                    </div>
    
                    <div class=""trust-section"">
                        <div class=""trust-title"">Estas empresas confían en nosotros</div>
                    </div>
                </body>
                </html>
                ";

        fieldTextoBienvenida.Text = textoHTML;
        fieldTextoBienvenida.Visible = true;
    }

    public void Restaurar() {
        Vistas.Ocultar(true);
    }

    public void Ocultar() {
        btnInicio.Checked = true;

        Hide();
    }

    public void Cerrar() {
        Vistas.Cerrar();
    }
}