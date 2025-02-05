using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Modelos.Repositorios.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Core.MVP.Presentadores.Plantillas {
    public interface IPresentadorRegistro<Vr, Do, O, C> : IPresentadorBase<Vr>
        where Vr : IVistaRegistro
        where Do : class, IRepositorioDatos<O, C>, new()
        where O : class, IObjetoUnico
        where C : Enum {
        Do DatosObjeto { get; }

        event EventHandler? DatosRegistradosActualizados;
        event EventHandler? Salir;
    }
}
