using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorRegistroAperturaCaja : PresentadorRegistroBase<IVistaRegistroAperturaCaja, Caja, DatosCaja, CriterioBusquedaCaja> {
        public PresentadorRegistroAperturaCaja(IVistaRegistroAperturaCaja vista) 
            : base(vista) { }

        public override void PopularVistaDesdeObjeto(Caja objeto) {
            Vista.SaldoInicial = objeto.SaldoInicial;

            Objeto = objeto;
        }

        protected override async Task<Caja?> ObtenerObjetoDesdeVista() {
            return new Caja(Objeto?.Id ?? 0,
                DateTime.Now,
                Vista.SaldoInicial,
                Vista.SaldoInicial,
                DateTime.MinValue,
                UtilesCuentaUsuario.UsuarioAutenticado?.Id ?? 0
            );
        }
    }
}
