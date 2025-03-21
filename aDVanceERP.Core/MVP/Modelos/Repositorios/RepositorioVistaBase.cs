using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Modelos.Repositorios {
    public sealed class RepositorioVistaBase : IRepositorioVista {
        private readonly Panel _contenedorVistas;
        private Dictionary<string, IVista> _vistas;

        public RepositorioVistaBase(Panel contenedorVistas) {
            _contenedorVistas = contenedorVistas ?? throw new ArgumentNullException(nameof(contenedorVistas));
            _vistas = new Dictionary<string, IVista>();

            // Habilitar doble búfer para reducir el flickering
            _contenedorVistas.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?
                .SetValue(_contenedorVistas, true);

            Inicializar();
        }

        public void Registrar(string nombre, IVista vista, Point coordenadas, Size dimensiones, string modoRedimensionado = "HV") {
            if (_vistas.ContainsKey(nombre))
                return; // No registrar si ya existe

            SuspendRedraw(); // Suspender el redibujado

            try {
                if (vista is Control control) {
                    control.Name = nombre;
                    control.Location = coordenadas;
                    control.Visible = false;                    
                    control.Tag = modoRedimensionado;

                    if (vista is Form vistaForm) {
                        vistaForm.TopLevel = false;

                        _contenedorVistas.Controls.Add(vistaForm);
                    } else if (vista is UserControl vistaUserControl) {
                        _contenedorVistas.Controls.Add(vistaUserControl);
                    }

                    AjustarDimensiones(vista, dimensiones, modoRedimensionado);
                }
            } finally {
                ResumeRedraw(); // Reanudar el redibujado
            }

            _vistas.Add(nombre, vista);
        }

        public void Registrar(string nombre, IVista vista) {
            Registrar(nombre, vista, new Point(0, 0), _contenedorVistas.Size);
        }

        public IVista? Obtener(string nombre) {
            var vista = _vistas[nombre];

            if (vista != null)
                return vista;

            // Si la vista no existe, se puede lanzar una excepción
            throw new KeyNotFoundException($"La vista con el nombre '{nombre}' no está registrada.");
        }

        public void Inicializar(string nombre = "") {
            if (!string.IsNullOrEmpty(nombre))
                Obtener(nombre)?.Inicializar();

            _contenedorVistas.Resize += ActualizarDimensionesVistas;
        }

        public void Mostrar(string nombre) {
            var vista = Obtener(nombre);

            if (vista == null)
                return;

            vista.Habilitada = true;
            vista.Mostrar();
        }

        public void Restaurar(string nombre) {
            var vista = Obtener(nombre);

            if (vista == null)
                return;

            vista.Habilitada = true;
            vista.Restaurar();
        }

        public void OcultarVista(string nombre) {
            var vista = Obtener(nombre);

            if (vista == null)
                return;

            vista.Ocultar();
            vista.Habilitada = true;
        }

        public void OcultarVistas() {
            SuspendRedraw(); // Suspender el redibujado

            try {
                foreach (var control in _contenedorVistas.Controls.OfType<IVista>()) {
                    control.Ocultar();
                    control.Habilitada = true;
                }
            } finally {
                ResumeRedraw(); // Reanudar el redibujado
            }
        }

        public void CerrarVista(string nombre) {
            var vista = Obtener(nombre);

            if (vista == null)
                return;

            vista.Cerrar();
            (vista as Control)?.Dispose();
            _vistas.Remove(nombre);
        }

        public void CerrarVistas() {
            SuspendRedraw();

            try {
                foreach (var control in _contenedorVistas.Controls.OfType<IVista>().ToList()) {
                    control.Cerrar();
                    (control as Control)?.Dispose();
                    _vistas.Remove((control as Control)?.Name);
                }
            } finally {
                ResumeRedraw(); // Reanudar el redibujado
            }
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
            SuspendRedraw(); // Suspender el redibujado

            try {
                foreach (var vistaKeyValue in _vistas.Where(v => !(v.Value is IVistaSubMenu))) {
                    var vista = vistaKeyValue.Value;

                    if (vista is Control control && control.Tag is string modoRedimensionado) {
                        if (control.InvokeRequired)
                            control.BeginInvoke(new Action(() => { AjustarDimensiones(vista, vista.Dimensiones, modoRedimensionado); }));
                        else AjustarDimensiones(vista, vista.Dimensiones, modoRedimensionado);
                    }
                }
            } finally {
                ResumeRedraw(); // Reanudar el redibujado
            }
        }

        private void SuspendRedraw() {
            _contenedorVistas.SuspendLayout();
        }

        private void ResumeRedraw() {
            _contenedorVistas.ResumeLayout();
        }        
    }
}