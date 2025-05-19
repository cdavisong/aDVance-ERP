using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas;
using aDVanceERP.Modulos.Finanzas.Properties;

namespace aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja {
    public partial class VistaTuplaCaja : Form, IVistaTuplaCaja {
        private int _estado;

        public VistaTuplaCaja() {
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

        public string FechaApertura {
            get => fieldFechaApertura.Text;
            set => fieldFechaApertura.Text = value;
        }

        public string SaldoInicial { 
            get => fieldSaldoInicial.Text;
            set => fieldSaldoInicial.Text = value;
        }

        public string SaldoActual { 
            get => fieldSaldoActual.Text;
            set => fieldSaldoActual.Text = value;
        }

        public string FechaCierre { 
            get => fieldFechaCierre.Text;
            set => fieldFechaCierre.Text = value;
        }

        public int Estado { 
            get => _estado;
            set {
                _estado = value;

                btnDescargarInforme.Enabled = _estado == 2;
                fieldEstado.Image = _estado switch {
                    0 => Resources.open_check_20px,
                    1 => Resources.open_sign_20px,
                    2 => Resources.closed_sign_20px,
                    _ => Resources.open_check_20px
                };
                
            }
        }

        public string NombreUsuario {
            get => fieldNombreUsuario.Text;
            set => fieldNombreUsuario.Text = value;
        }

        public Color ColorFondoTupla {
            get => layoutVista.BackColor;
            set => layoutVista.BackColor = value;
        }        

        public event EventHandler? TuplaSeleccionada;
        public event EventHandler? EditarDatosTupla;
        public event EventHandler? EliminarDatosTupla;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            fieldId.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldFechaApertura.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldSaldoInicial.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldSaldoActual.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldFechaCierre.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldEstado.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldNombreUsuario.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };

            btnEditar.Click += delegate (object? sender, EventArgs e) {
                EditarDatosTupla?.Invoke(this, e);
            };
            btnEliminar.Click += delegate (object? sender, EventArgs e) {
                EliminarDatosTupla?.Invoke(this, e);
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
            btnEditar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_FINANZAS_CAJA_EDITAR")
                                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_FINANZAS_CAJA_TODOS")
                                || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_FINANZAS_TODOS");
            btnEliminar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                                  || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_FINANZAS_CAJA_ELIMINAR")
                                  || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_FINANZAS_CAJA_TODOS")
                                  || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_FINANZAS_TODOS");
        }
    }
}
