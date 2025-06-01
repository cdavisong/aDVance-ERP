using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion.Plantillas;
using aDVanceERP.Core.Seguridad.Utiles;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores; 

public class PresentadorRegistroUsuario : PresentadorRegistroBase<IVistaRegistroUsuario, CuentaUsuario,
    DatosCuentaUsuario, CriterioBusquedaCuentaUsuario> {
    public PresentadorRegistroUsuario(IVistaRegistroUsuario vista) : base(vista) {
        vista.RegistrarDatos += delegate(object? sender, EventArgs args) {
            UsuarioRegistrado?.Invoke(sender, args); 
        };
        vista.AutenticarUsuario += delegate(object? sender, EventArgs args) {
            MostrarVistaAutenticacionUsuario?.Invoke("autenticate-user", args);
        };
    }

    public event EventHandler? UsuarioRegistrado;
    public event EventHandler? MostrarVistaAutenticacionUsuario;

    public override void PopularVistaDesdeObjeto(CuentaUsuario objeto) {
        throw new NotImplementedException();
    }

    protected override void RegistroAuxiliar(DatosCuentaUsuario datosCuentaUsuario, long id) {
        UsuarioRegistrado?.Invoke("register-user", EventArgs.Empty);
    }

    protected override async Task<CuentaUsuario?> ObtenerObjetoDesdeVista() {
        try {
            if (await UtilesCuentaUsuario.EsTablaCuentasUsuarioVacia()) {
                if (Vista.Password != null)
                    await UtilesCuentaUsuario.CrearUsuarioAdministrador(Vista.NombreUsuario, Vista.Password);

                UsuarioRegistrado?.Invoke("register-admin", EventArgs.Empty);

                return null;
            }
        }
        catch (ExcepcionConexionServidorMySQL e) {
            CentroNotificaciones.Mostrar(e.Message, TipoNotificacion.Error);
        }

        var passwordSeguro = UtilesPassword.HashPassword(Vista.Password);

        return new CuentaUsuario(Objeto?.Id ?? 0,
            Vista.NombreUsuario,
            passwordSeguro.hash,
            passwordSeguro.salt,
            0
        );
    }
}