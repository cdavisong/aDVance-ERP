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
            Vista.NombreArticulo = UtilesArticulo.ObtenerNombreArticulo(objeto.IdArticulo) ?? string.Empty;
            Vista.Cantidad = objeto.Cantidad;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override Compra? ObtenerObjetoDesdeVista() {
            return new Compra(_objeto?.Id ?? 0,
                   fecha: DateTime.Now,
                   idAlmacen: UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacen),
                   idProveedor: UtilesProveedor.ObtenerIdProveedor(Vista.RazonSocialProveedor),
                   idArticulo: UtilesArticulo.ObtenerIdArticulo(Vista.NombreArticulo),
                   cantidad: Vista.Cantidad,
                   total: Vista.Total
               );
        }
    }
}
