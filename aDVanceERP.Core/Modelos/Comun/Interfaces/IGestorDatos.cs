namespace aDVanceERP.Core.Modelos.Comun.Interfaces;

public interface IGestorDatos
{
    event EventHandler? RegistrarDatos;
    event EventHandler? EditarDatos;
    event EventHandler? EliminarDatos;
}