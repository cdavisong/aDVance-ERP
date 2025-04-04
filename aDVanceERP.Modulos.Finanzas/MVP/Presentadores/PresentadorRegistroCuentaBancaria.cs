using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.CuentaBancaria.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores; 

public class PresentadorRegistroCuentaBancaria : PresentadorRegistroBase<IVistaRegistroCuentaBancaria, CuentaBancaria,
    DatosCuentaBancaria, CriterioBusquedaCuentaBancaria> {
    public PresentadorRegistroCuentaBancaria(IVistaRegistroCuentaBancaria vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(CuentaBancaria objeto) {
        Vista.Alias = objeto.Alias ?? string.Empty;
        Vista.NumeroTarjeta = objeto.NumeroTarjeta ?? string.Empty;
        Vista.Moneda = objeto.Moneda.ToString();
        Vista.NombrePropietario = UtilesContacto.ObtenerNombreContacto(objeto.IdContacto) ?? string.Empty;
        Vista.ModoEdicionDatos = true;

        Objeto = objeto;
    }

    protected override async Task<CuentaBancaria?> ObtenerObjetoDesdeVista() {
        return new CuentaBancaria(Objeto?.Id ?? 0,
            Vista.Alias,
            Vista.NumeroTarjeta,
            (TipoMoneda)Enum.Parse(typeof(TipoMoneda), Vista.Moneda),
            await UtilesContacto.ObtenerIdContacto(Vista.NombrePropietario)
        );
    }
}