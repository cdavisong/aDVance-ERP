using Manigest.Core.MVP.Modelos.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Modelos {
    public enum CategoriaTelefonoContacto {
        Otro,
        Fijo,
        Movil
    }

    public class TelefonoContacto : IObjetoUnico {
        public TelefonoContacto(long idTelefonoContacto, string prefijo, string numero, CategoriaTelefonoContacto categoria, long idContacto) {
            Id = idTelefonoContacto;
            Prefijo = prefijo;
            Numero = numero;
            Categoria = categoria;
            IdContacto = idContacto;
        }

        public TelefonoContacto(string prefijo, string numero, CategoriaTelefonoContacto categoria, long idContacto) :
            this(0, prefijo, numero, categoria, idContacto) { }

        public long Id { get; set; }
        public string Prefijo { get; }
        public string Numero { get; }
        public CategoriaTelefonoContacto Categoria { get; set; }
        public long IdContacto { get; }
    }

    public enum CriterioBusquedaTelefonoContacto {
        Todos,
        Id,
        Numero,
        IdContacto
    }
}
