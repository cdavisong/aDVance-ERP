using aDVanceERP.Core.MVP.Presentadores;

using aDVancePOS.Desktop.MVP.Vistas.ContenedorModulos.Plantillas;
using aDVancePOS.Desktop.MVP.Vistas.Principal.Plantillas;

namespace aDVancePOS.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos : PresentadorBase<IVistaContenedorModulos> {
    public PresentadorContenedorModulos(IVistaPrincipal vistaPrincipal, IVistaContenedorModulos vista) : base(vista) {
        VistaPrincipal = vistaPrincipal;

        // Eventos

        #region Módulo : Punto de Venta



        #endregion
    }

    private IVistaPrincipal VistaPrincipal { get; }
}