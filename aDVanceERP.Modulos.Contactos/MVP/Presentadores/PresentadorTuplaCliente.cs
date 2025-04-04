using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores; 

public class PresentadorTuplaCliente : PresentadorTuplaBase<IVistaTuplaCliente, Cliente> {
    public PresentadorTuplaCliente(IVistaTuplaCliente vista, Cliente objeto) : base(vista, objeto) { }
}