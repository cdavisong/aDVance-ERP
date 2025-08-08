namespace aDVanceERP.Core.Interfaces;

public interface IVistaTupla : IVista {
    TableLayoutPanel PanelDatosTupla { get; }
    Color ColorFondo { get; set; }

    event EventHandler? EditarTuplaDatos;
    event EventHandler? EliminarTuplaDatos;

    void VerificarPermisos();
}