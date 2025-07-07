using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Modulos.Taller.Interfaces;

namespace aDVanceERP.Modulos.Taller.Vistas.Menu;

public partial class VistaMenuTaller : Form, IVistaMenuTaller {
    public VistaMenuTaller() {
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

    public event EventHandler? VerCostosProduccion;
    public event EventHandler? CambioMenu;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Eventos
        btnCostosProduccion.Click += delegate (object? sender, EventArgs e) { PresionarBotonSeleccion(1, e); };
    }

    public void MostrarCaracteristicaInicial() {
        if (btnCostosProduccion.Visible)
            btnCostosProduccion.PerformClick();
    }

    public void PresionarBotonSeleccion(object? sender, EventArgs e) {
        var indiceValido = int.TryParse(sender?.ToString() ?? string.Empty, out var indice);

        if (!indiceValido)
            return;

        CambioMenu?.Invoke(sender, e);

        switch (indice) {
            case 1:
                VerCostosProduccion?.Invoke(btnCostosProduccion, e);
                if (!btnCostosProduccion.Checked)
                    btnCostosProduccion.Checked = true;
                break;
        }
    }

    public void Mostrar() {
        VerificarPermisos();
        BringToFront();
        Show();
    }

    public void Restaurar() {
        btnCostosProduccion.Checked = false;
    }

    public void Ocultar() {
        Hide();
    }

    public void Cerrar() {
        Dispose();
    }

    private void VerificarPermisos() {
        btnCostosProduccion.Visible = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                               || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoParcial("MOD_TALLER_COSTOS")
                               || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_TALLER_TODOS");
    }
}