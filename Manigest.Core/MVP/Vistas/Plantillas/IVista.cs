using System.Drawing;

namespace Manigest.Core.MVP.Vistas.Plantillas {
    public interface IVista {
        bool Habilitada { get; set; }
        Point Coordenadas { get; set; }
        Size Dimensiones { get; set; }

        event EventHandler Salir;

        void Inicializar();
        void Mostrar();
        void Restaurar();
        void Ocultar();
        void Cerrar();
    }
}
