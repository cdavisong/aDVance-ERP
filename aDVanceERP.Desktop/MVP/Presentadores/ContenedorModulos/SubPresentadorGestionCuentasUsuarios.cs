using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionCuentasUsuarios _gestionCuentasUsuarios;

        private void InicializarVistaGestionCuentasUsuarios() {
            _gestionCuentasUsuarios = new PresentadorGestionCuentasUsuarios(new VistaGestionCuentasUsuarios());
            _gestionCuentasUsuarios.EditarObjeto += MostrarVistaEdicionCuentaUsuario;
            _gestionCuentasUsuarios.Vista.RegistrarDatos += MostrarVistaRegistroCuentaUsuario;
            _gestionCuentasUsuarios.Vista.CargarCriteriosBusqueda(UtilesBusquedaCuentaUsuario.CriterioBusquedaBusquedaCuentaUsuario);

            Vista.Vistas?.Registrar("vistaGestionCuentasUsuarios", _gestionCuentasUsuarios.Vista);
        }

        private void MostrarVistaGestionCuentasUsuarios(object? sender, EventArgs e) {
            _gestionCuentasUsuarios.Vista.Mostrar();
            _gestionCuentasUsuarios.Vista.Restaurar();
            _gestionCuentasUsuarios.RefrescarListaObjetos();
        }
    }
}
