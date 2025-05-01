using aDVanceERP.Core.MVP.Vistas.Plantillas;

using Guna.UI2.WinForms;

namespace aDVanceERP.Desktop.MVP.Vistas.Principal.Plantillas; 

public interface IVistaPrincipal : IVistaContenedorMenu {
    Guna2CirclePictureBox BtnSubmenuUsuario { get; }
    bool BtnSubmenuUsuarioDisponible { get; set; }
    bool ServicioTelegramActivo { get; set; }

    event EventHandler? VerNotificaciones;
    event EventHandler? VerMensajes;
    event EventHandler? SubMenuUsuario;
}