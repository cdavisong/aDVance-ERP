using System.Diagnostics;
using System.Globalization;

using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace aDVanceERP.Core.Utiles;

public static class UtilesReportes {
    public static void GenerarReporteVentas(DateTime fecha, List<string[]> filas,
                                      string cliente = "Todos los clientes",
                                      string usuario = "Todos los usuarios",
                                      string producto = "Todos los productos",
                                      bool mostrar = true) {
        // Crear un nuevo documento PDF
        var documento = new PdfDocument();
        documento.Info.Title = "Reporte de Ventas";
        documento.Info.Author = "aDVanceERP";

        // Configurar márgenes (en puntos, 1 punto = 1/72 pulgadas)
        const int margenIzquierdo = 40;
        const int margenDerecho = 40;
        const int margenSuperior = 40;
        const int margenInferior = 40;
        const int alturaEncabezado = 120;
        const int alturaPie = 30;
        const int alturaFila = 15;
        const int maxFilasPorPagina = 30;

        // Fuentes
        var fontTitulo = new XFont("Arial", 14, XFontStyleEx.Bold);
        var fontSubtitulo = new XFont("Arial", 10, XFontStyleEx.Regular);
        var fontContenido = new XFont("Arial", 9, XFontStyleEx.Regular);
        var fontEncabezado = new XFont("Arial", 9, XFontStyleEx.Bold);

        var culture = new CultureInfo("es-ES");
        decimal sumaTotal = 0;
        int paginaActual = 1;
        int filasProcesadas = 0;
        PdfPage pagina = null;
        XGraphics gfx = null;
        double yPoint = 0;

        while (filasProcesadas < filas.Count) {
            // Crear nueva página si es necesario
            if (pagina == null || filasProcesadas % maxFilasPorPagina == 0) {
                pagina = documento.AddPage();
                pagina.Size = PageSize.Letter;
                gfx = XGraphics.FromPdfPage(pagina);
                yPoint = margenSuperior;

                // Dibujar encabezado en cada página
                DibujarEncabezadoVentas(gfx, pagina, fontTitulo, fontSubtitulo,
                    fecha, cliente, usuario, producto,
                    margenIzquierdo, margenDerecho, ref yPoint);

                // Dibujar encabezados de tabla
                DibujarEncabezadosTablaVentas(gfx, pagina, fontEncabezado,
                    margenIzquierdo, margenDerecho, ref yPoint);
            }

            // Dibujar filas de datos
            int filasEnPagina = Math.Min(maxFilasPorPagina, filas.Count - filasProcesadas);
            for (int i = 0; i < filasEnPagina; i++) {
                var fila = filas[filasProcesadas];
                DibujarFilaVenta(gfx, fontContenido, fila, filasProcesadas + 1,
                                margenIzquierdo, ref yPoint, alturaFila, culture, ref sumaTotal);
                filasProcesadas++;
            }

            // Dibujar total parcial si es última página o hay muchas filas
            if (filasProcesadas == filas.Count || filasProcesadas % maxFilasPorPagina == 0) {
                DibujarPiePaginaVentas(gfx, pagina, fontEncabezado, fontSubtitulo,
                                      sumaTotal, margenIzquierdo, margenDerecho,
                                      margenInferior, ref yPoint, paginaActual,
                                      documento.Pages.Count, culture);
                paginaActual++;
            }
        }

        // Guardar el documento
        var nombreArchivo = $"ventas-productos-{fecha:yyyy-MM-dd}.pdf";

        if (documento.Pages.Count <= 0)
            return;

        documento.Save(nombreArchivo);

        // Mostrar el documento PDF al usuario
        if (mostrar)
            Process.Start(new ProcessStartInfo {
                FileName = nombreArchivo,
                UseShellExecute = true
            });
    }

    // Métodos auxiliares para GenerarReporteVentas
    private static void DibujarEncabezadoVentas(XGraphics gfx, PdfPage pagina, XFont fontTitulo, XFont fontSubtitulo,
                                              DateTime fecha, string cliente, string usuario, string producto,
                                              int margenIzquierdo, int margenDerecho, ref double yPoint) {
        // Agregar título
        gfx.DrawString("VENTAS POR ARTÍCULO", fontTitulo, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, pagina.Width - margenIzquierdo - margenDerecho, 20),
            XStringFormats.TopLeft);
        yPoint += 25;

        // Agregar información del reporte
        gfx.DrawString($"Fecha: {fecha.ToShortDateString()}", fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, pagina.Width, 15), XStringFormats.TopLeft);
        yPoint += 15;

        gfx.DrawString($"Cliente: {cliente}", fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, pagina.Width, 15), XStringFormats.TopLeft);
        yPoint += 15;

        gfx.DrawString($"Usuario: {usuario}", fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, pagina.Width, 15), XStringFormats.TopLeft);
        yPoint += 15;

        gfx.DrawString($"Producto: {producto}", fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, pagina.Width, 15), XStringFormats.TopLeft);
        yPoint += 20;
    }

    private static void DibujarEncabezadosTablaVentas(XGraphics gfx, PdfPage pagina, XFont fontEncabezado, int margenIzquierdo, int margenDerecho, ref double yPoint) {
        // Definir anchos de columnas
        var anchoCodigo = 50;
        var anchoProducto = 200;
        var anchoUM = 40;
        var anchoPrecioVentaFinal = 90;
        var anchoCantidad = 60;
        var anchoTotal = 90;

        // Crear encabezados de la tabla
        gfx.DrawString("Código", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoCodigo, 15), XStringFormats.TopLeft);

        gfx.DrawString("Producto", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo, yPoint, anchoProducto, 15), XStringFormats.TopLeft);

        gfx.DrawString("UM", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoProducto, yPoint, anchoUM, 15), XStringFormats.TopCenter);

        gfx.DrawString("Precio Venta Final", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoProducto + anchoUM, yPoint, anchoPrecioVentaFinal, 15), XStringFormats.TopRight);

        gfx.DrawString("Cantidad", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoProducto + anchoUM + anchoPrecioVentaFinal, yPoint, anchoCantidad, 15), XStringFormats.TopRight);

        gfx.DrawString("Total", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoProducto + anchoUM + anchoPrecioVentaFinal + anchoCantidad, yPoint, anchoTotal, 15), XStringFormats.TopRight);

        yPoint += 15;
        gfx.DrawLine(XPens.Black, margenIzquierdo, yPoint, pagina.Width - margenDerecho, yPoint);
        yPoint += 5;
    }

    private static void DibujarFilaVenta(XGraphics gfx, XFont fontContenido, string[] fila, int numeroFila,
                                       int margenIzquierdo, ref double yPoint, int alturaFila,
                                       CultureInfo culture, ref decimal sumaTotal) {
        // Definir anchos de columnas (consistentes con los encabezados)
        var anchoCodigo = 50;
        var anchoProducto = 200;
        var anchoUM = 40;
        var anchoPrecioVentaFinal = 90;
        var anchoCantidad = 60;
        var anchoTotal = 90;

        // Número de fila
        gfx.DrawString(numeroFila.ToString(), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoCodigo, alturaFila), XStringFormats.TopLeft);

        // Producto
        gfx.DrawString(fila[1], fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo, yPoint, anchoProducto, alturaFila), XStringFormats.TopLeft);

        // UM
        gfx.DrawString(fila.Length > 2 ? fila[2] : "", fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoProducto, yPoint, anchoUM, alturaFila), XStringFormats.TopCenter);

        // Precio Venta Final
        var precioBase = decimal.TryParse(fila.Length > 3 ? fila[3] : "0", NumberStyles.Any, CultureInfo.InvariantCulture, out var valorBase)
            ? valorBase
            : 0.00m;
        gfx.DrawString(precioBase.ToString("N2", CultureInfo.InvariantCulture), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoProducto + anchoUM, yPoint, anchoPrecioVentaFinal, alturaFila), XStringFormats.TopRight);

        // Cantidad
        gfx.DrawString(fila.Length > 4 ? fila[4] : "0", fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoProducto + anchoUM + anchoPrecioVentaFinal, yPoint, anchoCantidad, alturaFila), XStringFormats.TopRight);

        // Total
        var total = decimal.TryParse(fila.Length > 5 ? fila[5] : "0", NumberStyles.Any, CultureInfo.InvariantCulture, out var valorTotal)
            ? valorTotal
            : precioBase * (fila.Length > 4 ? decimal.Parse(fila[4]) : 0);
        gfx.DrawString(total.ToString("N2", CultureInfo.InvariantCulture), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoProducto + anchoUM + anchoPrecioVentaFinal + anchoCantidad, yPoint, anchoTotal, alturaFila), XStringFormats.TopRight);

        sumaTotal += total;
        yPoint += alturaFila;
    }

    private static void DibujarPiePaginaVentas(XGraphics gfx, PdfPage pagina, XFont fontEncabezado, XFont fontSubtitulo,
                                             decimal sumaTotal, int margenIzquierdo, int margenDerecho,
                                             int margenInferior, ref double yPoint, int paginaActual,
                                             int totalPaginas, CultureInfo culture) {
        // Definir anchos de columnas (consistentes con los encabezados)
        var anchoCodigo = 50;
        var anchoProducto = 200;
        var anchoUM = 40;
        var anchoPrecioVentaFinal = 90;
        var anchoCantidad = 60;
        var anchoTotal = 90;

        // Dibujar línea antes del total
        yPoint += 5;
        gfx.DrawLine(XPens.Black, margenIzquierdo, yPoint, pagina.Width - margenDerecho, yPoint);
        yPoint += 5;

        // Agregar fila con los totales
        gfx.DrawString("Total", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoProducto + anchoUM + anchoPrecioVentaFinal, yPoint, anchoCantidad, 15), XStringFormats.TopRight);

        gfx.DrawString(sumaTotal.ToString("N2", CultureInfo.InvariantCulture) + " $", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoProducto + anchoUM + anchoPrecioVentaFinal + anchoCantidad, yPoint, anchoTotal, 15), XStringFormats.TopRight);
        yPoint += 15;

        // Pie de página
        var fechaGeneracion = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        var textoPie = $"{fechaGeneracion} - Página {paginaActual} de {totalPaginas}";

        gfx.DrawString(textoPie, fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo, pagina.Height - margenInferior, pagina.Width - margenIzquierdo - margenDerecho, 20),
            XStringFormats.BottomRight);
    }

    public static void GenerarEntradaMercancias(DateTime fecha, List<string[]> filas,
                                          string proveedor = "",
                                          string documentoExterno = "",
                                          string direccion = "",
                                          string nif = "") {
        // Crear un nuevo documento PDF
        var documento = new PdfDocument();
        documento.Info.Title = "Entrada de Mercancías";
        documento.Info.Author = "aDVanceERP";

        // Configurar márgenes
        const int margenIzquierdo = 40;
        const int margenDerecho = 40;
        const int margenSuperior = 40;
        const int margenInferior = 40;
        const int alturaEncabezado = 150;
        const int alturaPie = 30;
        const int alturaFila = 15;
        const int maxFilasPorPagina = 25;

        // Fuentes
        var fontTitulo = new XFont("Arial", 16, XFontStyleEx.Bold);
        var fontSubtitulo = new XFont("Arial", 10, XFontStyleEx.Regular);
        var fontContenido = new XFont("Arial", 9, XFontStyleEx.Regular);
        var fontEncabezado = new XFont("Arial", 9, XFontStyleEx.Bold);
        var fontNegrita = new XFont("Arial", 9, XFontStyleEx.Bold);

        var culture = new CultureInfo("es-ES");
        decimal subtotal = 0;
        int paginaActual = 1;
        int filasProcesadas = 0;
        PdfPage pagina = null;
        XGraphics gfx = null;
        double yPoint = 0;

        while (filasProcesadas < filas.Count) {
            // Crear nueva página si es necesario
            if (pagina == null || filasProcesadas % maxFilasPorPagina == 0) {
                pagina = documento.AddPage();
                pagina.Size = PageSize.Letter;
                gfx = XGraphics.FromPdfPage(pagina);
                yPoint = margenSuperior;

                // Dibujar encabezado en cada página
                DibujarEncabezadoEntradaMercancias(gfx, pagina, fontTitulo, fontContenido, fontNegrita,
                    fecha, proveedor, documentoExterno, direccion, nif,
                    margenIzquierdo, margenDerecho, ref yPoint);

                // Dibujar encabezados de tabla
                DibujarEncabezadosTablaEntrada(gfx, pagina, fontEncabezado,
                    margenIzquierdo, margenDerecho, ref yPoint);
            }

            // Dibujar filas de datos
            int filasEnPagina = Math.Min(maxFilasPorPagina, filas.Count - filasProcesadas);
            for (int i = 0; i < filasEnPagina; i++) {
                var fila = filas[filasProcesadas];
                DibujarFilaEntrada(gfx, fontContenido, fila, filasProcesadas + 1,
                                 margenIzquierdo, ref yPoint, alturaFila, culture, ref subtotal);
                filasProcesadas++;
            }

            // Dibujar total parcial si es última página o hay muchas filas
            if (filasProcesadas == filas.Count || filasProcesadas % maxFilasPorPagina == 0) {
                DibujarPiePaginaEntrada(gfx, pagina, fontNegrita, fontContenido, fontSubtitulo,
                                       subtotal, margenIzquierdo, margenDerecho,
                                       margenInferior, ref yPoint, paginaActual,
                                       documento.Pages.Count, culture);
                paginaActual++;
            }
        }

        // Guardar el documento
        var nombreArchivo = $"entrada-mercancias-{fecha:yyyyMMdd}-{documento}.pdf";

        if (documento.Pages.Count <= 0)
            return;

        documento.Save(nombreArchivo);

        // Mostrar el documento PDF al usuario
        Process.Start(new ProcessStartInfo {
            FileName = nombreArchivo,
            UseShellExecute = true
        });
    }

    // Métodos auxiliares para GenerarEntradaMercancias
    private static void DibujarEncabezadoEntradaMercancias(XGraphics gfx, PdfPage pagina, XFont fontTitulo,
                                                         XFont fontContenido, XFont fontNegrita,
                                                         DateTime fecha, string proveedor,
                                                         string documento, string direccion, string nif,
                                                         int margenIzquierdo, int margenDerecho, ref double yPoint) {
        // Agregar título
        gfx.DrawString("ENTRADA DE MERCANCÍAS", fontTitulo, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, pagina.Width - margenIzquierdo - margenDerecho, 20),
            XStringFormats.TopLeft);
        yPoint += 25;

        // Información de la empresa
        gfx.DrawString("Empresa:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, 100, 15), XStringFormats.TopLeft);
        yPoint += 15;

        gfx.DrawString("Dirección:", fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, pagina.Width, 15), XStringFormats.TopLeft);
        yPoint += 20;

        // Encabezado de información del proveedor
        var anchoColumna1 = 100;
        var anchoColumna2 = 150;
        var anchoColumna3 = 100;
        var anchoColumna4 = 150;

        // Fila 1
        gfx.DrawString("Proveedor:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoColumna1, 15), XStringFormats.TopLeft);

        gfx.DrawString(proveedor, fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1, yPoint, anchoColumna2, 15), XStringFormats.TopLeft);

        gfx.DrawString("Número de documento:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2, yPoint, anchoColumna3, 15), XStringFormats.TopLeft);

        gfx.DrawString(documento, fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2 + anchoColumna3, yPoint, anchoColumna4, 15), XStringFormats.TopLeft);
        yPoint += 15;

        // Fila 2
        gfx.DrawString("Dirección:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoColumna1, 15), XStringFormats.TopLeft);

        gfx.DrawString(direccion, fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1, yPoint, anchoColumna2, 15), XStringFormats.TopLeft);

        gfx.DrawString("Documento externo:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2, yPoint, anchoColumna3, 15), XStringFormats.TopLeft);
        yPoint += 15;

        // Fila 3
        gfx.DrawString("NIT:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoColumna1, 15), XStringFormats.TopLeft);

        gfx.DrawString(nif, fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1, yPoint, anchoColumna2, 15), XStringFormats.TopLeft);

        gfx.DrawString("Fecha:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2, yPoint, anchoColumna3, 15), XStringFormats.TopLeft);

        gfx.DrawString(fecha.ToShortDateString(), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2 + anchoColumna3, yPoint, anchoColumna4, 15), XStringFormats.TopLeft);
        yPoint += 15;

        // Fila 4
        gfx.DrawString("Vencimiento:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2, yPoint, anchoColumna3, 15), XStringFormats.TopLeft);

        gfx.DrawString(fecha.ToShortDateString(), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2 + anchoColumna3, yPoint, anchoColumna4, 15), XStringFormats.TopLeft);
        yPoint += 20;
    }

    private static void DibujarEncabezadosTablaEntrada(XGraphics gfx, PdfPage pagina, XFont fontEncabezado, int margenIzquierdo, int margenDerecho, ref double yPoint) {
        // Definir anchos de columnas para la tabla de productos
        var anchoNumero = 30;
        var anchoProducto = 220;
        var anchoCantidad = 50;
        var anchoPrecio = 60;
        var anchoImpuesto = 50;
        var anchoDescuento = 60;
        var anchoTotal = 60;

        // Verificar y ajustar anchos si es necesario
        var anchoDisponible = pagina.Width - margenIzquierdo - margenDerecho;
        var sumaAnchos = anchoNumero + anchoProducto + anchoCantidad + anchoPrecio +
                         anchoImpuesto + anchoDescuento + anchoTotal;

        if (sumaAnchos > anchoDisponible) {
            // Reducir el ancho del producto proporcionalmente
            anchoProducto -= (sumaAnchos - (int) anchoDisponible.Value);
            anchoProducto = Math.Max(anchoProducto, 100); // Mínimo 100 puntos
        }

        // Encabezados de la tabla de productos
        gfx.DrawString("#", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoNumero, 15), XStringFormats.TopCenter);

        gfx.DrawString("Producto", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero, yPoint, anchoProducto, 15), XStringFormats.TopLeft);

        gfx.DrawString("Cantidad", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto, yPoint, anchoCantidad, 15), XStringFormats.TopRight);

        gfx.DrawString("Precio", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto + anchoCantidad, yPoint, anchoPrecio, 15), XStringFormats.TopRight);

        gfx.DrawString("Impuesto", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto + anchoCantidad + anchoPrecio, yPoint, anchoImpuesto, 15), XStringFormats.TopRight);

        gfx.DrawString("Descuento", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto + anchoCantidad + anchoPrecio + anchoImpuesto, yPoint, anchoDescuento, 15), XStringFormats.TopRight);

        gfx.DrawString("Total", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto + anchoCantidad + anchoPrecio + anchoImpuesto + anchoDescuento, yPoint, anchoTotal, 15), XStringFormats.TopRight);

        yPoint += 15;
        gfx.DrawLine(XPens.Black, margenIzquierdo, yPoint, pagina.Width - margenDerecho, yPoint);
        yPoint += 5;
    }

    private static void DibujarFilaEntrada(XGraphics gfx, XFont fontContenido, string[] fila, int numeroFila,
                                         int margenIzquierdo, ref double yPoint, int alturaFila,
                                         CultureInfo culture, ref decimal subtotal) {
        // Definir anchos de columnas (consistentes con los encabezados)
        var anchoNumero = 30;
        var anchoProducto = 220;
        var anchoCantidad = 50;
        var anchoPrecio = 60;
        var anchoImpuesto = 50;
        var anchoDescuento = 60;
        var anchoTotal = 60;

        // Número
        gfx.DrawString(numeroFila.ToString(), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoNumero, alturaFila), XStringFormats.TopCenter);

        // Producto
        gfx.DrawString(fila[1], fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero, yPoint, anchoProducto, alturaFila), XStringFormats.TopLeft);

        // Cantidad
        gfx.DrawString(fila[2], fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto, yPoint, anchoCantidad, alturaFila), XStringFormats.TopRight);

        // Precio
        var precio = decimal.TryParse(fila.Length > 3 ? fila[3] : "0", NumberStyles.Any, CultureInfo.InvariantCulture, out var valorPrecio)
            ? valorPrecio
            : 0.00m;
        gfx.DrawString(precio.ToString("N2", CultureInfo.InvariantCulture), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto + anchoCantidad, yPoint, anchoPrecio, alturaFila), XStringFormats.TopRight);

        // Impuesto
        var impuesto = decimal.TryParse(fila.Length > 4 ? fila[4] : "0", NumberStyles.Any, CultureInfo.InvariantCulture, out var valorImpuesto)
            ? valorImpuesto
            : 0.00m;
        gfx.DrawString(impuesto.ToString("N2", CultureInfo.InvariantCulture), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto + anchoCantidad + anchoPrecio, yPoint, anchoImpuesto, alturaFila), XStringFormats.TopRight);

        // Descuento
        var descuento = fila.Length > 5 ? fila[5] : "0.00%";
        gfx.DrawString(descuento, fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto + anchoCantidad + anchoPrecio + anchoImpuesto, yPoint, anchoDescuento, alturaFila), XStringFormats.TopRight);

        // Total
        var total = decimal.TryParse(fila.Length > 6 ? fila[6] : "0", NumberStyles.Any, CultureInfo.InvariantCulture, out var valorTotal)
            ? valorTotal
            : precio * decimal.Parse(fila[2]);
        gfx.DrawString(total.ToString("N2", CultureInfo.InvariantCulture), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto + anchoCantidad + anchoPrecio + anchoImpuesto + anchoDescuento, yPoint, anchoTotal, alturaFila), XStringFormats.TopRight);

        subtotal += total;
        yPoint += alturaFila;
    }

    private static void DibujarPiePaginaEntrada(XGraphics gfx, PdfPage pagina, XFont fontNegrita, XFont fontContenido,
                                              XFont fontSubtitulo, decimal subtotal, int margenIzquierdo,
                                              int margenDerecho, int margenInferior, ref double yPoint,
                                              int paginaActual, int totalPaginas, CultureInfo culture) {
        // Definir anchos de columnas (consistentes con los encabezados)
        var anchoNumero = 30;
        var anchoProducto = 220;
        var anchoCantidad = 50;
        var anchoPrecio = 60;
        var anchoImpuesto = 50;
        var anchoDescuento = 60;
        var anchoTotal = 60;

        // Totales
        yPoint += 10;
        gfx.DrawLine(XPens.Black, margenIzquierdo, yPoint, pagina.Width - margenDerecho, yPoint);
        yPoint += 10;

        // Descuento general
        gfx.DrawString("Descuento:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto + anchoCantidad + anchoPrecio + anchoImpuesto, yPoint, anchoDescuento, 15), XStringFormats.TopRight);

        gfx.DrawString("0.00 $", fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto + anchoCantidad + anchoPrecio + anchoImpuesto + anchoDescuento, yPoint, anchoTotal, 15), XStringFormats.TopRight);
        yPoint += 15;

        // Subtotal
        gfx.DrawString("Subtotal:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto + anchoCantidad + anchoPrecio + anchoImpuesto, yPoint, anchoDescuento, 15), XStringFormats.TopRight);

        gfx.DrawString(subtotal.ToString("N2", CultureInfo.InvariantCulture) + " $", fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto + anchoCantidad + anchoPrecio + anchoImpuesto + anchoDescuento, yPoint, anchoTotal, 15), XStringFormats.TopRight);
        yPoint += 15;

        // Total
        gfx.DrawString("Total:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto + anchoCantidad + anchoPrecio + anchoImpuesto, yPoint, anchoDescuento, 15), XStringFormats.TopRight);

        gfx.DrawString(subtotal.ToString("N2", CultureInfo.InvariantCulture) + " $", fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoProducto + anchoCantidad + anchoPrecio + anchoImpuesto + anchoDescuento, yPoint, anchoTotal, 15), XStringFormats.TopRight);
        yPoint += 20;

        // Pie de página
        var fechaGeneracion = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        var textoPie = $"{fechaGeneracion} - Página {paginaActual} de {totalPaginas}";

        gfx.DrawString(textoPie, fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo, pagina.Height - margenInferior, pagina.Width - margenIzquierdo - margenDerecho, 20),
            XStringFormats.BottomRight);
    }

    public static void GenerarFacturaVenta(DateTime fecha, List<string[]> productos,
                                     string[] datosCliente, string numeroFactura,
                                     string estadoPago, string metodoPago,
                                     decimal cantidadPagada) {
        // Crear un nuevo documento PDF
        var documento = new PdfDocument();
        documento.Info.Title = $"Factura {numeroFactura}";
        documento.Info.Author = "aDVanceERP";

        // Configurar márgenes
        const int margenIzquierdo = 40;
        const int margenDerecho = 40;
        const int margenSuperior = 40;
        const int margenInferior = 40;
        const int alturaEncabezado = 150;
        const int alturaPie = 30;
        const int alturaFila = 15;
        const int maxFilasPorPagina = 20; // Máximo de productos por página

        // Fuentes
        var fontTitulo = new XFont("Arial", 16, XFontStyleEx.Bold);
        var fontSubtitulo = new XFont("Arial", 10, XFontStyleEx.Regular);
        var fontContenido = new XFont("Arial", 9, XFontStyleEx.Regular);
        var fontEncabezado = new XFont("Arial", 9, XFontStyleEx.Bold);
        var fontNegrita = new XFont("Arial", 9, XFontStyleEx.Bold);

        var culture = new CultureInfo("es-ES");
        decimal totalFactura = 0;
        int paginaActual = 1;
        int productosProcesados = 0;
        PdfPage pagina = null;
        XGraphics gfx = null;
        double yPoint = 0;

        while (productosProcesados < productos.Count) {
            // Crear nueva página si es necesario
            if (pagina == null || productosProcesados % maxFilasPorPagina == 0) {
                pagina = documento.AddPage();
                pagina.Size = PageSize.Letter;
                gfx = XGraphics.FromPdfPage(pagina);
                yPoint = margenSuperior;

                // Dibujar encabezado en cada página
                DibujarEncabezadoFactura(gfx, pagina, fontTitulo, fontContenido, fontNegrita,
                    fecha, datosCliente, numeroFactura, estadoPago,
                    margenIzquierdo, margenDerecho, ref yPoint);

                // Dibujar encabezados de tabla
                DibujarEncabezadosTablaFactura(gfx, pagina, fontEncabezado,
                    margenIzquierdo, margenDerecho, ref yPoint);
            }

            // Dibujar filas de productos
            int productosEnPagina = Math.Min(maxFilasPorPagina, productos.Count - productosProcesados);
            for (int i = 0; i < productosEnPagina; i++) {
                var producto = productos[productosProcesados];
                decimal totalLinea = DibujarFilaProducto(gfx, pagina, fontContenido, producto, productosProcesados + 1,
                                                       margenIzquierdo, margenDerecho, ref yPoint, alturaFila, culture);
                totalFactura += totalLinea;
                productosProcesados++;
            }

            // Dibujar totales si es última página o hay muchos productos
            if (productosProcesados == productos.Count || productosProcesados % maxFilasPorPagina == 0) {
                DibujarPiePaginaFactura(gfx, pagina, fontNegrita, fontContenido, fontSubtitulo,
                                      totalFactura, metodoPago, cantidadPagada,
                                      margenIzquierdo, margenDerecho, margenInferior,
                                      ref yPoint, paginaActual, documento.Pages.Count, culture);
                paginaActual++;
            }
        }

        // Guardar el documento
        var nombreArchivo = $"factura-venta-{numeroFactura}.pdf";

        if (documento.Pages.Count <= 0)
            return;

        documento.Save(nombreArchivo);

        // Mostrar el documento PDF al usuario
        Process.Start(new ProcessStartInfo {
            FileName = nombreArchivo,
            UseShellExecute = true
        });
    }

    // Métodos auxiliares para GenerarFacturaVenta
    private static void DibujarEncabezadoFactura(XGraphics gfx, PdfPage pagina, XFont fontTitulo,
                                               XFont fontContenido, XFont fontNegrita,
                                               DateTime fecha, string[] datosCliente,
                                               string numeroFactura, string estadoPago,
                                               int margenIzquierdo, int margenDerecho, ref double yPoint) {
        var anchoColumna1 = 90;
        var anchoColumna2 = 90;
        var anchoColumna3 = 60;
        var anchoColumna4 = 200;

        gfx.DrawString("Factura N°:", fontNegrita, XBrushes.Black,
            new XRect(pagina.Width - margenDerecho - anchoColumna1 - anchoColumna2 + 30, yPoint, anchoColumna1, 15), XStringFormats.TopLeft);
        gfx.DrawString(numeroFactura, fontContenido, XBrushes.Black,
            new XRect(pagina.Width - margenDerecho - anchoColumna2 - 10, yPoint, anchoColumna2, 15), XStringFormats.TopLeft);
        yPoint += 30;

        // Agregar título
        gfx.DrawString("FACTURA", fontTitulo, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, pagina.Width - margenIzquierdo - margenDerecho, 20),
            XStringFormats.TopCenter);
        yPoint += 50;

        // Fila 1 - Fecha, Vencimiento y estado del pago
        gfx.DrawString("Fecha:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoColumna1, 15), XStringFormats.TopLeft);

        gfx.DrawString(fecha.ToShortDateString(), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1, yPoint, anchoColumna2, 15), XStringFormats.TopLeft);
        yPoint += 15;

        gfx.DrawString("Vencimiento:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoColumna1, 15), XStringFormats.TopLeft);

        gfx.DrawString(fecha.ToShortDateString(), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1, yPoint, anchoColumna2, 15), XStringFormats.TopLeft);
        yPoint += 15;

        gfx.DrawString("Estado del pago:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoColumna1, 15), XStringFormats.TopLeft);

        gfx.DrawString(estadoPago, fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1, yPoint, anchoColumna2, 15), XStringFormats.TopLeft);
        yPoint += 30;

        // Fila 2 - Cliente, Dirección y CI o NIT
        gfx.DrawString("Cliente:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2, yPoint - 60, anchoColumna3, 15), XStringFormats.TopLeft);

        gfx.DrawString(datosCliente.Length > 0 ? datosCliente[0] : "Anónimo", fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2 + anchoColumna3, yPoint - 60, anchoColumna4, 15), XStringFormats.TopLeft);

        if (datosCliente.Length > 1) {
            gfx.DrawString("Dirección:", fontNegrita, XBrushes.Black,
                new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2, yPoint - 45, anchoColumna3, 15), XStringFormats.TopLeft);

            gfx.DrawString(datosCliente[1], fontContenido, XBrushes.Black,
                new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2 + anchoColumna3, yPoint - 45, anchoColumna2, 15), XStringFormats.TopLeft);
        }

        if (datosCliente.Length > 2) {
            gfx.DrawString("CI o NIT:", fontNegrita, XBrushes.Black,
                new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2, yPoint - 30, anchoColumna3, 15), XStringFormats.TopLeft);

            gfx.DrawString(datosCliente[2], fontContenido, XBrushes.Black,
                new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2 + anchoColumna3, yPoint - 30, anchoColumna2, 15), XStringFormats.TopLeft);
        }
    }

    private static void DibujarEncabezadosTablaFactura(XGraphics gfx, PdfPage pagina, XFont fontEncabezado,
    int margenIzquierdo, int margenDerecho, ref double yPoint) {
        // Definir anchos de columnas para la tabla de productos
        var anchos = CalcularAnchosColumnas(pagina.Width - margenIzquierdo - margenDerecho);

        // Encabezados de la tabla de productos
        double xPos = margenIzquierdo - 11;

        // Columna #
        gfx.DrawString("#", fontEncabezado, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoNumero, 15), XStringFormats.TopCenter);
        xPos += anchos.AnchoNumero;

        // Columna Descripción
        gfx.DrawString("Descripción de producto", fontEncabezado, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoDescripcion, 15), XStringFormats.TopLeft);
        xPos += anchos.AnchoDescripcion;

        // Columna Cantidad
        gfx.DrawString("Cantidad", fontEncabezado, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoCantidad, 15), XStringFormats.TopRight);
        xPos += anchos.AnchoCantidad;

        // Columna Precio
        gfx.DrawString("Precio", fontEncabezado, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoPrecio, 15), XStringFormats.TopRight);
        xPos += anchos.AnchoPrecio;

        // Columna Impuesto
        gfx.DrawString("Impuesto", fontEncabezado, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoImpuesto, 15), XStringFormats.TopRight);
        xPos += anchos.AnchoImpuesto;

        // Columna Descuento
        gfx.DrawString("Descuento", fontEncabezado, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoDescuento, 15), XStringFormats.TopRight);
        xPos += anchos.AnchoDescuento;

        // Columna Total
        gfx.DrawString("Total", fontEncabezado, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoTotal, 15), XStringFormats.TopRight);

        yPoint += 15;
        gfx.DrawLine(XPens.Black, margenIzquierdo, yPoint, pagina.Width - margenDerecho, yPoint);
        yPoint += 5;
    }

    private static decimal DibujarFilaProducto(XGraphics gfx, PdfPage pagina, XFont fontContenido, string[] producto,
                                             int numeroFila, int margenIzquierdo, int margenDerecho, ref double yPoint,
                                             int alturaFila, CultureInfo culture) {
        var anchos = CalcularAnchosColumnas(pagina.Width - margenIzquierdo - margenDerecho);
        double xPos = margenIzquierdo - 11;

        // Número
        gfx.DrawString(numeroFila.ToString(), fontContenido, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoNumero, alturaFila), XStringFormats.TopCenter);
        xPos += anchos.AnchoNumero;

        // Descripción
        gfx.DrawString(producto[1], fontContenido, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoDescripcion, alturaFila), XStringFormats.TopLeft);
        xPos += anchos.AnchoDescripcion;

        // Cantidad
        gfx.DrawString(producto[2], fontContenido, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoCantidad, alturaFila), XStringFormats.TopRight);
        xPos += anchos.AnchoCantidad;

        // Precio
        var precio = decimal.TryParse(producto.Length > 3 ? producto[3] : "0", NumberStyles.Any, CultureInfo.InvariantCulture, out var valorPrecio)
            ? valorPrecio
            : 0.00m;
        gfx.DrawString(precio.ToString("N2", CultureInfo.InvariantCulture), fontContenido, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoPrecio, alturaFila), XStringFormats.TopRight);
        xPos += anchos.AnchoPrecio;

        // Impuesto
        gfx.DrawString(producto.Length > 4 ? producto[4] : "—", fontContenido, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoImpuesto, alturaFila), XStringFormats.TopCenter);
        xPos += anchos.AnchoImpuesto;

        // Descuento
        var descuento = producto.Length > 5 ? producto[5] : "0.00%";
        gfx.DrawString(descuento, fontContenido, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoDescuento, alturaFila), XStringFormats.TopRight);
        xPos += anchos.AnchoDescuento;

        // Total
        var total = decimal.TryParse(producto.Length > 6 ? producto[6] : "0", NumberStyles.Any, CultureInfo.InvariantCulture, out var valorTotal)
            ? valorTotal
            : precio * decimal.Parse(producto[2]);
        gfx.DrawString(total.ToString("N2", CultureInfo.InvariantCulture), fontContenido, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoTotal, alturaFila), XStringFormats.TopRight);

        yPoint += alturaFila;
        return total;
    }

    // Estructura para mantener consistentes los anchos de columna
    private static (int AnchoNumero, int AnchoDescripcion, int AnchoCantidad,
                   int AnchoPrecio, int AnchoImpuesto, int AnchoDescuento,
                   int AnchoTotal) CalcularAnchosColumnas(double anchoDisponible) {
        // Valores base para los anchos
        int anchoNumero = 30;
        int anchoDescripcion = 250;
        int anchoCantidad = 60;
        int anchoPrecio = 70;
        int anchoImpuesto = 60;
        int anchoDescuento = 70;
        int anchoTotal = 80;

        // Calcular suma total de anchos
        int sumaAnchos = anchoNumero + anchoDescripcion + anchoCantidad +
                        anchoPrecio + anchoImpuesto + anchoDescuento + anchoTotal;

        // Ajustar si excede el ancho disponible
        if (sumaAnchos > anchoDisponible) {
            // Calcular factor de reducción
            double factor = anchoDisponible / sumaAnchos;

            // Aplicar factor a cada columna (excepto número y cantidades)
            anchoDescripcion = (int) (anchoDescripcion * factor);
            anchoPrecio = (int) (anchoPrecio * factor);
            anchoImpuesto = (int) (anchoImpuesto * factor);
            anchoDescuento = (int) (anchoDescuento * factor);
            anchoTotal = (int) (anchoTotal * factor);

            // Asegurar mínimos
            anchoDescripcion = Math.Max(anchoDescripcion, 150);
            anchoPrecio = Math.Max(anchoPrecio, 50);
            anchoImpuesto = Math.Max(anchoImpuesto, 50);
            anchoDescuento = Math.Max(anchoDescuento, 50);
            anchoTotal = Math.Max(anchoTotal, 60);
        }

        return (anchoNumero, anchoDescripcion, anchoCantidad,
                anchoPrecio, anchoImpuesto, anchoDescuento,
                anchoTotal);
    }

    private static void DibujarPiePaginaFactura(XGraphics gfx, PdfPage pagina, XFont fontNegrita,
                                          XFont fontContenido, XFont fontSubtitulo,
                                          decimal totalFactura, string metodoPago,
                                          decimal cantidadPagada, int margenIzquierdo,
                                          int margenDerecho, int margenInferior,
                                          ref double yPoint, int paginaActual,
                                          int totalPaginas, CultureInfo culture) {
        var anchos = CalcularAnchosColumnas(pagina.Width - margenIzquierdo - margenDerecho);
        double xPos = margenIzquierdo + anchos.AnchoNumero + anchos.AnchoDescripcion;

        // Línea separadora antes de los totales
        yPoint += 5;
        gfx.DrawLine(XPens.Black, margenIzquierdo, yPoint, pagina.Width - margenDerecho, yPoint);
        yPoint += 10;

        // Total factura - Alineado con la columna "Total" de los productos
        double xPosTotales = margenIzquierdo + anchos.AnchoNumero + anchos.AnchoDescripcion +
                            anchos.AnchoCantidad + anchos.AnchoPrecio + anchos.AnchoImpuesto - 11;

        // Etiqueta "Total"
        gfx.DrawString("Total", fontNegrita, XBrushes.Black,
            new XRect(xPosTotales, yPoint, anchos.AnchoDescuento, 15), XStringFormats.TopRight);

        // Valor total - Alineado con la columna "Total" de los productos
        double xPosValorTotal = xPosTotales + anchos.AnchoDescuento;
        gfx.DrawString(totalFactura.ToString("N2", CultureInfo.InvariantCulture) + " $", fontNegrita, XBrushes.Black,
            new XRect(xPosValorTotal, yPoint, anchos.AnchoTotal, 15), XStringFormats.TopRight);

        yPoint += 20;

        // Información de pago (solo en la última página)
        if (paginaActual == totalPaginas) {
            // Restablecer posición X para la información de pago
            xPos = margenIzquierdo;

            // Método de pago
            gfx.DrawString("Método de pago:", fontNegrita, XBrushes.Black,
                new XRect(xPos, yPoint, 120, 15), XStringFormats.TopLeft);

            gfx.DrawString(metodoPago, fontContenido, XBrushes.Black,
                new XRect(xPos + 120, yPoint, 150, 15), XStringFormats.TopLeft);
            yPoint += 15;

            // Efectivo si aplica
            if (metodoPago.Equals("Efectivo", StringComparison.OrdinalIgnoreCase)) {
                gfx.DrawString("Efectivo:", fontNegrita, XBrushes.Black,
                    new XRect(xPos, yPoint, 120, 15), XStringFormats.TopLeft);

                gfx.DrawString(cantidadPagada.ToString("N2", CultureInfo.InvariantCulture) + " $", fontContenido, XBrushes.Black,
                    new XRect(xPos + 120, yPoint, 150, 15), XStringFormats.TopLeft);
                yPoint += 15;
            }

            // Cantidad pagada
            gfx.DrawString("Cantidad pagada:", fontNegrita, XBrushes.Black,
                new XRect(xPos, yPoint, 120, 15), XStringFormats.TopLeft);

            gfx.DrawString(cantidadPagada.ToString("N2", CultureInfo.InvariantCulture) + " $", fontContenido, XBrushes.Black,
                new XRect(xPos + 120, yPoint, 150, 15), XStringFormats.TopLeft);
            yPoint += 15;

            // Cantidad adeudada
            decimal cantidadAdeudada = totalFactura - cantidadPagada;
            gfx.DrawString("Cantidad adeudada:", fontNegrita, XBrushes.Black,
                new XRect(xPos, yPoint, 120, 15), XStringFormats.TopLeft);

            gfx.DrawString(cantidadAdeudada.ToString("N2", CultureInfo.InvariantCulture) + " $", fontContenido, XBrushes.Black,
                new XRect(xPos + 120, yPoint, 150, 15), XStringFormats.TopLeft);
            yPoint += 20;
        }

        // Pie de página
        var fechaGeneracion = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        var textoPie = $"Generado con aDVanceERP - {fechaGeneracion} - Página {paginaActual} de {totalPaginas}";

        gfx.DrawString(textoPie, fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo, pagina.Height - margenInferior, pagina.Width - margenIzquierdo - margenDerecho, 20),
            XStringFormats.BottomLeft);
    }

    #region Reporte de cierre de caja

    public static void GenerarReporteCierreCaja(DateTime fechaApertura, DateTime fechaCierre, decimal saldoInicial, decimal saldoFinal, int idCaja, List<string[]> movimientos, string estadoCaja = "Cerrada", bool mostrar = true) {
        // Crear un nuevo documento PDF
        var documento = new PdfDocument();
        documento.Info.Title = "Reporte de Cierre de Caja";
        documento.Info.Author = "aDVanceERP";

        // Configurar márgenes (en puntos, 1 punto = 1/72 pulgadas)
        const int margenIzquierdo = 40;
        const int margenDerecho = 40;
        const int margenSuperior = 40;
        const int margenInferior = 40;
        const int alturaEncabezado = 120;
        const int alturaPie = 30;
        const int alturaFila = 15;
        const int maxFilasPorPagina = 30;

        // Fuentes
        var fontTitulo = new XFont("Arial", 14, XFontStyleEx.Bold);
        var fontSubtitulo = new XFont("Arial", 10, XFontStyleEx.Regular);
        var fontContenido = new XFont("Arial", 9, XFontStyleEx.Regular);
        var fontEncabezado = new XFont("Arial", 9, XFontStyleEx.Bold);
        var fontNegrita = new XFont("Arial", 9, XFontStyleEx.Bold);

        var culture = new CultureInfo("es-ES");
        decimal totalIngresos = 0;
        decimal totalEgresos = 0;
        int paginaActual = 1;
        int filasProcesadas = 0;
        PdfPage pagina = null;
        XGraphics gfx = null;
        double yPoint = 0;

        while (filasProcesadas < movimientos.Count) {
            // Crear nueva página si es necesario
            if (pagina == null || filasProcesadas % maxFilasPorPagina == 0) {
                pagina = documento.AddPage();
                pagina.Size = PageSize.Letter;
                gfx = XGraphics.FromPdfPage(pagina);
                yPoint = margenSuperior;

                // Dibujar encabezado en cada página
                DibujarEncabezadoCierreCaja(gfx, pagina, fontTitulo, fontSubtitulo, fontNegrita,
                    idCaja, estadoCaja, fechaApertura, fechaCierre, saldoInicial, saldoFinal,
                    margenIzquierdo, margenDerecho, ref yPoint);

                // Dibujar encabezados de tabla
                DibujarEncabezadosTablaCierreCaja(gfx, pagina, fontEncabezado,
                    margenIzquierdo, margenDerecho, ref yPoint);
            }

            // Dibujar filas de datos
            int filasEnPagina = Math.Min(maxFilasPorPagina, movimientos.Count - filasProcesadas);
            for (int i = 0; i < filasEnPagina; i++) {
                var fila = movimientos[filasProcesadas];
                DibujarFilaMovimiento(gfx, fontContenido, fila, filasProcesadas + 1,
                                    margenIzquierdo, ref yPoint, alturaFila, culture,
                                    ref totalIngresos, ref totalEgresos);
                filasProcesadas++;
            }

            // Dibujar total parcial si es última página o hay muchas filas
            if (filasProcesadas == movimientos.Count || filasProcesadas % maxFilasPorPagina == 0) {
                DibujarPiePaginaCierreCaja(gfx, pagina, fontNegrita, fontContenido, fontSubtitulo,
                                          totalIngresos, totalEgresos, saldoInicial, saldoFinal,
                                          margenIzquierdo, margenDerecho, margenInferior,
                                          ref yPoint, paginaActual, documento.Pages.Count, culture);
                paginaActual++;
            }
        }

        // Guardar el documento
        var nombreArchivo = $"cierre-caja-{idCaja}-{fechaCierre:yyyyMMdd}.pdf";

        if (documento.Pages.Count > 0)
            documento.Save(nombreArchivo);

        // Mostrar el documento PDF al usuario
        if (mostrar)
            Process.Start(new ProcessStartInfo {
                FileName = nombreArchivo,
                UseShellExecute = true
            });
    }

    // Métodos auxiliares para GenerarReporteCierreCaja
    private static void DibujarEncabezadoCierreCaja(XGraphics gfx, PdfPage pagina, XFont fontTitulo,
        XFont fontSubtitulo, XFont fontNegrita, int idCaja, string estadoCaja,
        DateTime fechaApertura, DateTime fechaCierre, decimal saldoInicial, decimal saldoFinal,
        int margenIzquierdo, int margenDerecho, ref double yPoint) {
        // Agregar título
        gfx.DrawString("REPORTE DE CIERRE DE CAJA", fontTitulo, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, pagina.Width - margenIzquierdo - margenDerecho, 20),
            XStringFormats.TopLeft);
        yPoint += 25;

        // Información de la caja
        var anchoColumna1 = 100;
        var anchoColumna2 = 150;
        var anchoColumna3 = 100;
        var anchoColumna4 = 150;

        // Fila 1 - ID Caja y Estado
        gfx.DrawString("Caja N°:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoColumna1, 15), XStringFormats.TopLeft);
        gfx.DrawString(idCaja.ToString(), fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1, yPoint, anchoColumna2, 15), XStringFormats.TopLeft);

        gfx.DrawString("Estado:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2, yPoint, anchoColumna3, 15), XStringFormats.TopLeft);
        gfx.DrawString(estadoCaja, fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2 + anchoColumna3, yPoint, anchoColumna4, 15), XStringFormats.TopLeft);
        yPoint += 15;

        // Fila 2 - Fecha Apertura y Fecha Cierre
        gfx.DrawString("Fecha Apertura:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoColumna1, 15), XStringFormats.TopLeft);
        gfx.DrawString(fechaApertura.ToString("dd/MM/yyyy HH:mm:ss"), fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1, yPoint, anchoColumna2, 15), XStringFormats.TopLeft);

        gfx.DrawString("Fecha Cierre:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2, yPoint, anchoColumna3, 15), XStringFormats.TopLeft);
        gfx.DrawString(fechaCierre.ToString("dd/MM/yyyy HH:mm:ss"), fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2 + anchoColumna3, yPoint, anchoColumna4, 15), XStringFormats.TopLeft);
        yPoint += 15;

        // Fila 3 - Saldo Inicial y Saldo Final
        gfx.DrawString("Saldo Inicial:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoColumna1, 15), XStringFormats.TopLeft);
        gfx.DrawString(saldoInicial.ToString("N2", CultureInfo.InvariantCulture) + " $", fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1, yPoint, anchoColumna2, 15), XStringFormats.TopLeft);

        gfx.DrawString("Saldo Final:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2, yPoint, anchoColumna3, 15), XStringFormats.TopLeft);
        gfx.DrawString(saldoFinal.ToString("N2", CultureInfo.InvariantCulture) + " $", fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo + anchoColumna1 + anchoColumna2 + anchoColumna3, yPoint, anchoColumna4, 15), XStringFormats.TopLeft);
        yPoint += 30;
    }

    private static void DibujarEncabezadosTablaCierreCaja(XGraphics gfx, PdfPage pagina, XFont fontEncabezado,
    int margenIzquierdo, int margenDerecho, ref double yPoint) {
        // Calcular ancho disponible
        double anchoDisponible = pagina.Width - margenIzquierdo - margenDerecho;

        // Definir anchos base de columnas
        var anchos = CalcularAnchosColumnasCierreCaja(anchoDisponible);

        // Encabezados de la tabla
        double xPos = margenIzquierdo;

        // Columna #
        gfx.DrawString("#", fontEncabezado, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoNumero, 15), XStringFormats.TopCenter);
        xPos += anchos.AnchoNumero;

        // Columna Fecha
        gfx.DrawString("Fecha/Hora", fontEncabezado, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoFecha, 15), XStringFormats.TopLeft);
        xPos += anchos.AnchoFecha;

        // Columna Concepto
        gfx.DrawString("Concepto", fontEncabezado, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoConcepto, 15), XStringFormats.TopLeft);
        xPos += anchos.AnchoConcepto;

        // Columna Tipo
        gfx.DrawString("Tipo", fontEncabezado, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoTipo, 15), XStringFormats.TopCenter);
        xPos += anchos.AnchoTipo;

        // Columna Monto
        gfx.DrawString("Monto", fontEncabezado, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoMonto, 15), XStringFormats.TopRight);
        xPos += anchos.AnchoMonto;

        // Columna Observaciones
        gfx.DrawString("Observaciones", fontEncabezado, XBrushes.Black,
            new XRect(xPos + 10, yPoint, anchos.AnchoObservaciones, 15), XStringFormats.TopLeft);

        yPoint += 15;
        gfx.DrawLine(XPens.Black, margenIzquierdo, yPoint, pagina.Width - margenDerecho, yPoint);
        yPoint += 5;
    }

    private static (int AnchoNumero, int AnchoFecha, int AnchoConcepto,
                   int AnchoTipo, int AnchoMonto, int AnchoObservaciones)
        CalcularAnchosColumnasCierreCaja(double anchoDisponible) {
        // Valores base para los anchos (en puntos)
        int anchoNumero = 30;      // Columna #
        int anchoFecha = 100;      // Columna Fecha
        int anchoConcepto = 100;   // Columna Concepto (ajustable)
        int anchoTipo = 30;        // Columna Tipo
        int anchoMonto = 90;       // Columna Monto
        int anchoObservaciones = 150; // Columna Observaciones (ajustable)

        // Calcular suma total de anchos
        int sumaAnchos = anchoNumero + anchoFecha + anchoConcepto +
                        anchoTipo + anchoMonto + anchoObservaciones;

        // Si los anchos exceden el espacio disponible, ajustar las columnas de texto
        if (sumaAnchos > anchoDisponible) {
            // Calcular el exceso
            int exceso = (int) (sumaAnchos - anchoDisponible);

            // Reducir proporcionalmente las columnas de texto largo
            int reduccionConcepto = (int) (exceso * 0.4); // 60% del ajuste a Concepto
            int reduccionObservaciones = (int) (exceso * 0.6); // 40% del ajuste a Observaciones

            // Aplicar reducción asegurando un mínimo
            anchoConcepto = Math.Max(anchoConcepto - reduccionConcepto, 120);
            anchoObservaciones = Math.Max(anchoObservaciones - reduccionObservaciones, 80);
        }

        return (anchoNumero, anchoFecha, anchoConcepto, anchoTipo, anchoMonto, anchoObservaciones);
    }

    private static void DibujarFilaMovimiento(XGraphics gfx, XFont fontContenido, string[] fila, int numeroFila,
        int margenIzquierdo, ref double yPoint, int alturaFila, CultureInfo culture,
        ref decimal totalIngresos, ref decimal totalEgresos) {
        // Calcular anchos de columnas
        var anchos = CalcularAnchosColumnasCierreCaja(gfx.PageSize.Width - margenIzquierdo * 2);

        double xPos = margenIzquierdo;

        // Número
        gfx.DrawString(numeroFila.ToString(), fontContenido, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoNumero, alturaFila), XStringFormats.TopCenter);
        xPos += anchos.AnchoNumero;

        // Fecha
        gfx.DrawString(fila[0], fontContenido, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoFecha, alturaFila), XStringFormats.TopLeft);
        xPos += anchos.AnchoFecha;

        // Concepto
        gfx.DrawString(fila[1], fontContenido, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoConcepto, alturaFila), XStringFormats.TopLeft);
        xPos += anchos.AnchoConcepto;

        // Tipo
        gfx.DrawString(fila[2], fontContenido, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoTipo, alturaFila), XStringFormats.TopCenter);
        xPos += anchos.AnchoTipo;

        // Monto
        var monto = decimal.TryParse(fila[3], NumberStyles.Any, CultureInfo.InvariantCulture, out var valorMonto)
            ? valorMonto : 0.00m;
        gfx.DrawString(monto.ToString("N2", CultureInfo.InvariantCulture), fontContenido, XBrushes.Black,
            new XRect(xPos, yPoint, anchos.AnchoMonto, alturaFila), XStringFormats.TopRight);
        xPos += anchos.AnchoMonto;

        // Observaciones
        string observaciones = fila.Length > 4 ? fila[4] : "";
        // Truncar texto si es muy largo para la columna
        if (observaciones.Length > 40)
            observaciones = observaciones.Substring(0, 38) + "...";

        gfx.DrawString(observaciones, fontContenido, XBrushes.Black,
            new XRect(xPos + 10, yPoint, anchos.AnchoObservaciones, alturaFila), XStringFormats.TopLeft);

        // Actualizar totales
        if (fila[2] == "Ingreso")
            totalIngresos += monto;
        else
            totalEgresos += monto;

        yPoint += alturaFila;
    }

    private static void DibujarPiePaginaCierreCaja(XGraphics gfx, PdfPage pagina, XFont fontNegrita,
    XFont fontContenido, XFont fontSubtitulo, decimal totalIngresos, decimal totalEgresos,
    decimal saldoInicial, decimal saldoFinal, int margenIzquierdo, int margenDerecho,
    int margenInferior, ref double yPoint, int paginaActual, int totalPaginas, CultureInfo culture) {
        // Calcular anchos de columnas (consistentes con el resto del reporte)
        var anchos = CalcularAnchosColumnasCierreCaja(pagina.Width - margenIzquierdo - margenDerecho);

        // Línea separadora
        yPoint += 10;
        gfx.DrawLine(XPens.Black, margenIzquierdo, yPoint, pagina.Width - margenDerecho, yPoint);
        yPoint += 10;

        // Posición X para las etiquetas (alineado con la columna Concepto)
        double xPosEtiquetas1 = margenIzquierdo + anchos.AnchoNumero + anchos.AnchoFecha;
        double xPosEtiquetas2 = margenIzquierdo + anchos.AnchoNumero + anchos.AnchoFecha;
        double anchoEtiquetas = anchos.AnchoConcepto + anchos.AnchoTipo;

        // Posición X para los valores (alineado con la columna Monto)
        double xPosValores1 = xPosEtiquetas1 + anchoEtiquetas;
        double xPosValores2 = xPosEtiquetas2 + anchoEtiquetas;

        // Total Ingresos
        gfx.DrawString("Total Ingresos:", fontNegrita, XBrushes.Black,
            new XRect(xPosEtiquetas1, yPoint, anchoEtiquetas, 15), XStringFormats.TopRight);
        gfx.DrawString(totalIngresos.ToString("N2", culture) + " $", fontContenido, XBrushes.Black,
            new XRect(xPosValores1, yPoint, anchos.AnchoMonto, 15), XStringFormats.TopRight);
        yPoint += 15;

        // Total Egresos
        gfx.DrawString("Total Egresos:", fontNegrita, XBrushes.Black,
            new XRect(xPosEtiquetas1, yPoint, anchoEtiquetas, 15), XStringFormats.TopRight);
        gfx.DrawString(totalEgresos.ToString("N2", culture) + " $", fontContenido, XBrushes.Black,
            new XRect(xPosValores1, yPoint, anchos.AnchoMonto, 15), XStringFormats.TopRight);
        yPoint += 15;

        // Saldo Esperado (solo en la última página)
        if (paginaActual == totalPaginas) {
            decimal saldoEsperado = saldoInicial + totalIngresos - totalEgresos;

            gfx.DrawString("Saldo Esperado:", fontNegrita, XBrushes.Black,
                new XRect(xPosEtiquetas1, yPoint, anchoEtiquetas, 15), XStringFormats.TopRight);
            gfx.DrawString(saldoEsperado.ToString("N2", culture) + " $", fontContenido, XBrushes.Black,
                new XRect(xPosValores1, yPoint, anchos.AnchoMonto, 15), XStringFormats.TopRight);
            yPoint += 25;

            // Saldo Final (campo abierto para completar manualmente)
            gfx.DrawString("Saldo Final:", fontNegrita, XBrushes.Black,
                new XRect(xPosEtiquetas2, yPoint, anchoEtiquetas, 15), XStringFormats.TopRight);

            // Dibujar línea para completar manualmente
            gfx.DrawLine(XPens.Black, xPosValores1, yPoint + 12, xPosValores1 + anchos.AnchoMonto, yPoint + 12);
            yPoint += 15;

            // Diferencia (campo abierto para completar manualmente)
            gfx.DrawString("Diferencia:", fontNegrita, XBrushes.Black,
                new XRect(xPosEtiquetas2, yPoint, anchoEtiquetas, 15), XStringFormats.TopRight);

            // Dibujar línea para completar manualmente
            gfx.DrawLine(XPens.Black, xPosValores1, yPoint + 12, xPosValores1 + anchos.AnchoMonto, yPoint + 12);
            yPoint += 15;

            // Espacio para firmas
            double anchoFirma = (pagina.Width - margenIzquierdo - margenDerecho) / 2 - 20;
            yPoint = pagina.Height - margenInferior - 80;

            // Firma "Contabilizado por"
            gfx.DrawString("Contabilizado por:", fontContenido, XBrushes.Black,
                new XRect(margenIzquierdo, yPoint, anchoFirma, 15), XStringFormats.TopLeft);
            gfx.DrawLine(XPens.Black, margenIzquierdo, yPoint + 20, margenIzquierdo + anchoFirma, yPoint + 20);
            gfx.DrawString("Firma", fontSubtitulo, XBrushes.Gray,
                new XRect(margenIzquierdo, yPoint + 22, anchoFirma, 15), XStringFormats.TopCenter);

            // Firma "Revisado por"
            gfx.DrawString("Revisado por:", fontContenido, XBrushes.Black,
                new XRect(pagina.Width - margenDerecho - anchoFirma, yPoint, anchoFirma, 15), XStringFormats.TopLeft);
            gfx.DrawLine(XPens.Black, pagina.Width - margenDerecho - anchoFirma, yPoint + 20,
                        pagina.Width - margenDerecho, yPoint + 20);
            gfx.DrawString("Firma", fontSubtitulo, XBrushes.Gray,
                new XRect(pagina.Width - margenDerecho - anchoFirma, yPoint + 22, anchoFirma, 15), XStringFormats.TopCenter);

            yPoint += 40;
        }

        // Pie de página (alineado a la derecha)
        var fechaGeneracion = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        var textoPie = $"{fechaGeneracion} - Página {paginaActual} de {totalPaginas}";

        gfx.DrawString(textoPie, fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo, pagina.Height - margenInferior,
                     pagina.Width - margenIzquierdo - margenDerecho, 20),
            XStringFormats.BottomRight);
    }

    #endregion
}