using Manigest.Core.MVP.Modelos.Repositorios.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Core.MVP.Modelos.Repositorios {
    public sealed class RepositorioVistaBase : IRepositorioVista {
        private readonly Panel _contenedorVistas;

        public RepositorioVistaBase(Panel contenedorVistas) {
            _contenedorVistas = contenedorVistas;

            Inicializar();
        }

        public List<IVista> Vistas { get; private set; }

        public IVista? VistaActual { get; private set; }

        public void Registrar(string nombre, IVista vista, Point coordenadas, Size dimensiones, string modoRedimensionado = "HV") {
            ((Control) vista).Visible = false;
            ((Control) vista).Tag = modoRedimensionado;

            switch (vista) {
                case Form vistaForm:
                    vistaForm.Name = nombre;
                    vistaForm.Location = coordenadas;
                    vistaForm.TopLevel = false;

                    _contenedorVistas.Controls.Add(vistaForm);
                    break;
                case UserControl vistaUserControl:
                    vistaUserControl.Name = nombre;
                    vistaUserControl.Location = coordenadas;

                    _contenedorVistas.Controls.Add(vistaUserControl);
                    break;
            }

            switch (modoRedimensionado) {
                case "HV":
                    vista.Dimensiones = _contenedorVistas.Size;
                    break;
                case "H":
                    vista.Dimensiones = new Size(_contenedorVistas.Size.Width, vista.Dimensiones.Height);
                    break;
                case "V":
                    vista.Dimensiones = new Size(vista.Dimensiones.Width, _contenedorVistas.Size.Height);
                    break;
                default:
                    vista.Dimensiones = new Size(dimensiones.Width, dimensiones.Height);
                    break;
            }

            Vistas.Add(vista);
        }

        public void Registrar(string nombre, IVista vista) {
            Registrar(nombre, vista, new Point(0, 0), _contenedorVistas.Size);
        }

        public IVista? Obtener(string nombre) {
            var paneles = _contenedorVistas.Controls.Find(nombre, false);

            if (paneles[0] is IVista vista)
                return vista;

            return null;
        }

        public void Inicializar(string nombre = "") {
            if (string.IsNullOrEmpty(nombre)) {
                Vistas = new List<IVista>();
            } else
                Obtener(nombre)?.Inicializar();

            // Eventos            
            _contenedorVistas.Resize += ActualizarDimensionesVistas;
        }

        public void Mostrar(string nombre) {
            var vista = Obtener(nombre);

            if (vista == null)
                return;

            vista.Habilitada = true;
            vista.Mostrar();

            VistaActual = vista;
        }

        public void Restaurar(string nombre) {
            var vista = Obtener(nombre);

            if (vista == null)
                return;

            vista.Habilitada = true;
            vista.Restaurar();
        }

        public void Ocultar(bool ocultarTodo = false) {
            if (ocultarTodo)
                foreach (Control control in _contenedorVistas.Controls) {
                    if (control is IVista vista) {
                        vista.Ocultar();
                        vista.Habilitada = true;
                    }
                }
            else if (VistaActual != null) {
                VistaActual.Ocultar();
                VistaActual.Habilitada = true;
            }
        }

        public void ActualizarDimensionesVistas(object? sender, EventArgs e) {
            foreach (var vista in Vistas.Where(vista => !(vista is IVistaSubMenu))) {
                var modoRedimensionado = ((Control) vista)?.Tag?.ToString();

                if (vista == null)
                    return;

                switch (modoRedimensionado) {
                    case "HV":
                        vista.Dimensiones = _contenedorVistas.Size;
                        break;
                    case "H":
                        vista.Dimensiones = new Size(_contenedorVistas.Size.Width, vista.Dimensiones.Height);
                        break;
                    case "V":
                        vista.Dimensiones = new Size(vista.Dimensiones.Width, _contenedorVistas.Size.Height);
                        break;
                    default:
                        vista.Dimensiones = new Size(vista.Dimensiones.Width, vista.Dimensiones.Height);
                        break;
                }

            }

        }

        public void Cerrar(bool cerrarTodo = false) {
            if (cerrarTodo) {
                foreach (Control control in _contenedorVistas.Controls) {
                    if (control is IVista vista) {
                        vista.Cerrar();
                        control?.Dispose();
                    }
                }
            } else {
                VistaActual?.Cerrar();
                (VistaActual as Control)?.Dispose();
            }
        }
    }
}
