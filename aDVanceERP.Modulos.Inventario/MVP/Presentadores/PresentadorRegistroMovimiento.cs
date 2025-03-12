using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorRegistroMovimiento : PresentadorRegistroBase<IVistaRegistroMovimiento, Movimiento, DatosMovimiento, CriterioBusquedaMovimiento> {
        private Movimiento? _movimiento;

        public PresentadorRegistroMovimiento(IVistaRegistroMovimiento vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Movimiento objeto) {
            Vista.NombreArticulo = UtilesArticulo.ObtenerNombreArticulo(objeto.IdArticulo).Result ?? string.Empty;
            Vista.NombreAlmacenOrigen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenOrigen) ?? string.Empty;
            Vista.NombreAlmacenDestino = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenDestino) ?? string.Empty;
            Vista.CantidadMovida = objeto.CantidadMovida;
            Vista.Motivo = objeto.Motivo?.ToString() ?? string.Empty;
            Vista.Fecha = objeto.Fecha;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override async Task<Movimiento?> ObtenerObjetoDesdeVista() {
            _movimiento = new Movimiento(
                id: _objeto?.Id ?? 0,
                idArticulo: await UtilesArticulo.ObtenerIdArticulo(Vista.NombreArticulo),
                idAlmacenOrigen: await UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacenOrigen),
                idAlmacenDestino: await UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacenDestino),
                cantidadMovida: Vista.CantidadMovida,
                motivo: Vista.Motivo,
                fecha: Vista.Fecha
            );

            return _movimiento;
        }

        protected override void RegistroAuxiliar() {
            if (_movimiento != null) {
                UtilesMovimientoArticuloAlmacen.ModificarStockArticuloAlmacen(_movimiento.IdArticulo, _movimiento.IdAlmacenOrigen, _movimiento.IdAlmacenDestino, _movimiento.CantidadMovida);
            }
        }
    }

}
