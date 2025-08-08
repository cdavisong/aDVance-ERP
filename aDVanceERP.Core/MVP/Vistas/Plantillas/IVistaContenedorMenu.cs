using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas;

public interface IVistaContenedorMenu : IVistaContenedor {
    IRepositorioVista Menus { get; }
}