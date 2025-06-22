using aDVanceERP.Core.Repositorios.Plantillas;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas; 

public interface IVistaContenedorMenu : IVistaContenedor {
    IRepositorioVista Menus { get; }
}