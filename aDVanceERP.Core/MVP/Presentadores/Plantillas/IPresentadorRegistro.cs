using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas; 

public interface IPresentadorRegistro<Vr, Do, En, C> : IPresentadorBase<Vr>
    where Vr : IVistaRegistro
    where Do : class, IRepositorioDatos<En, C>, new()
    where En : class, IEntidadBaseDatos, new()
    where C : Enum {
    Do DatosObjeto { get; }

    event EventHandler? DatosRegistradosActualizados;
    event EventHandler? Salir;
}