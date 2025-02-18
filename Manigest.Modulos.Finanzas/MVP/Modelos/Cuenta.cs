using Manigest.Core.MVP.Modelos.Plantillas;

namespace Manigest.Modulos.Finanzas.MVP.Modelos {
    public enum TipoMoneda {
        CUP,
        CUC,
        USD
    }

    public class Cuenta : IObjetoUnico {
        public Cuenta(long id, string alias, string numeroTarjeta, TipoMoneda moneda, long idContacto) {
            Id = id;
            Alias = alias;
            NumeroTarjeta = numeroTarjeta;
            Moneda = moneda;
            IdContacto = idContacto;
        }

        public Cuenta(string alias, string numeroTarjeta, TipoMoneda moneda, long idContacto) 
            : this(0, alias, numeroTarjeta, moneda, idContacto) { }

        public long Id { get; set; }
        public string Alias { get; }
        public string NumeroTarjeta { get; }
        public TipoMoneda Moneda { get; }
        public long IdContacto { get; set; }
    }

    public enum CriterioBusquedaCuenta {
        Todos,
        Id,
        Alias
    }
}
