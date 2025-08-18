using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.CuentaBancaria.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Vistas.CuentaBancaria; 

public partial class VistaRegistroCuentaBancaria : Form, IVistaRegistroCuentaBancaria {
    private bool _modoEdicion;

    public VistaRegistroCuentaBancaria() {
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

    public string Alias {
        get => fieldAlias.Text;
        set => fieldAlias.Text = value;
    }

    public string NumeroTarjeta {
        get => fieldNumeroCuenta.Text;
        set => fieldNumeroCuenta.Text = value;
    }

    public string Moneda {
        get => fieldTipoMoneda.Text;
        set => fieldTipoMoneda.Text = value;
    }

    public string NombrePropietario {
        get => fieldNombrePropietario.Text;
        set => fieldNombrePropietario.Text = value;
    }

    public bool ModoEdicionDatos {
        get => _modoEdicion;
        set {
            fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
            btnRegistrar.Text = value ? "Actualizar cuenta" : "Registrar cuenta";
            _modoEdicion = value;
        }
    }

    public event EventHandler? RegistrarDatos;
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarDatos;
    

    public void Inicializar() {
        CargarTiposMoneda(Enum.GetNames(typeof(TipoMoneda)));

        // Eventos            
        btnCerrar.Click += delegate(object? sender, EventArgs args) { Close(); };
        fieldNumeroCuenta.TextChanged += AgregarEspaciosNumeroCuenta;
        btnRegistrar.Click += delegate(object? sender, EventArgs args) {
            if (ModoEdicionDatos)
                EditarDatos?.Invoke(sender, args);
            else
                RegistrarDatos?.Invoke(sender, args);
        };
        btnSalir.Click += delegate(object? sender, EventArgs args) { Close(); };
    }

    public void CargarTiposMoneda(string[] tiposMoneda) {
        fieldTipoMoneda.Items.Clear();
        fieldTipoMoneda.Items.AddRange(tiposMoneda);
        fieldTipoMoneda.SelectedIndex = 0;
    }

    public void CargarNombresContactos(object[] nombresContactos) {
        fieldNombrePropietario.Items.Add("Ninguno");
        fieldNombrePropietario.Items.AddRange(nombresContactos);
        fieldNombrePropietario.SelectedIndex = -1;
    }

    public void Mostrar() {
        BringToFront();
        ShowDialog();
    }

    public void Restaurar() {
        Alias = string.Empty;
        NumeroTarjeta = string.Empty;
        Moneda = string.Empty;
        fieldTipoMoneda.SelectedIndex = -1;
        NombrePropietario = string.Empty;
        fieldNombrePropietario.SelectedIndex = -1;
        ModoEdicionDatos = false;
    }

    public void Ocultar() {
        Hide();
    }

    public void Cerrar() {
        Dispose();
    }

    private void AgregarEspaciosNumeroCuenta(object? sender, EventArgs args) {
        var texto = fieldNumeroCuenta.Text.Replace(" ", "");

        if (texto.Length > 0) {
            var textoConEspacios = string.Join(" ",
                Enumerable.Range(0, texto.Length / 4 + (texto.Length % 4 == 0 ? 0 : 1))
                    .Select(i => texto.Substring(i * 4, Math.Min(4, texto.Length - i * 4))));

            // Guardar posición del cursor
            var cursorPosition = fieldNumeroCuenta.SelectionStart;

            // Actualizar el texto del TextBox
            fieldNumeroCuenta.TextChanged -= AgregarEspaciosNumeroCuenta;
            fieldNumeroCuenta.Text = textoConEspacios;
            fieldNumeroCuenta.TextChanged += AgregarEspaciosNumeroCuenta;

            // Restaurar posición del cursor
            fieldNumeroCuenta.SelectionStart = cursorPosition + 1;
        }
    }
}