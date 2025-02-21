using Manigest.Core.MVP.Modelos.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Modelos {
    public class Almacen : IObjetoUnico {
        public Almacen(long idAlmacen, string nombre, string direccion, bool autorizoVenta, string notas) {
            Id = idAlmacen;
            Nombre = nombre;
            Direccion = direccion;
            AutorizoVenta = autorizoVenta;
            Notas = notas;
        }

        public Almacen(string nombre, string direccion, bool autorizoVenta, string notas) 
            : this(0, nombre, direccion, autorizoVenta, notas) { }

        public long Id { get; set; }
        public string Nombre { get; }
        public string Direccion { get; }
        public bool AutorizoVenta { get; }
        public string Notas { get; set; }
    }

    public enum CriterioBusquedaAlmacen {
        Todos,
        Id,
        Nombre
    }

    public static class UtilesBusquedaAlmacen {
        public static string[] CriterioBusquedaAlmacen = new string[] {
            "Todos los almacenes",
            "Identificador de BD",
            "Nombre del almacén"
        };
    }
}
