using aDVanceERP.Core.Interfaces.Comun;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas; 

public interface IPresentadorRegistro<Vr, Do, O, C> : IPresentadorBase<Vr>
    where Vr : IVistaRegistro
    where Do : class, new()
    where O : class, IEntidadBd, new()
    where C : Enum {
    Do DatosObjeto { get; }

    event EventHandler? DatosRegistradosActualizados;
    event EventHandler? Salir;
}