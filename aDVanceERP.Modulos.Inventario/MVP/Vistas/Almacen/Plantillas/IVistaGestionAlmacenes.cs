using aDVanceERP.Core.Documentos.Interfaces;
using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.Vistas.Comun.Interfaces;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;

public interface IVistaGestionAlmacenes : IVistaContenedor, IGestorEntidades, IBuscadorEntidades<FiltroBusquedaAlmacen>,
    INavegadorTuplasEntidades {
    event EventHandler<FormatoDocumento>? ExportarDocumentoInventario;
}