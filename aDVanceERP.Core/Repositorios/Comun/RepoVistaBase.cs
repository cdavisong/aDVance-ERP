using System.Reflection;
using aDVanceERP.Core.Modelos.Comun;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Repositorios.Comun.Interfaces;
using aDVanceERP.Core.Vistas.Interfaces;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace aDVanceERP.Core.Repositorios.Comun;

public sealed class RepoVistaBase : IRepoVistaBase<IVistaBase> {
    private readonly Panel _contenedorVistas;
    private bool disposedValue;

    public RepoVistaBase(Panel contenedorVistas) {
        _contenedorVistas = contenedorVistas ?? throw new ArgumentNullException(nameof(contenedorVistas));
        _contenedorVistas.Resize += OnRedimensionarContenedorVistas;

        // Habilitar doble búfer para reducir el flickering
        _contenedorVistas.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)?
            .SetValue(_contenedorVistas, true);

        // Inicializar variables
        Vistas = new Dictionary<string, IVistaBase>();
    }

    public Dictionary<string, IVistaBase> Vistas { get; private set; }

    public IVistaBase? VistaActual { get; private set; }

    public void Inicializar(string nombre) {
        ObtenerPorId(nombre)?.Inicializar();
    }

    public IVistaBase? ObtenerPorId(object id) {
        var name = id.ToString();

        if (string.IsNullOrEmpty(name) || !(Vistas?.ContainsKey(name) ?? false))
            return null;

        return Vistas[name];
    }

    public List<IVistaBase> ObtenerTodos() {
        return Vistas?.Values.ToList() ?? new List<IVistaBase>();
    }

    public void Registrar(string nombre, IVistaBase vista) {
        Registrar(nombre, vista, new Point(0, 0), _contenedorVistas.Size, TipoRedimensionadoVista.Completo);
    }

    public void Registrar(string nombre, IVistaBase vista, Point coordenadas, Size dimensiones, TipoRedimensionadoVista tipoRedimensionado) {
        var form = (vista as Form);

        if (form != null) {
            form.Location = coordenadas;
            form.Name = nombre;
            form.Size = dimensiones;
            form.Tag = tipoRedimensionado;
            form.TopLevel = false;
            form.Visible = false;

            _contenedorVistas.Controls.Add(form);
        }
        else
            throw new ArgumentException("Error en el registro de la vista en el contenedor. Sólo se admiten vistas del tipo Form.", nameof(vista));

        // Agregar la vista la diccionario.
        Vistas.Add(nombre, vista);

        // Actualiza las dimensiones de las vistas por primera vez
        OnRedimensionarContenedorVistas(vista, EventArgs.Empty);
    }

    public void Mostrar(string nombre) {
        if (string.IsNullOrEmpty(nombre) || !Vistas.ContainsKey(nombre))
            return;

        Vistas[nombre].Mostrar();
    }

    public void Restaurar(string nombre) {
        if (string.IsNullOrEmpty(nombre) || !Vistas.ContainsKey(nombre))
            return;

        Vistas[nombre].Restaurar();
    }

    public void Ocultar(string nombre) {
        if (string.IsNullOrEmpty(nombre) || !Vistas.ContainsKey(nombre))
            return;

        Vistas[nombre].Ocultar();
    }

    public void OcultarTodos() {
        foreach (var vista in Vistas.Values)
            vista.Ocultar();
    }

    public void Cerrar(string nombre) {
        if (string.IsNullOrEmpty(nombre) || !Vistas.ContainsKey(nombre))
            return;

        Vistas[nombre].Cerrar();

        var form = _contenedorVistas.Controls.OfType<IVistaBase>().OfType<Form>().FirstOrDefault();

        form?.Dispose();

        _contenedorVistas.Controls.Remove(form);

        Vistas.Remove(nombre);
    }

    public void CerrarTodos() {
        if (Vistas == null)
            return;

        SuspendRedraw();

        try {
            foreach (var vista in Vistas.Values)
                vista.Cerrar();

            foreach (var form in _contenedorVistas.Controls.OfType<IVistaBase>().OfType<Form>()) {
                form.Dispose();

                _contenedorVistas.Controls.Remove(form);
            }

            Vistas.Clear();
        }
        finally {
            ResumeRedraw();
        }
    }

    private void AjustarDimensiones(IVistaBase vista, Size dimensiones, TipoRedimensionadoVista tipoRedimensionado) {
        switch (tipoRedimensionado) {
            case TipoRedimensionadoVista.Completo:
                vista.Dimensiones = _contenedorVistas.Size;
                break;
            case TipoRedimensionadoVista.Horizontal:
                vista.Dimensiones = new Size(_contenedorVistas.Size.Width, dimensiones.Height);
                break;
            case TipoRedimensionadoVista.Vertical:
                vista.Dimensiones = new Size(dimensiones.Width, _contenedorVistas.Size.Height);
                break;
            default:
                vista.Dimensiones = dimensiones;
                break;
        }
    }

    private void OnRedimensionarContenedorVistas(object? sender, EventArgs e) {
        try {
            if (sender is IVistaBase vistaSender) {
                if (vistaSender is Form form && form.Tag is TipoRedimensionadoVista tipoRedimensionado) {
                    if (form.InvokeRequired) {
                        form.Invoke(() => { OnRedimensionarContenedorVistas(vistaSender, e); });
                        return;
                    }

                    SuspendRedraw();

                    AjustarDimensiones(vistaSender, vistaSender.Dimensiones, tipoRedimensionado);
                }
                return;
            }

            foreach (var vista in (Vistas?.Values).Where(v => !(v is IVistaSubMenu)))
                OnRedimensionarContenedorVistas(vista, e);
        }
        finally {
            ResumeRedraw();
        }
    }

    private void SuspendRedraw() {
        _contenedorVistas.SuspendLayout();
    }

    private void ResumeRedraw() {
        _contenedorVistas.ResumeLayout();
    }

    private void Dispose(bool disposing) {
        if (!disposedValue) {
            if (disposing) {
                _contenedorVistas.Resize -= OnRedimensionarContenedorVistas;
            }

            CerrarTodos();

            // TODO: establecer los campos grandes como NULL
            disposedValue = true;
        }
    }

    // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
    // ~RepositorioVistaBase()
    // {
    //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
    //     Dispose(disposing: false);
    // }

    public void Dispose() {
        // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }


}