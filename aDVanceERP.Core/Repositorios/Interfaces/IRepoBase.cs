using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Core.Repositorios.Interfaces {
    public interface IRepoBase<En>
        where En : class, IEntidadBase, new() {
        En Obtener();
        (int cantidad, IEnumerable<En> resultados) ObtenerTodos();
    }
}