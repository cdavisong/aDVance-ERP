using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas;

public interface IVistaContenedorMenu : IVistaContenedor {
    IRepoVista Menus { get; }
}