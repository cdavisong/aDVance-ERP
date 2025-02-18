using Manigest.Core.MVP.Presentadores;
using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Finanzas.MVP.Modelos;
using Manigest.Modulos.Finanzas.MVP.Modelos.Repositorios;
using Manigest.Modulos.Finanzas.MVP.Vistas.Cuenta;
using Manigest.Modulos.Finanzas.MVP.Vistas.Cuenta.Plantillas;

namespace Manigest.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorGestionCuentas : PresentadorGestionBase<PresentadorTuplaCuenta, IVistaGestionCuentas, IVistaTuplaCuenta, Cuenta, DatosCuenta, CriterioBusquedaCuenta> {
        public PresentadorGestionCuentas(IVistaGestionCuentas vista) : base(vista) {            
        }

        public event EventHandler? MostrarQrTupla;

        protected override PresentadorTuplaCuenta ObtenerValoresTupla(Cuenta objeto) {
            var presentadorTupla = new PresentadorTuplaCuenta(new VistaTuplaCuenta(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.Alias = objeto.Alias;
            presentadorTupla.Vista.NumeroTarjeta = objeto.NumeroTarjeta;
            presentadorTupla.Vista.Moneda = objeto.Moneda.ToString();
            presentadorTupla.Vista.NombrePropietario = UtilesContacto.ObtenerNombreContacto(objeto.IdContacto) ?? string.Empty;
            presentadorTupla.Vista.MostrarQR += delegate (object? sender, EventArgs args) {
                MostrarQrTupla?.Invoke(sender, args);
            };

            return presentadorTupla;
        }
    }
}
