using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroAperturaCaja? _registroAperturaCaja;

        private void InicializarVistaRegistroAperturaCaja() {
            _registroAperturaCaja = new PresentadorRegistroAperturaCaja(new VistaRegistroAperturaCaja());
            _registroAperturaCaja.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
            _registroAperturaCaja.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroAperturaCaja.DatosRegistradosActualizados += async delegate {
                if (_gestionCajas == null)
                    return;

                await _gestionCajas.RefrescarListaObjetos();
            };
        }

        private void MostrarVistaRegistroAperturaCaja(object? sender, EventArgs e) {
            if (UtilesCaja.ExisteCajaActiva()) {
                CentroNotificaciones.Mostrar("Sólo puede existir una caja abierta por sesión. Para realizar nuevas aperturas de caja realice el cierre correspondiente a la caja activa actualmente", TipoNotificacion.Advertencia);

                return;
            }

            InicializarVistaRegistroAperturaCaja();

            if (_registroAperturaCaja == null)
                return;

            MostrarVistaPanelTransparente(_registroAperturaCaja.Vista);

            _registroAperturaCaja.Vista.Restaurar();
            _registroAperturaCaja.Vista.Mostrar();
            _registroAperturaCaja.Dispose();
        }

        private void MostrarVistaEdicionAperturaCaja(object? sender, EventArgs e) {
            InicializarVistaRegistroAperturaCaja();

            if (sender is Caja caja) {
                if (_registroAperturaCaja != null) {
                    MostrarVistaPanelTransparente(_registroAperturaCaja.Vista);

                    _registroAperturaCaja.PopularVistaDesdeObjeto(caja);
                    _registroAperturaCaja.Vista.Mostrar();
                }
            }

            _registroAperturaCaja?.Dispose();
        }
    }
}
