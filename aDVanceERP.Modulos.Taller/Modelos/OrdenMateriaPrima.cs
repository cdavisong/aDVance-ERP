using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Taller.Modelos {
    public class OrdenMateriaPrima : IObjetoUnico {
        public OrdenMateriaPrima() {
            IdOrdenProduccion = 0;
            IdProducto = 0; // Materia prima consumida
            Cantidad = 0.0m;
            CostoUnitario = 0.0m;
            CostoTotal = 0.0m;
            FechaRegistro = DateTime.Now;
        }

        public OrdenMateriaPrima(long id, long idOrdenProduccion, long idProducto, decimal cantidad, 
            decimal costoUnitario, decimal costoTotal) {
            Id = id;
            IdOrdenProduccion = idOrdenProduccion;
            IdProducto = idProducto; // Materia prima consumida
            Cantidad = cantidad;
            CostoUnitario = costoUnitario;
            CostoTotal = costoTotal;
            FechaRegistro = DateTime.Now;
        }

        public long Id { get; set; }
        public long IdOrdenProduccion { get; set; }
        public long IdProducto { get; set; } // Materia prima consumida
        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal CostoTotal { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }

    public enum CriterioBusquedaOrdenMateriaPrima {
        Todos,
        Id,
        OrdenProduccion,
        Producto,
        FechaRegistro
    }

    public static class UtilesBusquedaOrdenMateriaPrima {
        public static object[] CriterioBusquedaOrdenMateriaPrima =
        {
            "Todos los materiales consumidos",
            "Identificador de BD",
            "Orden de producción asociada",
            "Material utilizado",
            "Fecha de registro"
        };
    }
}