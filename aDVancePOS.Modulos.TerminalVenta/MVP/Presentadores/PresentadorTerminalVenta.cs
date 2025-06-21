using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta.Plantillas;
using aDVanceERP.Modulos.CompraVenta.Repositorios;

namespace aDVancePOS.Modulos.TerminalVenta.MVP.Presentadores;

public class PresentadorTerminalVenta : PresentadorRegistroBase<IVistaTerminalVenta, Venta, RepoVenta, FbVenta> {
    public PresentadorTerminalVenta(IVistaTerminalVenta vista) : base(vista) { }

    public override void PopularVistaDesdeEntidad(Venta objeto) {
        throw new NotImplementedException();
    }

    protected override async Task<Venta?> ObtenerEntidadDesdeVista() {
        return new Venta(Entidad?.Id ?? 0,
            DateTime.Now,
            await UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacen),
            UtilesCliente.ObtenerIdCliente(Vista.RazonSocialCliente),
            Vista.IdTipoEntrega,
            Vista.Direccion,
            Vista.EstadoEntrega,
            Vista.Total
        );
    }
}

