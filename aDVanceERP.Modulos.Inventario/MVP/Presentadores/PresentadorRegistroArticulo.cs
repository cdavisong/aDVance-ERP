using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorRegistroArticulo : PresentadorRegistroBase<IVistaRegistroArticulo, Articulo, DatosArticulo, CriterioBusquedaArticulo> {
        public PresentadorRegistroArticulo(IVistaRegistroArticulo vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Articulo objeto) {
            Vista.ModoEdicionDatos = true;
            Vista.Codigo = objeto.Codigo ?? string.Empty;
            Vista.Nombre = objeto.Nombre ?? string.Empty;
            Vista.Descripcion = objeto.Descripcion ?? string.Empty;
            Vista.RazonSocialProveedor = UtilesProveedor.ObtenerRazonSocialProveedor(objeto.IdProveedor) ?? string.Empty;
            Vista.PrecioAdquisicion = objeto.PrecioAdquisicion;
            Vista.PrecioCesion = objeto.PrecioCesion;
            Vista.StockMinimo = objeto.StockMinimo;
            Vista.PedidoMinimo = objeto.PedidoMinimo;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override async Task<Articulo?> ObtenerObjetoDesdeVista() {
            return new Articulo(
                _objeto?.Id ?? 0,
                codigo: Vista.Codigo,
                nombre: Vista.Nombre,
                descripcion: Vista.Descripcion,
                idProveedor: await UtilesProveedor.ObtenerIdProveedor(Vista.RazonSocialProveedor),
                precioAdquisicion: Vista.PrecioAdquisicion,
                precioCesion: Vista.PrecioCesion,
                stockMinimo: Vista.StockMinimo,
                pedidoMinimo: Vista.PedidoMinimo
            );
        }
    }
}
