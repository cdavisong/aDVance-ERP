using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas;
using System.Globalization;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorGestionCajas : PresentadorGestionBase<PresentadorTuplaCaja, IVistaGestionCajas, IVistaTuplaCaja, Caja, DatosCaja, FiltroBusquedaCaja> {
        public PresentadorGestionCajas(IVistaGestionCajas vista) 
            : base(vista) {
            vista.CerrarCajaSeleccionada += CerrarCajaSeleccionada;
            vista.EditarDatos += delegate {
                Vista.HabilitarBtnRegistroMovimientoCaja = false;
                Vista.HabilitarBtnCierreCaja = false;
            };
        }        

        protected override PresentadorTuplaCaja ObtenerValoresTupla(Caja objeto) {
            var presentadorTupla = new PresentadorTuplaCaja(new VistaTuplaCaja(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.FechaApertura = objeto.FechaApertura.ToString("yyyy-MM-dd HH:mm");
            presentadorTupla.Vista.SaldoInicial = objeto.SaldoInicial.ToString("N", CultureInfo.InvariantCulture);
            presentadorTupla.Vista.CantidadMovimientos = UtilesCaja.ObtenerCantidadMovimientos(objeto.Id).ToString();
            presentadorTupla.Vista.SaldoActual = objeto.SaldoActual.ToString("N", CultureInfo.InvariantCulture);
            presentadorTupla.Vista.FechaCierre = objeto.FechaCierre != DateTime.MinValue ? objeto.FechaCierre.ToString("yyyy-MM-dd HH:mm") : "-";
            presentadorTupla.Vista.Estado = (int) objeto.Estado;
            presentadorTupla.Vista.NombreUsuario = UtilesCuentaUsuario.ObtenerNombreCuentaUsuario(objeto.IdCuentaUsuario) ?? string.Empty;
            presentadorTupla.ObjetoSeleccionado += CambiarVisibilidadBotones;
            presentadorTupla.ObjetoDeseleccionado += CambiarVisibilidadBotones;
            
            return presentadorTupla;
        }

        public override void RefrescarListaObjetos() {
            // Cambiar la visibilidad de los botones 
            Vista.HabilitarBtnRegistroMovimientoCaja = false;
            Vista.HabilitarBtnCierreCaja = false;            

            base.RefrescarListaObjetos();
        }

        private void CerrarCajaSeleccionada(object? sender, EventArgs e) {
            foreach (var tupla in _tuplasObjetos)
                if (tupla.TuplaSeleccionada) {
                    tupla.Objeto.FechaCierre = DateTime.Now;
                    tupla.Objeto.Estado = EstadoCaja.Cerrada;

                    // Editar la venta del producto
                    DatosObjeto.Editar(tupla.Objeto);

                    break;
                }

            RefrescarListaObjetos();
        }

        private void CambiarVisibilidadBotones(object? sender, EventArgs e) {
            // 1. Filtrar primero las tuplas seleccionadas para evitar procesamiento innecesario
            var tuplaSeleccionada = _tuplasObjetos.Where(t => t.TuplaSeleccionada).FirstOrDefault();

            // 2. Actualizar la visibilidad de botones            
            Vista.HabilitarBtnCierreCaja = tuplaSeleccionada != null && tuplaSeleccionada.Objeto.Estado == EstadoCaja.Abierta;
            Vista.HabilitarBtnRegistroMovimientoCaja = tuplaSeleccionada != null && tuplaSeleccionada.Objeto.Estado == EstadoCaja.Abierta;
        }
    }
}
