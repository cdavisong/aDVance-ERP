using aDVanceERP.Core.Presentadores;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores
{
    public class PresentadorRegistroAperturaCaja : PresentadorVistaRegistroEdicionBase<IVistaRegistroAperturaCaja, Caja, DatosCaja, CriterioBusquedaCaja> {
        public PresentadorRegistroAperturaCaja(IVistaRegistroAperturaCaja vista) 
            : base(vista) { }

        public override void PopularVistaDesdeObjeto(Caja objeto) {
            Vista.ModoEdicion = true;
            Vista.Fecha = objeto.FechaApertura;
            Vista.SaldoInicial = objeto.SaldoInicial;

            Objeto = objeto;
        }

        protected override Task<Caja?> ObtenerObjetoDesdeVista() {
            return Task.FromResult<Caja?>(new Caja(Objeto?.Id ?? 0,
                Vista.Fecha,
                Vista.SaldoInicial,
                Vista.SaldoInicial,
                DateTime.MinValue,
                UtilesCuentaUsuario.UsuarioAutenticado?.Id ?? 0
            ) {
                Estado = EstadoCaja.Abierta
            });
        }
    }
}
