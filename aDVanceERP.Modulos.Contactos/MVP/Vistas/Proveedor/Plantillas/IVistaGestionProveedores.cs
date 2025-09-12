using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas;

public interface IVistaGestionProveedores : IVistaContenedor, IGestorDatos, IBuscadorEntidades<FiltroBusquedaProveedor>,
    IGestorTablaDatos { }