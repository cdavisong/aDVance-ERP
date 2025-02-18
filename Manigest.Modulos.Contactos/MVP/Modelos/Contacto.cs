

using Manigest.Core.MVP.Modelos.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Modelos {
    public class Contacto : IObjetoUnico {
        public Contacto(long idContacto, string nombre, string direccionCorreoElectronico, string direccion, string notas) {
            Id = idContacto;
            Nombre = nombre;
            DireccionCorreoElectronico = direccionCorreoElectronico;
            Direccion = direccion;
            Notas = notas;
        }

        public Contacto(string nombre, string direccionCorreoElectronico, string direccion)
            : this(0, nombre, direccionCorreoElectronico, direccion, string.Empty) { }

        public long Id { get; set; }
        public string Nombre { get; }
        public string DireccionCorreoElectronico { get; }
        public string Direccion { get; }
        public string Notas { get; set; }
    }

    public enum CriterioBusquedaContacto {
        Todos,
        Id,
        Nombre
    }

    public static class UtilesBusquedaContacto {
        public static string[] CriterioBusquedaContacto = new string[] {
            "Todos los contactos",
            "Identificador de BD",
            "Nombre del contacto"
        };
    }
}
