using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas; 

public interface IRepoVista : IDisposable {
    List<IVistaBase>? Vistas { get; }
    IVistaBase? VistaActual { get; }

    void Registrar(string nombre, IVistaBase vista);
    void Registrar(string nombre, IVistaBase vista, Point coordenadas, Size dimensiones, string modoRedimensionado = "HV");
    IVistaBase? Obtener(string nombre);
    void Inicializar(string nombre = "");
    void Mostrar(string nombre);
    void Restaurar(string nombre);
    void Ocultar(bool ocultarTodo = false);
    void Cerrar(bool cerrarTodo = false);
}