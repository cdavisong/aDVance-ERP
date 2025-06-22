using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Repositorios.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas; 

public interface IPresentadorRegistro<Vr, Rd, En, Fb> : IPresentadorBase<Vr>
    where Vr : IVistaRegistro
    where Rd : class, IRepositorioDatosEntidad<En, Fb>, new()
    where En : class, IEntidad, new()
    where Fb : Enum {
    Rd RepoDatosEntidad { get; }

    event EventHandler? DatosEntidadRegistradosActualizados;
    event EventHandler? Salir;
}