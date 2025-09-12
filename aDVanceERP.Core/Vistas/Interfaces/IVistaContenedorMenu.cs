using aDVanceERP.Core.Repositorios.Comun;

namespace aDVanceERP.Core.Vistas.Interfaces;

public interface IVistaContenedorMenu : IVistaContenedor {
    RepoVistaBase Menus { get; }
}