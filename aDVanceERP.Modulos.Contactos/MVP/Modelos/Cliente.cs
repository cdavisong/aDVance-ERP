using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Modelos {
    public class Cliente : IObjetoUnico {
        public Cliente() {
        }

        public Cliente(long idCliente, string numero, string razonSocial, long idContacto) {
            Id = idCliente;
            Numero = numero;
            RazonSocial = razonSocial;
            IdContacto = idContacto;
        }

        public long Id { get; set; }
        public string? Numero { get; }
        public string? RazonSocial { get; }
        public long IdContacto { get; }
    }

    public enum CriterioBusquedaCliente {
        Todos,
        Id,
        Numero,
        RazonSocial
    }

    public static class UtilesBusquedaCliente {
        public static string[] CriterioBusquedaCliente = new string[] {
            "Todos los clientes",
            "Identificador de BD",
            "Número del cliente",
            "Razón Social"
        };
    }
}
