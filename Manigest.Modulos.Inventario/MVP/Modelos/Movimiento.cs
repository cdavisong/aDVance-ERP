using Manigest.Core.MVP.Modelos.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Modelos {
    public enum MotivoMovimiento {
        Venta,
        Donacion,
        UsoInterno,
        Caducidad,
        RectificacionNegativa, // Rectificación (-)
        Compra,
        Devolucion,
        RectificacionPositiva // Rectificación (+)
    }

    public class Movimiento : IObjetoUnico { 
        public Movimiento(long id, long idArticulo, long idAlmacenOrigen, long idAlmacenDestino, int cantidadInicial, int cantidadMovida, int cantidadFinal, MotivoMovimiento motivo, DateTime fecha) {
            Id = id;
            IdArticulo = idArticulo;
            IdAlmacenOrigen = idAlmacenOrigen;
            IdAlmacenDestino = idAlmacenDestino;
            CantidadInicial = cantidadInicial;
            CantidadMovida = cantidadMovida;
            CantidadFinal = cantidadFinal;
            Motivo = motivo;
            Fecha = fecha;
        }

        public long Id { get; set; }
        public long IdArticulo { get; set; }
        public long IdAlmacenOrigen { get; set; }
        public long IdAlmacenDestino { get; set; }
        public int CantidadInicial { get; set; }
        public int CantidadMovida { get; set; }
        public int CantidadFinal { get; set; }
        public MotivoMovimiento Motivo { get; set; }
        public DateTime Fecha { get; set; }
    }

    public enum CriterioBusquedaMovimiento {
        Todos,
        Id,
        Articulo,
        AlmacenOrigen,
        AlmacenDestino,
        Fecha,
        Motivo
    }
}
