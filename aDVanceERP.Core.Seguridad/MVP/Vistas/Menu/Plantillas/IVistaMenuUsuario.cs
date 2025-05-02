using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Menu.Plantillas {
    public interface IVistaMenuUsuario : IVista {
        string? NombreUsuario { get; set; }
        Image? LogotipoEmpresa { get; set; }
        string? NombreEmpresa { get; set; }
        string? CorreoElectronico { get; set; }
        string? IdEmpresa { get; }

        event EventHandler? CerrarSesion;
        event EventHandler? ConfigurarEmpresa;
    }
}
