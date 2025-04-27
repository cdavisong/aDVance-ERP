using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;
using aDVanceERP.Modulos.Inventario.Properties;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento; 

public partial class VistaTuplaMovimiento : Form, IVistaTuplaMovimiento {
    public VistaTuplaMovimiento() {
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

    public string Id {
        get => fieldId.Text;
        set => fieldId.Text = value;
    }

    public string NombreArticulo {
        get => fieldNombreArticulo.Text;
        set => fieldNombreArticulo.Text = value;
    }

    public string NombreAlmacenOrigen {
        get => fieldNombreAlmacenOrigen.Text;
        set {
            fieldNombreAlmacenOrigen.Text = string.IsNullOrEmpty(value) ? "Ninguno" : value;
            fieldNombreAlmacenOrigen.Margin = new Padding(1, value?.Length > 16 ? 10 : 1, 1, 1);
        }
    }

    public string NombreAlmacenDestino {
        get => fieldNombreAlmacenDestino.Text;
        set {
            fieldNombreAlmacenDestino.Text = string.IsNullOrEmpty(value) ? "Ninguno" : value;
            fieldNombreAlmacenDestino.Margin = new Padding(1, value?.Length > 16 ? 10 : 1, 1, 1);
        }
    }

    public string CantidadMovida {
        get => fieldCantidadMovida.Text;
        set => fieldCantidadMovida.Text = value;
    }

    public string TipoMovimiento {
        get => fieldTipoMovimiento.Text;
        set {
            fieldTipoMovimiento.Text = string.IsNullOrEmpty(value) ? "ERROR" : value;
            fieldTipoMovimiento.Margin = new Padding(1, value?.Length > 23 ? 10 : 1, 1, 1);
        }
    }

    public string Fecha {
        get => fieldFecha.Text;
        set => fieldFecha.Text = value;
    }

    public Color ColorFondoTupla {
        get => layoutVista.BackColor;
        set => layoutVista.BackColor = value;
    }

    public event EventHandler? TuplaSeleccionada;
    public event EventHandler? EditarDatosTupla;
    public event EventHandler? EliminarDatosTupla;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Eventos
        fieldId.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldNombreArticulo.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldNombreAlmacenOrigen.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldNombreAlmacenDestino.Click += delegate(object? sender, EventArgs e) {
            TuplaSeleccionada?.Invoke(this, e);
        };
        fieldCantidadMovida.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldTipoMovimiento.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldFecha.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };

        btnEditar.Click += delegate(object? sender, EventArgs e) { EditarDatosTupla?.Invoke(this, e); };
        btnEliminar.Click += delegate(object? sender, EventArgs e) { EliminarDatosTupla?.Invoke(this, e); };
    }

    public void ActualizarIconoStock(string tipoMovimiento) {
        fieldIcono.BackgroundImage = tipoMovimiento switch {
            "Carga" => Resources.load_cargo_20px,
            "Descarga" => Resources.unload_cargo_20px,
            "Transferencia" => Resources.transfer_20px,
            _ => fieldIcono.BackgroundImage
        };
    }

    public void Mostrar() {
        VerificarPermisos();
        BringToFront();
        Show();
    }

    public void Restaurar() {
        ColorFondoTupla = BackColor;
    }

    public void Ocultar() {
        Hide();
    }

    public void Cerrar() {
        Dispose();
    }

    private void VerificarPermisos() {
        if (UtilesCuentaUsuario.UsuarioAutenticado == null || UtilesCuentaUsuario.PermisosUsuario == null) {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            return;
        }

        btnEditar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                "MOD_INVENTARIO_MOVIMIENTOS_EDITAR")
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                "MOD_INVENTARIO_MOVIMIENTOS_TODOS")
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_TODOS");
        btnEliminar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                              || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                  "MOD_INVENTARIO_MOVIMIENTOS_ELIMINAR")
                              || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                  "MOD_INVENTARIO_MOVIMIENTOS_TODOS")
                              || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_TODOS");
    }
}