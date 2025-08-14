using aDVanceERP.Core.Repositorios.Interfaces;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

namespace aDVanceERP.Modulos.Inventario.Repositorios.Plantillas;

public interface IRepositorioMovimiento : IRepoEntidadBaseDatos<Movimiento, FiltroBusquedaMovimiento> { }