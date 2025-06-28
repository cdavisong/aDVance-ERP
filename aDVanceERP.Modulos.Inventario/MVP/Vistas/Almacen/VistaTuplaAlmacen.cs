using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen; 

public partial class VistaTuplaAlmacen : Form, IVistaTuplaAlmacen {
    public VistaTuplaAlmacen() {
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

    public string Nombre {
        get => fieldNombre.Text;
        set => fieldNombre.Text = value;
    }

    public string Direccion {
        get => fieldDireccion.Text;
        set {
            fieldDireccion.Text = value;
            fieldDireccion.Margin = new Padding(1, value?.Length > 43 ? 10 : 1, 1, 1);
        }
    }

    public string Notas {
        get => fieldNotas.Text;
        set {
            fieldNotas.Text = value;
            fieldNotas.Margin = new Padding(1, value?.Length > 43 ? 10 : 1, 1, 1);
        }
    }

    public bool MostrarBotonExportarProductos {
        get => btnExportarProductos.Visible;
        set => btnExportarProductos.Visible = value;
    }

    public Color ColorFondoTupla {
        get => layoutVista.BackColor;
        set => layoutVista.BackColor = value;
    }

    public event EventHandler? TuplaSeleccionada;
    public event EventHandler? DescargarProductos;
    public event EventHandler? EditarDatosTupla;
    public event EventHandler? EliminarDatosTupla;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Eventos
        fieldId.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldNombre.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldDireccion.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldNotas.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };

        btnExportarProductos.Click += delegate (object? sender, EventArgs e) { DescargarProductos?.Invoke(Id, e); };
        btnEditar.Click += delegate(object? sender, EventArgs e) { EditarDatosTupla?.Invoke(this, e); };
        btnEliminar.Click += delegate(object? sender, EventArgs e) { EliminarDatosTupla?.Invoke(this, e); };
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
        btnEditar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                "MOD_INVENTARIO_ALMACENES_EDITAR")
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                "MOD_INVENTARIO_ALMACENES_TODOS")
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_TODOS");
        btnEliminar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                              || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                  "MOD_INVENTARIO_ALMACENES_ELIMINAR")
                              || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                  "MOD_INVENTARIO_ALMACENES_TODOS")
                              || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_TODOS");
    }
}