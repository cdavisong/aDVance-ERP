using System.Reflection;
using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Core.Modelos.Comun;

public class PanelContenedorVistas : IPanelContenedorVistas {
    private Panel _panelContenedor;

    public PanelContenedorVistas(Panel panelContenedor) {
        _panelContenedor = panelContenedor ?? throw new ArgumentNullException(nameof(panelContenedor));
        _panelContenedor.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(_panelContenedor, true, null);
        _panelContenedor.Resize += ActualizarDimensionesVistas;

        Vistas = new Dictionary<string, IVista>();
    }

    public Size Dimensiones {
        get => _panelContenedor?.Size ?? Size.Empty;
        set => _panelContenedor.Size = value;
    }

    public bool Habilitar {
        get => _panelContenedor.Enabled;
        set => _panelContenedor.Enabled = value;
    }

    public IDictionary<string, IVista> Vistas { get; }

    public IVista? VistaActual { get; private set; }

    public void AdicionarVista(IVista vista) {
        AdicionarVista(vista, new Point(0, 0), _panelContenedor.Size);
    }

    public void AdicionarVista(IVista vista, Point coordenadas, Size dimensiones, TipoRedimensionadoVista tipoRedimensionado = TipoRedimensionadoVista.Total) {
        _panelContenedor.SuspendLayout();

        try {
            if (vista == null) {
                throw new ArgumentNullException(nameof(vista));
            }
            else if (Vistas.ContainsKey(vista.Nombre)) {
                throw new ArgumentException($"La vista con el nombre '{vista.Nombre}' ya está registrada en el contenedor.");
            }
            else if (vista is Control control) {
                control.Name = vista.Nombre;
                control.Location = coordenadas;
                control.Visible = false;
                control.Tag = tipoRedimensionado;

                if (vista is Form form) {
                    form.TopLevel = false;
                }

                _panelContenedor.Controls.Add(control);
            }
            else throw new ArgumentException($"La vista debe ser un Control. Tipo actual: {vista.GetType().Name}");

            Vistas.Add(vista.Nombre, vista);
        }
        finally {
            _panelContenedor.ResumeLayout(false);
        }
    }

    public IVista ObtenerVista(string nombre) {
        return Vistas.TryGetValue(nombre, out var vista)
            ? vista
            : throw new KeyNotFoundException($"No se encontró una vista con el nombre '{nombre}'.");
    }

    public void MostrarVista(string nombre) {
        Vistas.TryGetValue(nombre, out var vista);

        if (vista != null) {
            if (vista is Control) {
                vista.Mostrar();
            }
            else {
                throw new InvalidOperationException($"La vista '{nombre}' no es un Control y no puede mostrarse.");
            }
        }
        else {
            throw new KeyNotFoundException($"No se encontró una vista con el nombre '{nombre}'.");
        }
    }

    public void RestaurarVista(string nombre) {
        Vistas.TryGetValue(nombre, out var vista);

        if (vista != null) {
            vista.Restaurar();
        }
        else {
            throw new KeyNotFoundException($"No se encontró una vista con el nombre '{nombre}'.");
        }
    }

    public void OcultarVista(string nombre) {
        Vistas.TryGetValue(nombre, out var vista);

        if (vista != null) {
            if (vista is Control control) {
                vista.Ocultar();
            }
            else {
                throw new InvalidOperationException($"La vista '{nombre}' no es un Control y no puede ocultarse.");
            }
        }
        else {
            throw new KeyNotFoundException($"No se encontró una vista con el nombre '{nombre}'.");
        }
    }

    public void OcultarVistas() {
        foreach (var vista in Vistas.Values)
            vista.Ocultar();
    }

    public void CerrarVista(string nombre) {
        Vistas.TryGetValue(nombre, out var vista);

        if (vista != null) {
            if (vista is Control control)
                _panelContenedor.Controls.Remove(control);

            vista.Dispose();

            Vistas.Remove(nombre);
        }
        else {
            throw new KeyNotFoundException($"No se encontró una vista con el nombre '{nombre}'.");
        }
    }

    public void CerrarVistas() {
        foreach (var vista in Vistas.Values)
            CerrarVista(vista.Nombre);
    }

    #region Lógica para redimensionar vistas

    private void ActualizarDimensionesVistas(object? sender, EventArgs empty) {
        if (Vistas.Count == 0)
            return;

        _panelContenedor.SuspendLayout();

        try {
            var controlesAProcesar = ObtenerControlesParaRedimensionar(sender).ToList();

            foreach (var control in controlesAProcesar) {
                if (control.Tag is TipoRedimensionadoVista tipoRedimensionado) {
                    RedimensionarControl(control, tipoRedimensionado, control.Size, control.Location);
                }
            }
        }
        finally {
            _panelContenedor.ResumeLayout();
        }
    }

    private IEnumerable<Control> ObtenerControlesParaRedimensionar(object? sender) {
        if (sender is string nombreVista) {
            var vista = ObtenerVista(nombreVista);
            if (vista is Control control) {
                yield return control;
            }
        }
        else {
            foreach (var vista in Vistas.Values) {
                if (vista is Control control) {
                    yield return control;
                }
            }
        }
    }

    private void RedimensionarControl(Control control, TipoRedimensionadoVista tipo, Size dimensiones, Point coordenadas) {
        switch (tipo) {
            case TipoRedimensionadoVista.Total:
                control.Size = _panelContenedor.Size;
                control.Location = coordenadas;
                break;
            case TipoRedimensionadoVista.Horizontal:
                control.Width = dimensiones.Width;
                control.Location = new Point(coordenadas.X, control.Location.Y);
                break;
            case TipoRedimensionadoVista.Vertical:
                control.Height = dimensiones.Height;
                control.Location = new Point(control.Location.X, coordenadas.Y);
                break;
                // Ninguno no requiere acción
        }
    }

    #endregion

    public void Dispose() {
        foreach (var vista in Vistas.Values)
            vista.Dispose();

        _panelContenedor.Controls.Clear();
        _panelContenedor?.Dispose();
        _panelContenedor = null;

        Vistas.Clear();

        GC.SuppressFinalize(this);
    }
}