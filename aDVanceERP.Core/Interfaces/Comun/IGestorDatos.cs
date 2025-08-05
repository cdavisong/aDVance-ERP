namespace aDVanceERP.Core.Interfaces.Comun;

public interface IGestorDatos
{
    event EventHandler? RegistrarDatos;
    event EventHandler? EditarDatos;
    event EventHandler? EliminarDatos;
}