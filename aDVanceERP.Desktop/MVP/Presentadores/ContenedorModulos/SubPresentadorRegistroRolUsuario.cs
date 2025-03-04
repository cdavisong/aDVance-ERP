using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroRolUsuario _registroRolUsuario;

        public List<string[]>? Permisos { get; private set; } = new List<string[]>();

        private void InicializarVistaRegistroRolUsuario() { 
            _registroRolUsuario = new PresentadorRegistroRolUsuario(new VistaRegistroRolUsuario());
            _registroRolUsuario.Vista.CargarNombresModulos(UtilesModulo.ObtenerNombresModulos());
            _registroRolUsuario.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroRolUsuario.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroRolUsuario.Vista.Dimensiones = new Size(_registroRolUsuario.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
            _registroRolUsuario.DatosRegistradosActualizados += delegate {
                Permisos = _registroRolUsuario.Vista.Permisos;

                RegistrarEditarPermisosRol(UtilesRolUsuario.ObtenerIdRolUsuario(_registroRolUsuario.Vista.NombreRolUsuario));
            };
            _registroRolUsuario.Salir += delegate { 
                _gestionRolesUsuarios.RefrescarListaObjetos(); 
            };            
        }

        private void MostrarVistaRegistroRolUsuario(object? sender, EventArgs e) {
            InicializarVistaRegistroRolUsuario();

            _registroRolUsuario.Vista.Mostrar();
            _registroRolUsuario = null;
        }

        private void MostrarVistaEdicionRolUsuario(object? sender, EventArgs e) {
            InicializarVistaRegistroRolUsuario();

            _registroRolUsuario.PopularVistaDesdeObjeto(sender as RolUsuario);            
            _registroRolUsuario.Vista.Mostrar();
            _registroRolUsuario = null;
        }

        private void RegistrarEditarPermisosRol(long idRolUsuario = 0) {
            if (Permisos?.Count == 0)
                return;

            // Si idRolUsuario es 0, se asume que es un rol nuevo
            bool esRolNuevo = idRolUsuario == 0;

            if (esRolNuevo) {
                idRolUsuario = UtilesBD.ObtenerUltimoIdTabla("rol_usuario");
            } else {
                using (var datosPermisoRolUsuario = new DatosPermisoRolUsuario()) {
                    datosPermisoRolUsuario.EliminarPorRol(idRolUsuario);
                }
            }

            foreach (var permiso in Permisos) {
                var permisoRolUsuario = new PermisoRolUsuario(
                    0, // ID se generará automáticamente en la base de datos
                    idRolUsuario,
                    long.Parse(permiso[0])
                );

                using (var datosPermisoRolUsuario = new DatosPermisoRolUsuario()) {
                    datosPermisoRolUsuario.Adicionar(permisoRolUsuario);
                }
            }

            Permisos?.Clear();
        }
    }
}
