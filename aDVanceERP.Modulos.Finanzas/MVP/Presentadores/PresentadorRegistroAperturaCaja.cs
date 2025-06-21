using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas;
using aDVanceERP.Modulos.Finanzas.Repositorios;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorRegistroAperturaCaja : PresentadorRegistroBase<IVistaRegistroAperturaCaja, Caja, RepoCaja, FbCaja> {
        public PresentadorRegistroAperturaCaja(IVistaRegistroAperturaCaja vista) 
            : base(vista) { }

        public override void PopularVistaDesdeEntidad(Caja objeto) {
            Vista.ModoEdicionDatos = true;
            Vista.Fecha = objeto.FechaApertura;
            Vista.SaldoInicial = objeto.SaldoInicial;

            Entidad = objeto;
        }

        protected override Caja? ObtenerEntidadDesdeVista() {
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
