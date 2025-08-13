namespace aDVanceERP.Core.Vistas.Interfaces; 

public interface IVistaBase {
    bool Habilitada { get; set; }
    Point Coordenadas { get; set; }
    Size Dimensiones { get; set; }

    void Inicializar();
    void Mostrar();
    void Restaurar();
    void Ocultar();
    void Cerrar();
}