using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos {

    public class Caja : IObjetoUnico {
        public Caja() {            
            Notas = string.Empty;
        }

        public Caja(long id, int numero, decimal saldoInicial, DateTime fechaApertura, DateTime? fechaCierre = null, string notas = "") {
            Id = id;
            Numero = numero;
            SaldoInicial = saldoInicial;
            Saldo = saldoInicial;
            FechaApertura = fechaApertura;
            FechaCierre = fechaCierre;
            Notas = notas;
        }

        public long Id { get; set; }
        public int Numero { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal Saldo { get; private set; }
        public DateTime FechaApertura { get; private set; }
        public DateTime? FechaCierre { get; private set; }
        public string Notas { get; set; }

        public bool Abierta {
            get => FechaCierre == null || FechaCierre == DateTime.MinValue;
        }
    }
    public enum CriterioBusquedaCaja {
        Todos,
        Id,
        Numero,
        FechaCierre
    }

    public static class UtilesBusquedaCaja {
        public static string[] CriterioBusquedaCaja = new string[] {
            "Todas las cajas",
            "Identificador de BD",
            "Número de caja",
            "Fecha de cierre"
        };
    }    
}
