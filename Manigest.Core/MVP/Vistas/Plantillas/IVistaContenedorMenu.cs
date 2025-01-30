using Manigest.Core.MVP.Modelos.Repositorios.Plantillas;

namespace Manigest.Core.MVP.Vistas.Plantillas {
    public interface IVistaContenedorMenu : IVistaContenedor {
        IRepositorioVista Menus { get; }
    }
}
