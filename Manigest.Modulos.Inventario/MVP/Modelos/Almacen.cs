using Manigest.Core.MVP.Modelos.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Modelos {
    public class Almacen : IObjetoUnico {
        public Almacen(long idAlmacen, string nombre, string direccion, string notas) {
            Id = idAlmacen;
            Nombre = nombre;
            Direccion = direccion;
            Notas = notas;
        }

        public Almacen(string nombre, string direccion, string notas) 
            : this(0, nombre, direccion, notas) { }

        public long Id { get; set; }
        public string Nombre { get; }
        public string Direccion { get; }
        public string Notas { get; set; }
    }

    public enum CriterioBusquedaAlmacen {
        Todos,
        Id,
        Nombre
    }
}
