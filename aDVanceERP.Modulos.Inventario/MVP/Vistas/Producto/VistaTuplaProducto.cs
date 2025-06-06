using System.Globalization;

using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto;

public partial class VistaTuplaProducto : Form, IVistaTuplaProducto {
    private string? _nombreAlmacen;

    public VistaTuplaProducto() {
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

    public string NombreAlmacen {
        get => _nombreAlmacen ?? string.Empty;
        set => _nombreAlmacen = string.IsNullOrEmpty(value) ? "Ninguno" : value;
    }

    public string Codigo {
        get => fieldCodigo.Text;
        set => fieldCodigo.Text = value;
    }

    public string Nombre {
        get => fieldNombre.Text;
        set {
            fieldNombre.Text = value;
            fieldNombre.Margin = new Padding(1, value?.Length > 27 ? 10 : 1, 1, 1);
        }
    }

    public string Descripcion {
        get => fieldDescripcion.Text;
        set {
            fieldDescripcion.Text = value;
            fieldDescripcion.Margin = new Padding(1, value?.Length > 47 ? 10 : 1, 1, 1);
        }
    }

    public decimal PrecioCompraBase {
        get => decimal.TryParse(fieldPrecioCompraBase.Text, NumberStyles.Any, CultureInfo.InvariantCulture,
            out var value)
            ? value
            : 0;
        set => fieldPrecioCompraBase.Text = value > 0
                ? value.ToString("N2", CultureInfo.InvariantCulture)
                : "-";
    }

    public decimal PrecioVentaBase {
        get => decimal.TryParse(fieldPrecioVentaBase.Text, NumberStyles.Any, CultureInfo.InvariantCulture,
            out var value)
            ? value
            : 0;
        set => fieldPrecioVentaBase.Text = value > 0
                ? value.ToString("N2", CultureInfo.InvariantCulture)
                : "-";
    }

    public string UnidadMedida {
        get => fieldUnidadMedida.Text;
        set => fieldUnidadMedida.Text = value;
    }

    public float Stock {
        get => float.TryParse(fieldStock.Text, NumberStyles.Float, CultureInfo.InvariantCulture, 
            out var value) 
            ? value 
            : 0;
        set {
            fieldStock.ForeColor = value == 0 ? Color.Firebrick : Color.FromArgb(115, 109, 106);
            fieldStock.Font = new Font(fieldStock.Font, value == 0 ? FontStyle.Bold : FontStyle.Regular);
            fieldStock.Text = value.ToString("0.00", CultureInfo.InvariantCulture);
        }
    }

    public Color ColorFondoTupla {
        get => layoutVista.BackColor;
        set => layoutVista.BackColor = value;
    }

    public event EventHandler? TuplaSeleccionada;
    public event EventHandler? MovimientoPositivoStock;
    public event EventHandler? MovimientoNegativoStock;
    public event EventHandler? EditarDatosTupla;
    public event EventHandler? EliminarDatosTupla;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Eventos
        fieldId.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldCodigo.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldNombre.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldDescripcion.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldPrecioCompraBase.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldPrecioVentaBase.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldStock.Click += delegate (object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        btnEditar.Click += delegate (object? sender, EventArgs e) { EditarDatosTupla?.Invoke(this, e); };
        btnMovimientoPositivo.Click += delegate (object? sender, EventArgs e) {
            MovimientoPositivoStock?.Invoke(NombreAlmacen, e);
        };
        btnMovimientoNegativo.Click += delegate (object? sender, EventArgs e) {
            MovimientoNegativoStock?.Invoke(NombreAlmacen, e);
        };
        btnEliminar.Click += async delegate (object? sender, EventArgs e) {
            if (await UtilesProducto.PuedeEliminarProducto(long.Parse(Id)))
                EliminarDatosTupla?.Invoke(this, e);
            else
                CentroNotificaciones.Mostrar(
                    $"No se puede eliminar el producto {Nombre}, existen registros de movimientos asociados al mismo y podría dañar la integridad y trazabilidad de los datos.",
                    TipoNotificacion.Advertencia);
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
            btnMovimientoPositivo.Enabled = false;
            btnMovimientoNegativo.Enabled = false;
            btnEditar.Enabled = false;
            return;
        }

        btnMovimientoPositivo.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                                        || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                            "MOD_INVENTARIO_MOVIMIENTOS_ADICIONAR")
                                        || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                            "MOD_INVENTARIO_MOVIMIENTOS_TODOS")
                                        || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                            "MOD_INVENTARIO_TODOS");
        btnMovimientoNegativo.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                                        || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                            "MOD_INVENTARIO_MOVIMIENTOS_ADICIONAR")
                                        || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                            "MOD_INVENTARIO_MOVIMIENTOS_TODOS")
                                        || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                            "MOD_INVENTARIO_TODOS");
        btnEditar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                "MOD_INVENTARIO_PRODUCTOS_EDITAR")
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                "MOD_INVENTARIO_PRODUCTOS_TODOS")
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_TODOS");
    }
}