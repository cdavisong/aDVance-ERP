using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Core.Repositorios.Interfaces {
    public interface IRepoBase<En> : IDisposable
        where En : class, IEntidadBase, new() {
        En? ObtenerPorId(object? id);
        IEnumerable<En> ObtenerTodos();
    }
}