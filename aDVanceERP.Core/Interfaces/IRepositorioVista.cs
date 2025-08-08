namespace aDVanceERP.Core.Interfaces;

public interface IRepositorioVista : IDisposable {
    List<IVista>? Vistas { get; }
    IVista? VistaActual { get; }

    void Registrar(string nombre, IVista vista);
    void Registrar(string nombre, IVista vista, Point coordenadas, Size dimensiones, string modoRedimensionado = "HV");
    IVista? Obtener(string nombre);
    void Inicializar(string nombre = "");
    void Mostrar(string nombre);
    void Restaurar(string nombre);
    void Ocultar(bool ocultarTodo = false);
    void Cerrar(bool cerrarTodo = false);
}