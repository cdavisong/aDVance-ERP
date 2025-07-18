using System.Reflection;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Modelos.Repositorios; 

public sealed class RepositorioVistaBase : IRepositorioVista {
    private readonly Panel _contenedorVistas;
    private bool disposedValue;

    public RepositorioVistaBase(Panel contenedorVistas) {
        _contenedorVistas = contenedorVistas ?? throw new ArgumentNullException(nameof(contenedorVistas));

        // Habilitar doble búfer para reducir el flickering
        _contenedorVistas.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)?
            .SetValue(_contenedorVistas, true);

        Inicializar();
    }

    public List<IVista>? Vistas { get; private set; }

    public IVista? VistaActual { get; private set; }

    public void Registrar(string nombre, IVista vista, Point coordenadas, Size dimensiones,
        string modoRedimensionado = "HV") {
        SuspendRedraw(); // Suspender el redibujado

        try {
            if (vista is Control control) {
                control.Visible = false;
                control.Tag = modoRedimensionado;

                if (vista is Form vistaForm) {
                    vistaForm.Name = nombre;
                    vistaForm.Location = coordenadas;
                    vistaForm.TopLevel = false;

                    _contenedorVistas.Controls.Add(vistaForm);
                }
                else if (vista is UserControl vistaUserControl) {
                    vistaUserControl.Name = nombre;
                    vistaUserControl.Location = coordenadas;

                    _contenedorVistas.Controls.Add(vistaUserControl);
                }
                else if (vista is Panel vistaPanel) {
                    vistaPanel.Name = nombre;
                    vistaPanel.Location = coordenadas;

                    _contenedorVistas.Controls.Add(vistaPanel);
                }

                Vistas?.Add(vista);

                // Actualiza las dimensiones de las vistas
                ActualizarDimensionesVistas(vista, EventArgs.Empty);
            }
        }
        finally {
            ResumeRedraw(); // Reanudar el redibujado
        }
    }

    public void Registrar(string nombre, IVista vista) {
        Registrar(nombre, vista, new Point(0, 0), _contenedorVistas.Size);
    }

    public IVista? Obtener(string nombre) {
        var controles = _contenedorVistas.Controls.Find(nombre, false);
        return controles.FirstOrDefault() as IVista;
    }

    public void Inicializar(string nombre = "") {
        if (string.IsNullOrEmpty(nombre))
            Vistas = new List<IVista>();
        else
            Obtener(nombre)?.Inicializar();

        _contenedorVistas.Resize += ActualizarDimensionesVistas;
    }

    public void Mostrar(string nombre) {
        var vista = Obtener(nombre);
        if (vista != null) {
            vista.Habilitada = true;
            vista.Mostrar();
            VistaActual = vista;
        }
    }

    public void Restaurar(string nombre) {
        var vista = Obtener(nombre);
        if (vista != null) {
            vista.Habilitada = true;
            vista.Restaurar();
        }
    }

    public void Ocultar(bool ocultarTodo = false) {
        SuspendRedraw(); // Suspender el redibujado

        try {
            if (ocultarTodo) {
                if (Vistas != null)
                    foreach (var vista in Vistas) {
                        vista.Ocultar();
                        vista.Habilitada = true;
                    }
            }
            else {
                if (VistaActual != null) {
                    VistaActual.Ocultar();
                    VistaActual.Habilitada = true;
                }
            }
        }
        finally {
            ResumeRedraw(); // Reanudar el redibujado
        }
    }

    public void Cerrar(bool cerrarTodo = false) {
        SuspendRedraw(); // Suspender el redibujado

        try {
            if (cerrarTodo) {
                if (Vistas != null)
                    foreach (var vista in Vistas)
                        vista.Cerrar();

                foreach (var control in _contenedorVistas.Controls.OfType<IVista>().ToList())
                    (control as Control)?.Dispose();

                Vistas?.Clear();
            }
            else {
                VistaActual?.Cerrar();
                (VistaActual as Control)?.Dispose();
            }
        }
        finally {
            ResumeRedraw(); // Reanudar el redibujado
        }
    }

    public async Task CerrarAsync(bool cerrarTodo = false) {
        await Task.Run(() => {
            Cerrar(cerrarTodo); // Ejecutar en un hilo secundario
        });
    }

    private void AjustarDimensiones(IVista vista, Size dimensiones, string modoRedimensionado) {
        switch (modoRedimensionado) {
            case "HV":
                vista.Dimensiones = _contenedorVistas.Size;
                break;
            case "H":
                vista.Dimensiones = new Size(_contenedorVistas.Size.Width, dimensiones.Height);
                break;
            case "V":
                vista.Dimensiones = new Size(dimensiones.Width, _contenedorVistas.Size.Height);
                break;
            default:
                vista.Dimensiones = dimensiones;
                break;
        }
    }

    private void ActualizarDimensionesVistas(object? sender, EventArgs e) {
        if (sender is IVista vistaSender) {
            if (vistaSender is Control control && control.Tag is string modoRedimensionado)
                if (control.InvokeRequired)
                    control.BeginInvoke(() => {
                        AjustarDimensiones(vistaSender, vistaSender.Dimensiones, modoRedimensionado);
                    });
                else AjustarDimensiones(vistaSender, vistaSender.Dimensiones, modoRedimensionado);

            return;
        }

        SuspendRedraw(); // Suspender el redibujado

        try {
            foreach (var vista in Vistas.Where(v => !(v is IVistaSubMenu)))
                if (vista is Control control && control.Tag is string modoRedimensionado) {
                    if (control.InvokeRequired)
                        control.BeginInvoke(() => {
                            AjustarDimensiones(vista, vista.Dimensiones, modoRedimensionado);
                        });
                    else AjustarDimensiones(vista, vista.Dimensiones, modoRedimensionado);
                }
        }
        finally {
            ResumeRedraw(); // Reanudar el redibujado
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
                _contenedorVistas.Resize -= ActualizarDimensionesVistas;
            }

            Cerrar();

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