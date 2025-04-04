using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero.Plantillas;

public interface IVistaGestionMensajeros : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaMensajero>,
    IGestorTablaDatos { }