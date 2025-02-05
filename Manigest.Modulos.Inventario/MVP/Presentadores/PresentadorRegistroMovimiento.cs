using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Modelos.Repositorios;
using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;
using Manigest.Core.Utiles.Datos;

namespace Manigest.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorRegistroMovimiento : PresentadorRegistroBase<IVistaRegistroMovimiento, Movimiento, DatosMovimiento, CriterioBusquedaMovimiento> {
        public PresentadorRegistroMovimiento(IVistaRegistroMovimiento vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Movimiento objeto) {
            Vista.NombreArticulo = UtilesArticulo.ObtenerNombreArticulo(objeto.IdArticulo) ?? string.Empty;
            Vista.NombreAlmacenOrigen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenOrigen) ?? string.Empty;
            Vista.NombreAlmacenDestino = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenDestino) ?? string.Empty;
            Vista.CantidadInicial = objeto.CantidadInicial;
            Vista.CantidadMovida = objeto.CantidadMovida;
            Vista.CantidadFinal = objeto.CantidadFinal;
            Vista.Motivo = objeto.Motivo.ToString();
            Vista.Fecha = objeto.Fecha;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override Movimiento ObtenerObjetoDesdeVista() {
            var movimiento = new Movimiento(
                id: _objeto?.Id ?? 0,
                idArticulo: UtilesArticulo.ObtenerIdArticulo(Vista.NombreArticulo),
                idAlmacenOrigen: UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacenOrigen),
                idAlmacenDestino: UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacenDestino),
                cantidadInicial: Vista.CantidadInicial,
                cantidadMovida: Vista.CantidadMovida,
                cantidadFinal: Vista.CantidadFinal,
                motivo: Enum.Parse<MotivoMovimiento>(Vista.Motivo),
                fecha: Vista.Fecha
            );

            // Modificar stock en la base de datos según el movimiento entre almacenes o incremento / decremento
            //UtilesArticulo.ModificarStockArticulo(
            //        movimiento.IdArticulo, 
            //        movimiento.CantidadMovida, 
            //        movimiento.IdAlmacenOrigen, 
            //        movimiento.IdAlmacenDestino, 
            //        movPositivo: movimiento.CantidadFinal > movimiento.CantidadInicial
            //    );
            
            return movimiento;
        }
    }

}
