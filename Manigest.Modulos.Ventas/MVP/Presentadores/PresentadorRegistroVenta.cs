using Manigest.Core.MVP.Presentadores;
using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Ventas.MVP.Modelos;
using Manigest.Modulos.Ventas.MVP.Modelos.Repositorios;
using Manigest.Modulos.Ventas.MVP.Vistas.Venta.Plantillas;

namespace Manigest.Modulos.Ventas.MVP.Presentadores {
    public class PresentadorRegistroVenta : PresentadorRegistroBase<IVistaRegistroVenta, Venta, DatosVenta, CriterioBusquedaVenta> {
        public PresentadorRegistroVenta(IVistaRegistroVenta vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Venta objeto) {
            throw new NotImplementedException();
        }

        protected override Venta ObtenerObjetoDesdeVista() {
            return new Venta(_objeto?.Id ?? 0,
                   fecha: DateTime.Now,
                   idAlmacen: UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacen),
                   idCliente: UtilesCliente.ObtenerIdCliente(Vista.NombreCliente),
                   total: Vista.Total
               );
        }
    }
}
