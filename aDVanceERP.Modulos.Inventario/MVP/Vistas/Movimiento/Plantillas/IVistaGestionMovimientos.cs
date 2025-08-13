using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas; 

public interface IVistaGestionMovimientos : IVistaContenedor, IGestorDatos, IBuscadorDatos<FiltroBusquedaMovimiento>,
    IGestorTablaDatos { }