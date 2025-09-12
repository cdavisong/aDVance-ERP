using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas;

public interface IVistaGestionClientes : IVistaContenedor, IGestorEntidades, IBuscadorEntidades<FiltroBusquedaCliente>,
    INavegadorTuplasEntidades { }