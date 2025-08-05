using aDVanceERP.Core.Interfaces.Comun;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas;

public interface IVistaGestionClientes : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaCliente>,
    IGestorTablaDatos { }