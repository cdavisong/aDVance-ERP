using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Modulos.Finanzas.MVP.Vistas.CuentaBancaria.Plantillas;

public interface IVistaRegistroCuentaBancaria : IVistaRegistroEdicion {
    string Alias { get; set; }
    string NumeroTarjeta { get; set; }
    string Moneda { get; set; }
    string NombrePropietario { get; set; }

    void CargarTiposMoneda(string[] tiposMoneda);
    void CargarNombresContactos(object[] nombresContactos);
}