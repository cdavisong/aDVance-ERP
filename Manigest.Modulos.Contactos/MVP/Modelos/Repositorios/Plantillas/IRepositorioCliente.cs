using Manigest.Core.MVP.Modelos.Repositorios.Plantillas;
using Manigest.Modulos.Contactos.MVP.Modelos;

namespace Manigest.Modulos.Contactos.MVP.Modelos.Repositorios.Plantillas {
    public interface IRepositorioCliente : IRepositorioDatos<Cliente, CriterioBusquedaCliente> { }
}
