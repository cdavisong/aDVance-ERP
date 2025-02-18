using Manigest.Core.MVP.Presentadores;
using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Finanzas.MVP.Modelos;
using Manigest.Modulos.Finanzas.MVP.Modelos.Repositorios;
using Manigest.Modulos.Finanzas.MVP.Vistas.Cuenta.Plantillas;

namespace Manigest.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorRegistroCuenta : PresentadorRegistroBase<IVistaRegistroCuenta, Cuenta, DatosCuenta, CriterioBusquedaCuenta> {
        public PresentadorRegistroCuenta(IVistaRegistroCuenta vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Cuenta objeto) {
            Vista.Alias = objeto.Alias;
            Vista.NumeroTarjeta = objeto.NumeroTarjeta;
            Vista.Moneda = objeto.Moneda.ToString();
            Vista.NombrePropietario = UtilesContacto.ObtenerNombreContacto(objeto.IdContacto) ?? string.Empty;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override Cuenta ObtenerObjetoDesdeVista() {
            return new Cuenta(_objeto?.Id ?? 0,
                    alias: Vista.Alias,
                    numeroTarjeta: Vista.NumeroTarjeta,
                    moneda: (TipoMoneda) Enum.Parse(typeof(TipoMoneda), Vista.Moneda),
                    idContacto: UtilesContacto.ObtenerIdContacto(Vista.NombrePropietario)
                );
        }
    }
}
