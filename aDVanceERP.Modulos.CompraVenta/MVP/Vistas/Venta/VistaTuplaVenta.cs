using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta;

public partial class VistaTuplaVenta : Form, IVistaTuplaVenta {
    public VistaTuplaVenta() {
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

    public string Fecha {
        get => fieldFecha.Text;
        set => fieldFecha.Text = value;
    }

    public string NombreAlmacen {
        get => fieldNombreAlmacen.Text;
        set {
            fieldNombreAlmacen.Text = string.IsNullOrEmpty(value) ? "Ninguno" : value;
            fieldNombreAlmacen.Margin = new Padding(1, value.Length > 16 ? 10 : 1, 1, 1);
        }
    }

    public string NombreCliente {
        get => fieldNombreCliente.Text;
        set => fieldNombreCliente.Text = value;
    }

    public string CantidadProductos {
        get => fieldCantidadProductos.Text;
        set => fieldCantidadProductos.Text = value;
    }

    public string MontoTotal {
        get => fieldMontoTotal.Text;
        set => fieldMontoTotal.Text = value;
    }

    public string? EstadoEntrega {
        get => fieldEstadoEntrega.Text;
        set {
            fieldEstadoEntrega.Text = value;

            ColorFondoTupla = ObtenerColorTupla();
        }
    }

    public string? EstadoPago {
        get => fieldEstadoPago.Text;
        set {
            fieldEstadoPago.Text = value;

            ColorFondoTupla = ObtenerColorTupla();
        }
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
        // VAriables
        ColorFondoTupla = ObtenerColorTupla();

        // Eventos
        fieldId.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldFecha.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldNombreAlmacen.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldNombreCliente.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldCantidadProductos.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldMontoTotal.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldEstadoEntrega.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldEstadoPago.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };

        btnEditar.Click += delegate (object? sender, EventArgs e) { EditarDatosTupla?.Invoke(this, e); };
        btnEliminar.Click += delegate (object? sender, EventArgs e) { EliminarDatosTupla?.Invoke(this, e); };
    }

    public void Mostrar() {
        VerificarPermisos();
        BringToFront();
        Show();
    }

    public void Restaurar() {
        ColorFondoTupla = ObtenerColorTupla();
    }

    public void Ocultar() {
        Hide();
    }

    public void Cerrar() {
        Dispose();
    }

    private void VerificarPermisos() {
        btnEditar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_COMPRAVENTA_VENTA_EDITAR")
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_COMPRAVENTA_VENTA_TODOS")
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_COMPRAVENTA_TODOS");
        btnEliminar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                              || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                  "MOD_COMPRAVENTA_VENTA_ELIMINAR")
                              || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                  "MOD_COMPRAVENTA_VENTA_TODOS")
                              || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_COMPRAVENTA_TODOS");
    }

    private Color ObtenerColorTupla() {
        if (EstadoPago?.Equals("Pendiente") ?? false)
            return VariablesGlobales.ColorPagoPendienteTupla;
        else if (EstadoEntrega?.Equals("Pendiente") ?? false)
            return VariablesGlobales.ColorEntregaPendienteTupla;

        return BackColor;
    }
}