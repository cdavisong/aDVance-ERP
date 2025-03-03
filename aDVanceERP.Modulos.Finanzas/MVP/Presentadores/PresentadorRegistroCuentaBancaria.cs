using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.CuentaBancaria.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorRegistroCuentaBancaria : PresentadorRegistroBase<IVistaRegistroCuentaBancaria, CuentaBancaria, DatosCuentaBancaria, CriterioBusquedaCuentaBancaria> {
        public PresentadorRegistroCuentaBancaria(IVistaRegistroCuentaBancaria vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(CuentaBancaria objeto) {
            Vista.Alias = objeto.Alias ?? string.Empty;
            Vista.NumeroTarjeta = objeto.NumeroTarjeta ?? string.Empty;
            Vista.Moneda = objeto.Moneda.ToString();
            Vista.NombrePropietario = UtilesContacto.ObtenerNombreContacto(objeto.IdContacto) ?? string.Empty;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override CuentaBancaria ObtenerObjetoDesdeVista() {
            return new CuentaBancaria(_objeto?.Id ?? 0,
                    alias: Vista.Alias,
                    numeroTarjeta: Vista.NumeroTarjeta,
                    moneda: (TipoMoneda) Enum.Parse(typeof(TipoMoneda), Vista.Moneda),
                    idContacto: UtilesContacto.ObtenerIdContacto(Vista.NombrePropietario)
                );
        }
    }
}
