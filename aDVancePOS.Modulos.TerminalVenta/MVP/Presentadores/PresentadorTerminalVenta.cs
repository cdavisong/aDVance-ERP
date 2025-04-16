using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta.Plantillas;

namespace aDVancePOS.Modulos.TerminalVenta.MVP.Presentadores;

public class PresentadorTerminalVenta : PresentadorRegistroBase<IVistaTerminalVenta, Venta, DatosVenta, CriterioBusquedaVenta> {
    public PresentadorTerminalVenta(IVistaTerminalVenta vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(Venta objeto) {
        throw new NotImplementedException();
    }

    protected override async Task<Venta?> ObtenerObjetoDesdeVista() {
        return new Venta(Objeto?.Id ?? 0,
            DateTime.Now,
            0, //await UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacen),
            0, //UtilesCliente.ObtenerIdCliente(Vista.RazonSocialCliente),
            Vista.IdTipoEntrega,
            "", //Vista.Direccion,
            "", //Vista.EstadoEntrega,
            Vista.Total
        );
    }
}

