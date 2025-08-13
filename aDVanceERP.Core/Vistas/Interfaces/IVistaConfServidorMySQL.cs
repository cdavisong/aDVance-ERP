using aDVanceERP.Core.Modelos.BD;

namespace aDVanceERP.Core.Vistas.Interfaces {
    public interface IVistaConfServidorMySQL : IVistaBase {
        string? NombreDireccionServidor { get; set; }
        string? NombreBaseDatos { get; set; }
        string? NombreUsuario { get; set; }
        string? Password { get; }
        bool RecordarConfiguracion { get; set; }

        event EventHandler<ConfServidorMySQL>? AlmacenarConfiguracion;
    }
}