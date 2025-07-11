using System.Globalization;

using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Modulos.Taller.Interfaces;

using Guna.UI2.WinForms;

namespace aDVanceERP.Modulos.Taller.Vistas.CostosProduccion;

public partial class VistaTuplaCostoDirecto : Form, IVistaTuplaCostoProduccion {
    public VistaTuplaCostoDirecto() {
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

    public string FechaRegistro {
        get => fieldFecha.Text;
        set => fieldFecha.Text = value;
    }

    public string NombreProducto {
        get => fieldNombre.Text;
        set => fieldNombre.Text = value;
    }

    public decimal CostoMateriaPrima {
        get => decimal.TryParse(fieldMateriaPrimaDirecta.Text, NumberStyles.Any, CultureInfo.InvariantCulture,
            out var value)
            ? value
            : 0;
        set => fieldMateriaPrimaDirecta.Text = value > 0
                ? value.ToString("N2", CultureInfo.InvariantCulture)
                : "-";
    }

    public decimal CostoManoObra {
        get => decimal.TryParse(fieldManoObraDirecta.Text, NumberStyles.Any, CultureInfo.InvariantCulture,
            out var value)
            ? value
            : 0;
        set => fieldManoObraDirecta.Text = value > 0
                ? value.ToString("N2", CultureInfo.InvariantCulture)
                : "-";
    }

    public decimal CostoIndirectoFabricacion {
        get => decimal.TryParse(fieldCostoIndirecto.Text, NumberStyles.Any, CultureInfo.InvariantCulture,
            out var value)
            ? value
            : 0;
        set => fieldCostoIndirecto.Text = value > 0
                ? value.ToString("N2", CultureInfo.InvariantCulture)
                : "-";
    }

    public decimal CostoTotal {
        get => decimal.TryParse(fieldCostoTotal.Text, NumberStyles.Any, CultureInfo.InvariantCulture,
            out var value)
            ? value
            : 0;
        set => fieldCostoTotal.Text = value > 0
                ? value.ToString("N2", CultureInfo.InvariantCulture)
                : "-";
    }

    public string? Observaciones {
        get => fieldObservaciones.Text;
        set => fieldObservaciones.Text = value;
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
        foreach (var control in layoutVista.Controls) {
            if (control is Guna2CircleButton || control is Guna2Button)
                continue;

            ((Control) control).Click += OnSeleccionTupla;
        }
        btnEditar.Click += delegate (object? sender, EventArgs e) {
            EditarDatosTupla?.Invoke(this, e);
        };
        btnEliminar.Click += delegate (object? sender, EventArgs e) {
            EliminarDatosTupla?.Invoke(this, e);
        };
    }

    private void OnSeleccionTupla(object? sender, EventArgs e) {
        TuplaSeleccionada?.Invoke(this, e);
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
            return;
        }

        btnEditar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_TALLER_COSTOS_EDITAR")
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_TALLER_COSTOS_TODOS")
                            || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_TALLER_TODOS");
        btnEliminar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                              || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_TALLER_COSTOS_ELIMINAR")
                              || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_TALLER_COSTOS_TODOS")
                              || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_TALLER_TODOS");
    }
}