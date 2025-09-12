using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Core.Vistas.Interfaces; 

public interface IVistaBase : IEntidadBase {
    bool Habilitada { get; set; }
    Point Coordenadas { get; set; }
    Size Dimensiones { get; set; }

    void Inicializar();
    void Mostrar();
    void Restaurar();
    void Ocultar();
    void Cerrar();
}