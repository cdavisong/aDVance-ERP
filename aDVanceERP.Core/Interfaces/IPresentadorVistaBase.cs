namespace aDVanceERP.Core.Interfaces;

public interface IPresentadorVistaBase<Vi> 
    where Vi : class, IVista {
    Vi Vista { get; }
}