using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores {
    public class PresentadorRegistroCompra : PresentadorRegistroBase<IVistaRegistroCompra, Compra, DatosCompra, CriterioBusquedaCompra> {
        public PresentadorRegistroCompra(IVistaRegistroCompra vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Compra objeto) {
            Vista.RazonSocialProveedor = UtilesProveedor.ObtenerRazonSocialProveedor(objeto.IdProveedor) ?? string.Empty;
            Vista.NombreAlmacen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacen) ?? string.Empty;
            Vista.NombreArticulo = UtilesArticulo.ObtenerNombreArticulo(objeto.IdArticulo).Result ?? string.Empty;
            Vista.Cantidad = objeto.Cantidad;
            Vista.ModoEdicionDatos = true;

            Objeto = objeto;
        }

        protected override async Task<Compra?> ObtenerObjetoDesdeVista() {
            return new Compra(Objeto?.Id ?? 0,
                   fecha: DateTime.Now,
                   idAlmacen: await UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacen),
                   idProveedor: await UtilesProveedor.ObtenerIdProveedor(Vista.RazonSocialProveedor),
                   idArticulo: await UtilesArticulo.ObtenerIdArticulo(Vista.NombreArticulo),
                   cantidad: Vista.Cantidad,
                   total: Vista.Total
               );
        }
    }
}
