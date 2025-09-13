using aDVanceERP.Core.Presentadores.Comun;
using aDVanceERP.Core.Vistas.BD;
using aDVanceERP.Core.Vistas.Comun.Interfaces;
using aDVanceERP.Desktop.MVP.Vistas.ContenedorSeguridad.Plantillas;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorSeguridad;

public partial class PresentadorContenedorSeguridad : PresentadorVistaBase<IVistaContenedorSeguridad> {
    private VistaConfiguracionBaseDatos? _vistaConfiguracionBaseDatos;

    public PresentadorContenedorSeguridad(IVistaPrincipal vistaPrincipal, IVistaContenedorSeguridad vista) :
        base(vista) {
        VistaPrincipal = vistaPrincipal;

        // Eventos
        #region Gestión de conexión a la base de datos

        _vistaConfiguracionBaseDatos = new VistaConfiguracionBaseDatos();
        _vistaConfiguracionBaseDatos.ConfiguracionCargada += (s, e) => {
            // Ocultar la vista de configuración de base de datos
            _vistaConfiguracionBaseDatos.Ocultar();

            // Mostrar la vista de autenticación de usuario
            MostrarVistaAutenticacionUsuario("first-login", EventArgs.Empty);
        };

        Vista.Vistas?.Registrar("vistaConfiguracionBaseDatos", _vistaConfiguracionBaseDatos);

        #endregion
        #region Gestión de autenticación y registro primario de usuarios

        InicializarVistaAutenticacionUsuario();
        InicializarVistaRegistroUsuario();
        InicializarVistaAprobacionUsuario();

        #endregion

        // Otros
        _vistaConfiguracionBaseDatos.Mostrar();
    }

    private IVistaPrincipal VistaPrincipal { get; }

    public override void Dispose() {
        //...
    }
}