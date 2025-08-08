using aDVanceERP.Core.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;

public class PresentadorTuplaCompra : PresentadorVistaTuplaBase<IVistaTuplaCompra, Compra> {
    public PresentadorTuplaCompra(IVistaTuplaCompra vista, Compra objeto) : base(vista, objeto) { }
}