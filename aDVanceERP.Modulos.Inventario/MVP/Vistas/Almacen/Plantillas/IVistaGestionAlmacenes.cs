using aDVanceERP.Core.Documentos.Interfaces;
using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas; 

public interface IVistaGestionAlmacenes : IVistaContenedor, IGestorDatos, IBuscadorDatos<FiltroBusquedaAlmacen>,
    IGestorTablaDatos {
    event EventHandler<FormatoDocumento>? ExportarDocumentoInventario;
}