namespace Manigest.Core.Utiles.Datos {
    public static class UtilesMovimientoArticuloAlmacen {
        public static string[] MotivoMovimientoPositivo = new[] {
            "Compra",
            "Devolucion",
            "RectificacionPositiva" // Rectificación (+)
        };

        public static string[] MotivoMovimientoNegativo = new[] {
            "Venta",
            "Donacion",
            "UsoInterno",
            "Caducidad",
            "RectificacionNegativa" // Rectificación (-)
        };
    }
}
