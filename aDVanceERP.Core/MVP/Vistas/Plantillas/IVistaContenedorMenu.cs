using aDVanceERP.Core.Repositorios.Comun;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas;

public interface IVistaContenedorMenu : IVistaContenedor {
    RepoVistaBase Menus { get; }
}