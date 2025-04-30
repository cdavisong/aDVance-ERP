using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Menu.Plantillas {
    public interface IVistaMenuUsuario : IVista {
        Image? ImagenPerfil { get; }
        string? NombreApellidos { get; }
        string? CorreoElectronico { get; }

        event EventHandler? CerrarSesion;
        event EventHandler? ConfigurarCuenta;

        //void CargarDatosPerfil(PerfilUsuario perfil);
    }
}
