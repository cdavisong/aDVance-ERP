using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorRegistroAperturaCaja : PresentadorRegistroBase<IVistaRegistroAperturaCaja, Caja, DatosCaja, FiltroBusquedaCaja> {
        public PresentadorRegistroAperturaCaja(IVistaRegistroAperturaCaja vista) 
            : base(vista) { }

        public override void PopularVistaDesdeObjeto(Caja objeto) {
            Vista.ModoEdicionDatos = true;
            Vista.Fecha = objeto.FechaApertura;
            Vista.SaldoInicial = objeto.SaldoInicial;

            Entidad = objeto;
        }

        protected override Caja ObtenerEntidadDesdeVista() {
            return new Caja(Entidad?.Id ?? 0,
                Vista.Fecha,
                Vista.SaldoInicial,
                Vista.SaldoInicial,
                DateTime.MinValue,
                UtilesCuentaUsuario.UsuarioAutenticado?.Id ?? 0
            ) {
                Estado = EstadoCaja.Abierta
            };
        }
    }
}
