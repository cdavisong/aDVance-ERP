using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas {
    public interface IRepositorioDatos<O, C> : IDisposable
        where O : class, IObjetoUnico, new()
        where C : Enum {
        List<O> Objetos { get; }

        long Cantidad();
        long Adicionar(O objeto);
        bool Editar(O objeto, long nuevoId = 0);
        bool Eliminar(long id);
        IEnumerable<O> Obtener(string? textoComando = "", int limite = 0, int desplazamiento = 0);
        IEnumerable<O> Obtener(C? criterio, string? dato, int limite = 0, int desplazamiento = 0);
        bool Existe(string dato);

        Task<long> CantidadAsync();
        Task<long> AdicionarAsync(O objeto);
        Task<bool> EditarAsync(O objeto, long nuevoId = 0);
        Task<bool> EliminarAsync(long id);
        Task<IEnumerable<O>> ObtenerAsync(C? criterio, string? dato, out int totalFilas, int limite = 0, int desplazamiento = 0);
        Task<bool> ExisteAsync(string dato);
    }
}