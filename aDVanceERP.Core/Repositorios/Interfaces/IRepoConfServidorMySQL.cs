using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Core.Repositorios.Interfaces {
    public interface IRepoConfServidorMySQL<En> : IRepoBase<En>
        where En : class, IEntidad, new() {

        void Salvar(string directorio, En entidad);
    }
}