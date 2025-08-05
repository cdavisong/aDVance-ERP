using aDVanceERP.Core.Interfaces.Comun;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;

public interface IVistaGestionMovimientos : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaMovimiento>,
    IGestorTablaDatos { }