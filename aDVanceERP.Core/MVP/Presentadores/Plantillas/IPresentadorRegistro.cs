using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Presentadores.Comun.Interfaces;
using aDVanceERP.Core.Repositorios.Comun.Interfaces;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas;

public interface IPresentadorRegistro<Vr, Re, En, Fb> : IPresentadorVistaBase<Vr>
    where Vr : class, IVistaRegistro
    where Re : class, IRepoEntidadBaseDatos<En, Fb>, new()
    where En : class, IEntidadBaseDatos, new()
    where Fb : Enum {
    Re DatosObjeto { get; }

    event EventHandler? DatosRegistradosActualizados;
    event EventHandler? Salir;
}