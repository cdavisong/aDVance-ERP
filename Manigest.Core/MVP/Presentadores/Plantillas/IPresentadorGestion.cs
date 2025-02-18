using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Modelos.Repositorios.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Core.MVP.Presentadores.Plantillas {
    public interface IPresentadorGestion<Vg, Do, O, C> : IPresentadorBase<Vg>
        where Vg : IVistaContenedor, IGestorDatos, IBuscadorDatos<C>, IGestorTablaDatos
        where Do : class, IRepositorioDatos<O, C>, new()
        where O : class, IObjetoUnico
        where C : Enum {
        Do DatosObjeto { get; }
        C CriterioBusquedaObjeto { get; }
        string DatoBusquedaObjeto { get; }

        event EventHandler EditarObjeto;

        void BusquedaDatos(C criterio, string dato);
        void RefrescarListaObjetos();
    }
}
