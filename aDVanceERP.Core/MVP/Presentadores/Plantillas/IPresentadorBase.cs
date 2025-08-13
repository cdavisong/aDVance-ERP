using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas; 

public interface IPresentadorBase<V> : IDisposable where V : IVistaBase { }