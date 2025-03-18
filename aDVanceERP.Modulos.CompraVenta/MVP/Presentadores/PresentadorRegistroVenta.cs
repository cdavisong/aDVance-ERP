using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleVentaArticulo.Plantillas;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores {
    public class PresentadorRegistroVenta : PresentadorRegistroBase<IVistaRegistroVenta, Venta, DatosVenta, CriterioBusquedaVenta> {
        public PresentadorRegistroVenta(IVistaRegistroVenta vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Venta objeto) {
            Vista.RazonSocialCliente = UtilesCliente.ObtenerRazonSocialCliente(objeto.IdCliente) ?? string.Empty;
            Vista.NombreAlmacen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacen) ?? string.Empty;
            Vista.ModoEdicionDatos = true;

            var articulosVenta = UtilesVenta.ObtenerArticulosPorVenta(objeto.Id);

            foreach (var articulo in articulosVenta) {
                var articuloSplit = articulo.Split(':');
                ((IVistaGestionDetallesVentaArticulos) Vista).AdicionarArticulo(Vista.NombreAlmacen, articuloSplit[0], articuloSplit[1]);
            }

            _objeto = objeto;
        }

        protected override async Task<Venta?> ObtenerObjetoDesdeVista() {
            return new Venta(_objeto?.Id ?? 0,
                   fecha: DateTime.Now,
                   idAlmacen: await UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacen),
                   idCliente: await UtilesCliente.ObtenerIdCliente(Vista.RazonSocialCliente),
                   total: Vista.Total
               );
        }
    }
}
