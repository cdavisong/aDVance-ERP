namespace aDVanceERP.Core.Modelos.Modulos.Inventario;

public enum CategoriaProducto {
    Mercancia,
    ProductoTerminado,
    MateriaPrima
}

public static class UtilesCategoriaProducto {
    public static object[] CategoriaProducto = {
        "Mercancía (Producto revendido)",
        "Producto terminado",
        "Materia prima"
    };

    public static string[] DescripcionesProducto = {
        "Artículos comprados a proveedores para ser vendidos directamente sin modificaciones. No requieren proceso de fabricación",
        "Artículos elaborados por la empresa a partir de materias primas y mano de obra. Su costo incluye materiales, actividades de producción y costos asociados",
        "Insumos o materiales utilizados para fabricar productos terminados. Pueden venderse directamente si están configurados para ello"
    };
}