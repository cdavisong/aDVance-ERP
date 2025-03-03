using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionRolesUsuarios _gestionRolesUsuarios;

        private void InicializarVistaGestionRolesUsuarios() {
            _gestionRolesUsuarios = new PresentadorGestionRolesUsuarios(new VistaGestionRolesUsuarios());
            _gestionRolesUsuarios.EditarObjeto += MostrarVistaEdicionRolUsuario;
            _gestionRolesUsuarios.Vista.RegistrarDatos += MostrarVistaRegistroRolUsuario;
            _gestionRolesUsuarios.Vista.CargarCriteriosBusqueda(UtilesBusquedaRolUsuario.CriterioBusquedaBusquedaRolUsuario);

            Vista.Vistas?.Registrar("vistaGestionRolesUsuarios", _gestionRolesUsuarios.Vista);
        }

        private void MostrarVistaGestionRolesUsuarios(object? sender, EventArgs e) {
            _gestionRolesUsuarios.Vista.Mostrar();
            _gestionRolesUsuarios.Vista.Restaurar();
            _gestionRolesUsuarios.RefrescarListaObjetos();
        }
    }
}
