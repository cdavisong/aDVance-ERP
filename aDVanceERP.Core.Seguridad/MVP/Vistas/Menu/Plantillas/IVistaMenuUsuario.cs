using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Menu.Plantillas {
    public interface IVistaMenuUsuario : IVista {
        Image? LogotipoEmpresa { get; set; }
        string? NombreEmpresa { get; set; }
        string? CorreoElectronico { get; set; }

        event EventHandler? CerrarSesion;
        event EventHandler? ConfigurarEmpresa;
    }
}
