using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Core.Repositorios.Interfaces {
    public interface IRepoConfiguracionBaseDatos<En> : IRepoBase<En>
        where En : class, IEntidadBase, new() {

        void Salvar(string directorio, En entidad);
    }
}