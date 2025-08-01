using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas; 

public interface IVistaGestionMovimientos : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaMovimiento>,
    IGestorTablaDatos { }