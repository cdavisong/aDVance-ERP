using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorGestionCuentasUsuarios? _gestionCuentasUsuarios;

    private async void InicializarVistaGestionCuentasUsuarios() {
        _gestionCuentasUsuarios = new PresentadorGestionCuentasUsuarios(new VistaGestionCuentasUsuarios());
        _gestionCuentasUsuarios.EditarEntidad += MostrarVistaEdicionCuentaUsuario;
        _gestionCuentasUsuarios.Vista.RegistrarDatos += MostrarVistaRegistroCuentaUsuario;

        if (Vista.Vistas != null)
            await Task.Run(() => Vista.Vistas?.Registrar("vistaGestionCuentasUsuarios", _gestionCuentasUsuarios.Vista));
    }

    private async void MostrarVistaGestionCuentasUsuarios(object? sender, EventArgs e) {
        if (_gestionCuentasUsuarios?.Vista == null)
            return;

        _gestionCuentasUsuarios.Vista.CargarCriteriosBusqueda(UtilesBusquedaCuentaUsuario.FbCuentasUsuarios);
        _gestionCuentasUsuarios.Vista.Restaurar();
        _gestionCuentasUsuarios.Vista.Mostrar();

        await _gestionCuentasUsuarios.PopularTuplasDatosEntidades();
    }
}