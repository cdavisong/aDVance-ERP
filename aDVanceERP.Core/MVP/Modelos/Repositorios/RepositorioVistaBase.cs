using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Modelos.Repositorios {
    public sealed class RepositorioVistaBase : IRepositorioVista {
        private readonly Panel _contenedorVistas;
        private List<IVista>? _vistas;

        public RepositorioVistaBase(Panel contenedorVistas) {
            _contenedorVistas = contenedorVistas ?? throw new ArgumentNullException(nameof(contenedorVistas));
            Inicializar();
        }

        public List<IVista>? Vistas => _vistas;
        public IVista? VistaActual { get; private set; }

        public void Registrar(string nombre, IVista vista, Point coordenadas, Size dimensiones, string modoRedimensionado = "HV") {
            if (vista is Control control) {
                control.Visible = false;
                control.Tag = modoRedimensionado;

                if (vista is Form vistaForm) {
                    vistaForm.Name = nombre;
                    vistaForm.Location = coordenadas;
                    vistaForm.TopLevel = false;
                    _contenedorVistas.Controls.Add(vistaForm);
                } else if (vista is UserControl vistaUserControl) {
                    vistaUserControl.Name = nombre;
                    vistaUserControl.Location = coordenadas;
                    _contenedorVistas.Controls.Add(vistaUserControl);
                }

                AjustarDimensiones(vista, dimensiones, modoRedimensionado);
                _vistas?.Add(vista);
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
            if (string.IsNullOrEmpty(nombre)) {
                _vistas = new List<IVista>();
            } else {
                Obtener(nombre)?.Inicializar();
            }

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
            if (ocultarTodo) {
                foreach (var control in _contenedorVistas.Controls.OfType<IVista>()) {
                    control.Ocultar();
                    control.Habilitada = true;
                }
            } else {
                if (VistaActual != null) {
                    VistaActual.Ocultar();
                    VistaActual.Habilitada = true;
                }                
            }
        }

        public void Cerrar(bool cerrarTodo = false) {
            if (cerrarTodo) {
                foreach (var control in _contenedorVistas.Controls.OfType<IVista>()) {
                    control.Cerrar();
                    (control as Control)?.Dispose();
                }
            } else {
                VistaActual?.Cerrar();
                (VistaActual as Control)?.Dispose();
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
            foreach (var vista in _vistas.Where(v => !(v is IVistaSubMenu))) {
                if (vista is Control control && control.Tag is string modoRedimensionado) {
                    AjustarDimensiones(vista, vista.Dimensiones, modoRedimensionado);
                }
            }
        }
    }
}