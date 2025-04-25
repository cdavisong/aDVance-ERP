using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Mensajeria.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Mensajeria;

public partial class VistaRegistroMensajeria : Form, IVistaRegistroMensajeria {
    private bool _modoEdicion;
    private string[] _descripcionesTiposEntrega = Array.Empty<string>();
    private List<string[]>? _articulosVenta = new();

    public VistaRegistroMensajeria() {
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

    public long IdVenta { get; set; }

    public string? NombreCliente { get; private set; }

    public string? TelefonosCliente { get; private set; }

    public string? NombreMensajero {
        get => fieldNombreMensajero.Text;
        set => fieldNombreMensajero.Text = value;
    }

    public string? TipoEntrega {
        get => fieldTipoEntrega.Text;
        set => fieldTipoEntrega.Text = value;
    }

    public string DescripcionTipoEntrega {
        get => fieldDescripcionTipoEntrega.Text;
        set => fieldDescripcionTipoEntrega.Text = value;
    }

    public string? Direccion {
        get => fieldDireccion.Text;
        set {
            fieldDireccion.Text = value;
            fieldDireccion.Margin = new Padding(1, value?.Length > 43 ? 10 : 1, 1, 1);
        }
    }

    public string ResumenEntrega {
        get => fieldResumenEntrega.Text;
        set => fieldResumenEntrega.Text = value;
    }

    public bool ModoEdicionDatos {
        get => _modoEdicion;
        set {
            fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
            btnRegistrar.Text = value ? "Actualizar contacto" : "Registrar contacto";
            _modoEdicion = value;
        }
    }

    public string? Observaciones {
        get => fieldObservaciones.Text;
        set => fieldObservaciones.Text = value;
    }

    public event EventHandler? RegistrarDatos;
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarDatos;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Eventos
        btnCerrar.Click += delegate (object? sender, EventArgs args) {
            Salir?.Invoke(sender, args);
        };
        fieldNombreMensajero.SelectedIndexChanged += delegate {
            ActualizarResumenEntrega();
        };
        fieldTipoEntrega.SelectedIndexChanged += delegate {
            DescripcionTipoEntrega = _descripcionesTiposEntrega[fieldTipoEntrega.SelectedIndex];

            ActualizarResumenEntrega();
        };
        fieldDireccion.TextChanged += delegate {
            ActualizarResumenEntrega();
        };
        fieldObservaciones.TextChanged += delegate {
            ActualizarResumenEntrega();
        };
        btnRegistrar.Click += delegate (object? sender, EventArgs args) {
            if (ModoEdicionDatos)
                EditarDatos?.Invoke(sender, args);
            else
                RegistrarDatos?.Invoke(sender, args);
        };
        btnSalir.Click += delegate (object? sender, EventArgs args) {
            Salir?.Invoke(sender, args);
        };
    }

    public void CargarNombresMensajeros(object[] nombresMensajeros) {
        fieldNombreMensajero.Items.Clear();
        fieldNombreMensajero.Items.AddRange(nombresMensajeros);
        fieldNombreMensajero.SelectedIndex = -1;
    }

    public void CargarTiposEntrega() {
        #region Obtención de tipos y descripciones

        var tiposDescripciones = UtilesEntrega.ObtenerNombreDescripcionTiposEntrega(false).Result;
        var tipos = new List<object>();
        var descripciones = new List<string>();

        foreach (var item in tiposDescripciones) {
            var partes = item.Split('|');

            if (partes.Length < 2)
                continue;

            tipos.Add(partes[0].Trim()); // Nombre
            descripciones.Add(partes[1].Trim()); // Descripción
        }

        #endregion

        fieldTipoEntrega.Items.Clear();
        fieldTipoEntrega.Items.AddRange(tipos.ToArray());
        fieldTipoEntrega.SelectedIndex = -1;

        _descripcionesTiposEntrega = descripciones.ToArray();
    }

    public void PopularDatosCliente(string? nombreCliente) {
        if (nombreCliente != null) {
            NombreCliente = nombreCliente;

            var idCliente = UtilesCliente.ObtenerIdCliente(nombreCliente);

            TelefonosCliente = UtilesTelefonoContacto.ObtenerTelefonoCliente(idCliente, true) ?? UtilesTelefonoContacto.ObtenerTelefonoCliente(idCliente, false);
            Direccion = UtilesCliente.ObtenerDireccionCliente(idCliente);
        }
    }

    public void PopularArticulosVenta(List<string[]>? datosArticulos) {
        _articulosVenta = datosArticulos;

        ActualizarResumenEntrega();
    }

    public void Mostrar() {
        BringToFront();
        ShowDialog();
    }

    public void Restaurar() {
        NombreMensajero = string.Empty;
        fieldNombreMensajero.SelectedIndex = -1;
        TipoEntrega = string.Empty;
        fieldTipoEntrega.SelectedIndex = -1;
        DescripcionTipoEntrega = "...";
        Direccion = string.Empty;
        ResumenEntrega = "...";
        ModoEdicionDatos = false;
    }

    public void Ocultar() {
        Hide();
    }

    public void Cerrar() {
        Dispose();
    }

    private void ActualizarResumenEntrega() {
        var resumenHtml = $@"
<div class='resumen-entrega'>
    <h3>Entrega #{UtilesBD.ObtenerUltimoIdTabla("seguimiento_entrega") + 1:000}</h3>
    <p><strong>Fecha:</strong> {DateTime.Now:yyyy-MM-dd}</p>
    
    <div class='seccion-cliente' style='margin-bottom: 10px;'>
        <h4 style='margin-bottom: 5px;'>Datos del cliente</h4>
        <hr style='margin: 5px 0;'>
        <p style='margin: 2px 0;'><strong>Nombre:</strong> {NombreCliente}</p>
        <p style='margin: 2px 0;'><strong>Teléfonos:</strong> {TelefonosCliente}</p>
        <p style='margin: 2px 0;'><strong>Dirección:</strong> {Direccion}</p>
        <p style='margin: 2px 0;'><strong>Observaciones:</strong> {Observaciones}</p>
    </div>
    
    <div class='seccion-articulos'>
        <h4 style='margin-bottom: 5px;'>Artículos</h4>
        <hr style='margin: 5px 0;'>";

        if (_articulosVenta != null)
            resumenHtml = _articulosVenta.Aggregate(resumenHtml,
                (current, articulo) => current + $@"
        <p style='margin: 2px 0;'><strong>{articulo[4]}</strong> - {articulo[1]}</p>");

        resumenHtml += @"
    </div>
</div>";

        // Actualizar el resúmen de entrega
        ResumenEntrega = resumenHtml;
        
        if (ModoEdicionDatos) 
            return;

        // Verificar si la entrega es válida
        var mensajeroOk = !string.IsNullOrEmpty(NombreMensajero);
        var tipoEntregaOk = !string.IsNullOrEmpty(TipoEntrega);
        var direccionOk = !string.IsNullOrEmpty(Direccion);

        btnRegistrar.Enabled = mensajeroOk && tipoEntregaOk && direccionOk;
    }
}