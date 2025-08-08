namespace aDVanceERP.Core.Interfaces;

public interface IVista : IDisposable {
    Point Coordenadas { get; set; }
    Size Dimensiones { get; set; }
    bool Habilitar { get; set; }
    string Nombre { get; }

    void Inicializar();
    void Mostrar();
    void Ocultar();
    void Restaurar();
}