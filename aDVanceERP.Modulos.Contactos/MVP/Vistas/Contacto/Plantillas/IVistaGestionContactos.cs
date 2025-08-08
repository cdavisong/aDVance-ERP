using aDVanceERP.Core.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Contacto.Plantillas;

public interface IVistaGestionContactos : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaContacto>,
    IGestorTablaDatos { }