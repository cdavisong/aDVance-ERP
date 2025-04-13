using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;

namespace aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta.Plantillas; 

public interface IVistaRegistroVenta : IVistaRegistro, IBuscadorDatos<CriterioBusquedaVenta> {
    
}