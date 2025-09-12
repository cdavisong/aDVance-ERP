using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionCajas? _gestionCajas;

        private async void InicializarVistaGestionCajas() {
            _gestionCajas = new PresentadorGestionCajas(new VistaGestionCajas());
            _gestionCajas.EditarObjeto += MostrarVistaEdicionAperturaCaja;
            _gestionCajas.Vista.RegistrarEntidad += MostrarVistaRegistroAperturaCaja;
            _gestionCajas.Vista.RegistrarMovimientoCajaSeleccionada += MostrarVistaRegistroMovimientoCaja;

            if (Vista.Vistas != null)
                await Task.Run(() => Vista.Vistas?.Registrar("vistaGestionCajas", _gestionCajas.Vista));
        }

        private void MostrarVistaGestionCajas(object? sender, EventArgs e) {
            if (_gestionCajas?.Vista == null)
                return;

            _gestionCajas.Vista.CargarFiltrosBusqueda(UtilesBusquedaCaja.FiltroBusquedaCaja);
            _gestionCajas.Vista.Restaurar();
            _gestionCajas.Vista.Mostrar();

            _gestionCajas.ActualizarResultadosBusqueda();
        }
    }
}
