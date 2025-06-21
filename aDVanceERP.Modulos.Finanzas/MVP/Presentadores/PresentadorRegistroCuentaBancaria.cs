using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.CuentaBancaria.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores; 

public class PresentadorRegistroCuentaBancaria : PresentadorRegistroBase<IVistaRegistroCuentaBancaria, CuentaBancaria,
    DatosCuentaBancaria, CriterioBusquedaCuentaBancaria> {
    public PresentadorRegistroCuentaBancaria(IVistaRegistroCuentaBancaria vista) : base(vista) { }

    public override void PopularVistaDesdeEntidad(CuentaBancaria objeto) {
        Vista.Alias = objeto.Alias ?? string.Empty;
        Vista.NumeroTarjeta = objeto.NumeroTarjeta ?? string.Empty;
        Vista.Moneda = objeto.Moneda.ToString();
        Vista.NombrePropietario = UtilesContacto.ObtenerNombreContacto(objeto.IdContacto) ?? string.Empty;
        Vista.ModoEdicionDatos = true;

        Entidad = objeto;
    }

    protected override bool DatosEntidadCorrectos() {
        var aliasOk = !string.IsNullOrEmpty(Vista.Alias);
        var noLetrasNumeroTarjetaOk = !Vista.NumeroTarjeta.Replace(" ", "").Any(char.IsLetter);
        var numeroDijitosTarjeta = Vista.NumeroTarjeta.Select(char.IsDigit).Count(result => result == true);
        var numeroDijitosTarjetaOk = numeroDijitosTarjeta == 16;
        var numeroTarjetaOk = !string.IsNullOrEmpty(Vista.NumeroTarjeta) && noLetrasNumeroTarjetaOk && numeroDijitosTarjetaOk;
        
        if (!aliasOk)
            CentroNotificaciones.Mostrar("El campo de alias es obligatorio para registro de cuenta bancaria, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
        if (!numeroTarjetaOk)
            CentroNotificaciones.Mostrar("Debe especificar un número de tarjeta válido, el campo no puede estar vacío ni contener caracteres incorrectos", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);

        return aliasOk && numeroTarjetaOk;
    }

    protected override async Task<CuentaBancaria?> ObtenerEntidadDesdeVista() {
        return new CuentaBancaria(Entidad?.Id ?? 0,
            Vista.Alias,
            Vista.NumeroTarjeta,
            (TipoMoneda)Enum.Parse(typeof(TipoMoneda), Vista.Moneda),
            await UtilesContacto.ObtenerIdContacto(Vista.NombrePropietario)
        );
    }
}