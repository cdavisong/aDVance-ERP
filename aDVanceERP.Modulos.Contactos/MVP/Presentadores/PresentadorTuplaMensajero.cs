using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores;

public class PresentadorTuplaMensajero : PresentadorTuplaBase<IVistaTuplaMensajero, Mensajero> {
    public PresentadorTuplaMensajero(IVistaTuplaMensajero vista, Mensajero objeto) : base(vista, objeto) { }
}