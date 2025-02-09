using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Modelos.Repositorios;
using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;
using Manigest.Modulos.Inventario.MVP.Vistas.Movimiento;
using Manigest.Core.Utiles.Datos;

namespace Manigest.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorGestionMovimientos : PresentadorGestionBase<PresentadorTuplaMovimiento, IVistaGestionMovimientos, IVistaTuplaMovimiento, Movimiento, DatosMovimiento, CriterioBusquedaMovimiento> {
        public PresentadorGestionMovimientos(IVistaGestionMovimientos vista) : base(vista) {
            vista.CambioAlmacenOrigen += delegate (object? sender, EventArgs e) {
                var nombreAlmacen = sender?.ToString() ?? string.Empty;

                RefrescarListaObjetos(CriterioBusquedaMovimiento.AlmacenOrigen, nombreAlmacen);
            };
        }

        public override CriterioBusquedaMovimiento CriterioBusquedaObjeto { get; protected set; } = CriterioBusquedaMovimiento.Articulo;

        public override void RefrescarListaObjetos(CriterioBusquedaMovimiento criterioBusquedaObjeto = default, string? datoBusqueda = "") {
            var nuevoCriterioBusqueda = datoBusqueda != "Todos" ? criterioBusquedaObjeto : CriterioBusquedaMovimiento.Todos;
            var nuevoDatoBusqueda = datoBusqueda;
            
            switch (nuevoCriterioBusqueda) {
                case CriterioBusquedaMovimiento.Articulo:
                    nuevoDatoBusqueda = UtilesArticulo.ObtenerIdArticulo(datoBusqueda).ToString();
                    break;
                case CriterioBusquedaMovimiento.AlmacenOrigen:
                case CriterioBusquedaMovimiento.AlmacenDestino:
                    nuevoDatoBusqueda = UtilesAlmacen.ObtenerIdAlmacen(datoBusqueda).ToString();
                    break;
                case CriterioBusquedaMovimiento.Fecha:
                    break;
                case CriterioBusquedaMovimiento.Motivo:
                    break;
                default:
                    base.RefrescarListaObjetos();
                    break;
            }

            if (nuevoCriterioBusqueda != CriterioBusquedaMovimiento.Todos)
                base.RefrescarListaObjetos(nuevoCriterioBusqueda, nuevoDatoBusqueda);
        }

        protected override PresentadorTuplaMovimiento ObtenerValoresTupla(Movimiento objeto) {
            var presentadorTupla = new PresentadorTuplaMovimiento(new VistaTuplaMovimiento(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.NombreArticulo = UtilesArticulo.ObtenerNombreArticulo(objeto.IdArticulo) ?? string.Empty;
            presentadorTupla.Vista.NombreAlmacenOrigen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenOrigen) ?? string.Empty;
            presentadorTupla.Vista.ActualizarIconoStock(objeto.CantidadFinal > objeto.CantidadInicial);
            presentadorTupla.Vista.NombreAlmacenDestino = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenDestino) ?? string.Empty;
            presentadorTupla.Vista.CantidadMovida = objeto.CantidadMovida.ToString();
            presentadorTupla.Vista.Motivo = objeto.Motivo.ToString();
            presentadorTupla.Vista.Fecha = objeto.Fecha.ToString("yyyy-MM-dd");

            return presentadorTupla;
        }
    }

}
