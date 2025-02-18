using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Finanzas.MVP.Vistas.Cuenta.Plantillas {
    public interface IVistaRegistroCuenta : IVistaRegistro {
        string Alias { get; set; }
        string NumeroTarjeta { get; set; }
        string Moneda { get; set; }
        string NombrePropietario { get; set; }

        void CargarTiposMoneda(string[] tiposMoneda);
        void CargarNombresContactos(string[] nombresContactos);
    }
}
