using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos {
    public class Movimiento : IObjetoUnico {
        public Movimiento() {
        }

        public Movimiento(long id, long idArticulo, long idAlmacenOrigen, long idAlmacenDestino, int cantidadMovida, long idTipoMovimiento, DateTime fecha) {
            Id = id;
            IdArticulo = idArticulo;
            IdAlmacenOrigen = idAlmacenOrigen;
            IdAlmacenDestino = idAlmacenDestino;
            CantidadMovida = cantidadMovida;
            IdTipoMovimiento = idTipoMovimiento;
            Fecha = fecha;
        }

        public long Id { get; set; }
        public long IdArticulo { get; set; }
        public long IdAlmacenOrigen { get; set; }
        public long IdAlmacenDestino { get; set; }
        public int CantidadMovida { get; set; }
        public long IdTipoMovimiento { get; set; }
        public DateTime Fecha { get; set; }
    }

    public enum CriterioBusquedaMovimiento {
        Todos,
        Id,
        Articulo,
        AlmacenOrigen,
        AlmacenDestino,
        Fecha,
        TipoMovimiento
    }

    public static class UtilesBusquedaMovimiento {
        public static string[] CriterioBusquedaMovimiento = new string[] {
            "Todos los movimientos",
            "Identificador de BD",
            "Nombre del artículo",
            "Almacén de orígen",
            "Almacén de destino",
            "Fecha del movimiento",
            "Tipo de movimiento"
        };
    }
}
