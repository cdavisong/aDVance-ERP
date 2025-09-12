using aDVanceERP.Core.Documentos.Interfaces;
using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;

public interface IVistaGestionAlmacenes : IVistaContenedor, IGestorEntidades, IBuscadorEntidades<FiltroBusquedaAlmacen>,
    IGestorTablaDatos {
    event EventHandler<FormatoDocumento>? ExportarDocumentoInventario;
}