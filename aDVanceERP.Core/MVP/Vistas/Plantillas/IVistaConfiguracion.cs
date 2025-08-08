using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas;

public interface IVistaConfiguracion : IVista {
    event EventHandler AlmacenarConfiguracion;
}