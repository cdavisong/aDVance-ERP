namespace Manigest.Core.MVP.Modelos.Plantillas {
    public interface IGestorDatos {
        event EventHandler RegistrarDatos;
        event EventHandler EditarDatos;
        event EventHandler EliminarDatos;
    }
}
