using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Modelos.Repositorios;
using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas;
using Manigest.Core.Utiles.Datos;

namespace Manigest.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorRegistroArticulo : PresentadorRegistroBase<IVistaRegistroArticulo, Articulo, DatosArticulo, CriterioBusquedaArticulo> {
        public PresentadorRegistroArticulo(IVistaRegistroArticulo vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Articulo objeto) {
            Vista.Codigo = objeto.Codigo;
            Vista.Nombre = objeto.Nombre;
            Vista.Descripcion = objeto.Descripcion;
            Vista.RazonSocialProveedor = UtilesProveedor.ObtenerRazonSocialProveedor(objeto.IdProveedor) ?? string.Empty;
            Vista.PrecioAdquisicion = objeto.PrecioAdquisicion;
            Vista.PrecioCesion = objeto.PrecioCesion;
            Vista.StockMinimo = objeto.StockMinimo;
            Vista.PedidoMinimo = objeto.PedidoMinimo;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override Articulo ObtenerObjetoDesdeVista() {
            return new Articulo(
                _objeto?.Id ?? 0,
                codigo: Vista.Codigo,
                nombre: Vista.Nombre,
                descripcion: Vista.Descripcion,
                idProveedor: UtilesProveedor.ObtenerIdProveedor(Vista.RazonSocialProveedor),
                precioAdquisicion: Vista.PrecioAdquisicion,
                precioCesion: Vista.PrecioCesion,
                stockMinimo: Vista.StockMinimo,
                pedidoMinimo: Vista.PedidoMinimo
            );
        }
    }
}
