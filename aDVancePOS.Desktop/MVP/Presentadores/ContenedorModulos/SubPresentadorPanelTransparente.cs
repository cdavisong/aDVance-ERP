using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.MVP.Vistas.PanelTransparente;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVancePOS.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorPanelTransparente? _panelTransparente;

        private void InicializarVistaPanelTransparente(IVista parent) {
            _panelTransparente = new PresentadorPanelTransparente(new VistaPanelTransparente(parent));
        }

        private void MostrarVistaPanelTransparente(IVista parent) {
            InicializarVistaPanelTransparente(parent);

            if (_panelTransparente?.Vista == null)
                return;

            _panelTransparente.Vista.Restaurar();
            _panelTransparente.Vista.Mostrar();
        }
    }
}
