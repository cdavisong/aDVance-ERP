using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;

namespace aDVanceERP.Modulos.Inventario.Repositorios.Plantillas;

public interface IRepositorioProducto : IRepositorioDatos<Producto, CriterioBusquedaProducto> { }