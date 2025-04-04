using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas; 

public interface IVistaGestionProveedores : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaProveedor>,
    IGestorTablaDatos { }