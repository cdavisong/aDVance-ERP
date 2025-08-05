using aDVanceERP.Core.Interfaces.Comun;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas;

public interface IVistaContenedorMenu : IVistaContenedor {
    IRepositorioVista Menus { get; }
}