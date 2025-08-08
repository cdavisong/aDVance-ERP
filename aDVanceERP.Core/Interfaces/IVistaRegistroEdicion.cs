namespace aDVanceERP.Core.Interfaces;

public interface IVistaRegistroEdicion : IVista { 
    bool ModoEdicion { get; set; }
    IPanelContenedorVistas ContenedorVistas { get; set; }

    event EventHandler? Registrar;
    event EventHandler? Editar;

    bool VerificarCamposObligatorios();
}