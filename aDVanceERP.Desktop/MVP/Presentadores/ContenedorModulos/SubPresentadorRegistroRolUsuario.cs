using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroRolUsuario _registroRolUsuario;

        public List<string[]>? Permisos { get; private set; } = new List<string[]>();

        private async Task InicializarVistaRegistroRolUsuario() {
            _registroRolUsuario = new PresentadorRegistroRolUsuario(new VistaRegistroRolUsuario());

            // Configurar coordenadas y dimensiones de la vista
            _registroRolUsuario.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
            _registroRolUsuario.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroRolUsuario.Vista.CargarNombresModulos(UtilesModulo.ObtenerNombresModulos());
            _registroRolUsuario.DatosRegistradosActualizados += delegate {
                Permisos = _registroRolUsuario.Vista.Permisos;

                RegistrarEditarPermisosRol(UtilesRolUsuario.ObtenerIdRolUsuario(_registroRolUsuario.Vista.NombreRolUsuario));
            };
            _registroRolUsuario.Salir += async (sender, e) => {
                if (_gestionRolesUsuarios != null) {
                    await _gestionRolesUsuarios.RefrescarListaObjetos();
                }
            };
        }

        private async void MostrarVistaRegistroRolUsuario(object? sender, EventArgs e) {
            await InicializarVistaRegistroRolUsuario();

            if (_registroRolUsuario != null) {
                _registroRolUsuario.Vista.Mostrar();
            }

            _registroRolUsuario?.Dispose();
        }

        private async void MostrarVistaEdicionRolUsuario(object? sender, EventArgs e) {
            await InicializarVistaRegistroRolUsuario();

            if (_registroRolUsuario != null && sender is RolUsuario rolUsuario) {
                _registroRolUsuario.PopularVistaDesdeObjeto(rolUsuario);
                _registroRolUsuario.Vista.Mostrar();
            }

            _registroRolUsuario?.Dispose();
        }

        private void RegistrarEditarPermisosRol(long idRolUsuario = 0) {
            if (Permisos == null || Permisos.Count == 0)
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

            Permisos.Clear();
        }
    }
}
