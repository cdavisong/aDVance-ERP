namespace aDVanceERP.Core.Vistas.Interfaces;

public interface IVistaTupla : IVistaBase {
    Color ColorFondoTupla { get; set; }

    event EventHandler? TuplaSeleccionada;
    event EventHandler? EditarDatosTupla;
    event EventHandler? EliminarDatosTupla;
}