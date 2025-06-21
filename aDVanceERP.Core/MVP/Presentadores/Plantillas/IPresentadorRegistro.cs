using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas; 

public interface IPresentadorRegistro<Vr, Do, O, C> : IPresentadorBase<Vr>
    where Vr : IVistaRegistro
    where Do : class, IRepositorioDatosEntidad<O, C>, new()
    where O : class, IEntidad, new()
    where C : Enum {
    Do DatosObjeto { get; }

    event EventHandler? DatosRegistradosActualizados;
    event EventHandler? Salir;
}