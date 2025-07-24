using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

namespace aDVanceERP.Modulos.Inventario.Repositorios.Plantillas
{
    public interface IRepositorioDetalleProducto : IRepositorioDatos<DetalleProducto, CriterioBusquedaDetalleProducto> { }
}
