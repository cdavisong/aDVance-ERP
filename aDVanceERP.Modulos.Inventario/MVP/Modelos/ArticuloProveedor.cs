using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos {
    public class ArticuloProveedor : IObjetoUnico {
        public ArticuloProveedor() {
        }

        public ArticuloProveedor(long id, long idProveedor, float precioAdquisicion, float precioVenta) {
            Id = id;
            IdProveedor = idProveedor;
            PrecioAdquisicion = precioAdquisicion;
            PrecioVenta = precioVenta;
        }

        public long Id { get; set; }
        public long IdArticulo { get; set; }
        public long IdProveedor { get; set; }
        public float PrecioAdquisicion { get; }
        public float PrecioVenta { get; }
    }

    public enum CriterioBusquedaArticuloProveedor {
        Todos,
        Id
    }

    public static class UtilesBusquedaArticuloProveedor {
        public static string[] CriterioBusquedaArticulo = new string[] {
            "Todos los artículos",
            "Identificador de BD"
        };
    }
}
