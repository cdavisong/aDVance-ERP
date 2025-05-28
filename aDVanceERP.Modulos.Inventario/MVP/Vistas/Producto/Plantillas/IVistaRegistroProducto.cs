using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas; 

public interface IVistaRegistroProducto : IVistaRegistro {
    // P1 : Datos generales
    CategoriaProducto CategoriaProducto { get; set; }
    string Nombre { get; set; }
    string Codigo { get; set; }    
    string Descripcion { get; set; }

    // P1_1 : Datos del roveedor y disponibilidad de venta directa de materias primas
    string RazonSocialProveedor { get; set; }
    bool EsVendible { get; set; }

    // P2 : Detalles del producto
    string UnidadMedida { get; set; }
    string? ColorPrimario { get; set; }
    string? ColorSecundario { get; set; }
    string? Tipo { get; set; }
    string? Diseno { get; set; }

    // P3 : Precios de compraventa
    decimal PrecioCompraBase { get; set; }
    decimal PrecioVentaBase { get; set; }

    void CargarRazonesSocialesProveedores(object[] nombresProveedores);
    void CargarDescripcionesUnidadesMedida(string[] descripcionesUnidadesMedida);
    void CargarUnidadesMedida(object[] unidadesMedida);
    void CargarTiposProducto(object[] tiposProducto);
    void CargarDisenosProducto(object[] disenosProducto);
}