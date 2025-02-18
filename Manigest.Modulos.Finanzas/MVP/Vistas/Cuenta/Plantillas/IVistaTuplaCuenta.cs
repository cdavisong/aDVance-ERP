using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Finanzas.MVP.Vistas.Cuenta.Plantillas {
    public interface IVistaTuplaCuenta : IVistaTupla {
        string Id { get; set; }
        string Alias { get; set; }
        string NumeroTarjeta { get; set; }
        string Moneda { get; set; }
        string NombrePropietario { get; set; }

        event EventHandler? MostrarQR;
    }
}
