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
            
            if (Vista.Vistas != null)
                Vista.Vistas?.Registrar("vistaGestionRolesUsuarios", _gestionRolesUsuarios.Vista);
        }

        private void MostrarVistaGestionRolesUsuarios(object? sender, EventArgs e) {
            if ((_gestionRolesUsuarios?.Vista) == null)
                return;

            _gestionRolesUsuarios.Vista.CargarCriteriosBusqueda(UtilesBusquedaRolUsuario.CriterioBusquedaBusquedaRolUsuario);
            _gestionRolesUsuarios.Vista.Restaurar();
            _gestionRolesUsuarios.Vista.Mostrar();

            _gestionRolesUsuarios.RefrescarListaObjetos();
        }
    }
}
