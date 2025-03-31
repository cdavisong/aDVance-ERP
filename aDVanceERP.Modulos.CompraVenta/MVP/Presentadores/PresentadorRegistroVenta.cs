using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaArticulo.Plantillas;
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

            foreach (var articuloSplit in articulosVenta.Select(articulo => articulo.Split(':'))) {
                ((IVistaGestionDetallesCompraventaArticulos) Vista).AdicionarArticulo(Vista.NombreAlmacen, articuloSplit[0], articuloSplit[1]);
            }

            Objeto = objeto;
        }

        protected override async Task<Venta?> ObtenerObjetoDesdeVista() {
            return new Venta(Objeto?.Id ?? 0,
                   fecha: DateTime.Now,
                   idAlmacen: await UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacen),
                   idCliente: await UtilesCliente.ObtenerIdCliente(Vista.RazonSocialCliente),
                   total: Vista.Total
               );
        }
    }
}
