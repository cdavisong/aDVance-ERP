using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.MVP.Presentadores.ContenedorSeguridad;
using aDVanceERP.Desktop.MVP.Vistas.ContenedorSeguridad;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;

namespace aDVanceERP.Desktop.MVP.Presentadores.Principal; 

public partial class PresentadorPrincipal {
    private PresentadorContenedorSeguridad? _contenedorSeguridad;

    private void InicializarVistaContenedorSeguridad() {
        _contenedorSeguridad = new PresentadorContenedorSeguridad(Vista, new VistaContenedorSeguridad());
        _contenedorSeguridad.UsuarioAutenticado += delegate (object? sender, EventArgs e) {
            // Verificar el registro de la empresa y mostrar la vista de Login
            using (var datosEmpresa = new RepoEmpresa()) {
                if (datosEmpresa.Cantidad() == 0)
                    MostrarVistaRegistroEmpresa(this, EventArgs.Empty);
                else _isRegistroEmpresa = true;
            }

            if (_isRegistroEmpresa) {
                MostrarVistaContenedorModulos(sender, e);

                if (_menuUsuario != null)
                    _menuUsuario.Vista.NombreUsuario = UtilesCuentaUsuario.UsuarioAutenticado?.Nombre;

                ActualizarRepoEmpresa();
            } else return;
        };

        Vista.Vistas?.Registrar("vistaContenedorSeguridad", _contenedorSeguridad.Vista);
    }

    private void MostrarVistaContenedorSeguridad(object? sender, EventArgs e) {
        if (_contenedorSeguridad == null)
            return;

        _contenedorSeguridad.Vista.Restaurar();
        _contenedorSeguridad.Vista.Mostrar();

        // Mostrar el botón de sub-menu para usuarios
        Vista.BtnSubmenuUsuarioDisponible = false;
    }

    private void ActualizarRepoEmpresa() {
        using (var datosEmpresa = new RepoEmpresa()) {
            _empresa = datosEmpresa.Buscar().resultados.FirstOrDefault();

            if (_menuUsuario != null && _empresa != null) {
                _menuUsuario.Vista.LogotipoEmpresa = _empresa.Logotipo;
                _menuUsuario.Vista.NombreEmpresa = _empresa.Nombre;
                _menuUsuario.Vista.CorreoElectronico = UtilesContacto.ObtenerCorreoElectronicoContacto(_empresa.IdContacto);

                // Actualizar el id de la empresa
                IdEmpresa = _menuUsuario.Vista.IdEmpresa;
            }
        }
    }
}