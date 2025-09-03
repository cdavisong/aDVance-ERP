using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores; 

public class PresentadorTuplaProducto : PresentadorTuplaBase<IVistaTuplaProducto, Producto> {
    public PresentadorTuplaProducto(IVistaTuplaProducto vista, Producto objeto) : base(vista, objeto) { }
}