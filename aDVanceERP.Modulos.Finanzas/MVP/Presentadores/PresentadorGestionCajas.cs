using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas;
using System.Globalization;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorGestionCajas : PresentadorGestionBase<PresentadorTuplaCaja, IVistaGestionCajas, IVistaTuplaCaja, Caja, DatosCaja, CriterioBusquedaCaja> {
        public PresentadorGestionCajas(IVistaGestionCajas vista) 
            : base(vista) { }

        protected override PresentadorTuplaCaja ObtenerValoresTupla(Caja objeto) {
            var presentadorTupla = new PresentadorTuplaCaja(new VistaTuplaCaja, objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.FechaApertura = objeto.FechaApertura.ToString("yyyy-MM-dd");
            presentadorTupla.Vista.SaldoInicial = objeto.SaldoInicial.ToString("N", CultureInfo.InvariantCulture);
            presentadorTupla.Vista.SaldoActual = objeto.SaldoActual.ToString("N", CultureInfo.InvariantCulture);
            presentadorTupla.Vista.FechaCierre = objeto.FechaCierre.ToString("yyyy-MM-dd");
            presentadorTupla.Vista.Estado = (int) objeto.Estado;
            presentadorTupla.Vista.NombreUsuario = UtilesCuentaUsuario.ObtenerNombreCuentaUsuario(objeto.IdCuentaUsuario) ?? string.Empty;
        
            return presentadorTupla;
        }
    }
}
