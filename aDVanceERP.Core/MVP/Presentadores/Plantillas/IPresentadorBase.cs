using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas; 

public interface IPresentadorBase<V> : IDisposable where V : IVista { }