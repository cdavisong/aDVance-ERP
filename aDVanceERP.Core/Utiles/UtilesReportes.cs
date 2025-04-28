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
                                      string producto = "Todos los artículos") {
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
        var nombreArchivo = $"ventas-articulos-{fecha:yyyy-MM-dd}.pdf";
        documento.Save(nombreArchivo);

        // Mostrar el documento PDF al usuario
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

        gfx.DrawString($"Artículo: {producto}", fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, pagina.Width, 15), XStringFormats.TopLeft);
        yPoint += 20;
    }

    private static void DibujarEncabezadosTablaVentas(XGraphics gfx, PdfPage pagina, XFont fontEncabezado, int margenIzquierdo, int margenDerecho, ref double yPoint) {
        // Definir anchos de columnas
        var anchoCodigo = 50;
        var anchoArticulo = 200;
        var anchoUM = 40;
        var anchoPrecioVentaFinal = 90;
        var anchoCantidad = 60;
        var anchoTotal = 90;

        // Crear encabezados de la tabla
        gfx.DrawString("Código", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoCodigo, 15), XStringFormats.TopLeft);

        gfx.DrawString("Artículo", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo, yPoint, anchoArticulo, 15), XStringFormats.TopLeft);

        gfx.DrawString("UM", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoArticulo, yPoint, anchoUM, 15), XStringFormats.TopCenter);

        gfx.DrawString("Precio Venta Final", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoArticulo + anchoUM, yPoint, anchoPrecioVentaFinal, 15), XStringFormats.TopRight);

        gfx.DrawString("Cantidad", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoArticulo + anchoUM + anchoPrecioVentaFinal, yPoint, anchoCantidad, 15), XStringFormats.TopRight);

        gfx.DrawString("Total", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoArticulo + anchoUM + anchoPrecioVentaFinal + anchoCantidad, yPoint, anchoTotal, 15), XStringFormats.TopRight);

        yPoint += 15;
        gfx.DrawLine(XPens.Black, margenIzquierdo, yPoint, pagina.Width - margenDerecho, yPoint);
        yPoint += 5;
    }

    private static void DibujarFilaVenta(XGraphics gfx, XFont fontContenido, string[] fila, int numeroFila,
                                       int margenIzquierdo, ref double yPoint, int alturaFila,
                                       CultureInfo culture, ref decimal sumaTotal) {
        // Definir anchos de columnas (consistentes con los encabezados)
        var anchoCodigo = 50;
        var anchoArticulo = 200;
        var anchoUM = 40;
        var anchoPrecioVentaFinal = 90;
        var anchoCantidad = 60;
        var anchoTotal = 90;

        // Número de fila
        gfx.DrawString(numeroFila.ToString(), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoCodigo, alturaFila), XStringFormats.TopLeft);

        // Artículo
        gfx.DrawString(fila[1], fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo, yPoint, anchoArticulo, alturaFila), XStringFormats.TopLeft);

        // UM
        gfx.DrawString(fila.Length > 2 ? fila[2] : "", fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoArticulo, yPoint, anchoUM, alturaFila), XStringFormats.TopCenter);

        // Precio Venta Final
        var precioBase = decimal.TryParse(fila.Length > 3 ? fila[3] : "0", NumberStyles.Any, CultureInfo.InvariantCulture, out var valorBase)
            ? valorBase
            : 0.00m;
        gfx.DrawString(precioBase.ToString("N2", culture), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoArticulo + anchoUM, yPoint, anchoPrecioVentaFinal, alturaFila), XStringFormats.TopRight);

        // Cantidad
        gfx.DrawString(fila.Length > 4 ? fila[4] : "0", fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoArticulo + anchoUM + anchoPrecioVentaFinal, yPoint, anchoCantidad, alturaFila), XStringFormats.TopRight);

        // Total
        var total = decimal.TryParse(fila.Length > 5 ? fila[5] : "0", NumberStyles.Any, CultureInfo.InvariantCulture, out var valorTotal)
            ? valorTotal
            : precioBase * (fila.Length > 4 ? decimal.Parse(fila[4]) : 0);
        gfx.DrawString(total.ToString("N2", culture), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoArticulo + anchoUM + anchoPrecioVentaFinal + anchoCantidad, yPoint, anchoTotal, alturaFila), XStringFormats.TopRight);

        sumaTotal += total;
        yPoint += alturaFila;
    }

    private static void DibujarPiePaginaVentas(XGraphics gfx, PdfPage pagina, XFont fontEncabezado, XFont fontSubtitulo,
                                             decimal sumaTotal, int margenIzquierdo, int margenDerecho,
                                             int margenInferior, ref double yPoint, int paginaActual,
                                             int totalPaginas, CultureInfo culture) {
        // Definir anchos de columnas (consistentes con los encabezados)
        var anchoCodigo = 50;
        var anchoArticulo = 200;
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
            new XRect(margenIzquierdo + anchoCodigo + anchoArticulo + anchoUM + anchoPrecioVentaFinal, yPoint, anchoCantidad, 15), XStringFormats.TopRight);

        gfx.DrawString(sumaTotal.ToString("N2", culture) + " $", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoCodigo + anchoArticulo + anchoUM + anchoPrecioVentaFinal + anchoCantidad, yPoint, anchoTotal, 15), XStringFormats.TopRight);
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
                                          string documento = "",
                                          string direccion = "",
                                          string nif = "") {
        // Crear un nuevo documento PDF
        var documentoPdf = new PdfDocument();
        documentoPdf.Info.Title = "Entrada de Mercancías";
        documentoPdf.Info.Author = "aDVanceERP";

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
                pagina = documentoPdf.AddPage();
                pagina.Size = PageSize.Letter;
                gfx = XGraphics.FromPdfPage(pagina);
                yPoint = margenSuperior;

                // Dibujar encabezado en cada página
                DibujarEncabezadoEntradaMercancias(gfx, pagina, fontTitulo, fontContenido, fontNegrita,
                    fecha, proveedor, documento, direccion, nif, 
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
                                       documentoPdf.Pages.Count, culture);
                paginaActual++;
            }
        }

        // Guardar el documento
        var nombreArchivo = $"entrada-mercancias-{fecha:yyyyMMdd}-{documento}.pdf";
        documentoPdf.Save(nombreArchivo);

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
        var anchoArticulo = 220;
        var anchoCantidad = 50;
        var anchoPrecio = 60;
        var anchoImpuesto = 50;
        var anchoDescuento = 60;
        var anchoTotal = 60;

        // Verificar y ajustar anchos si es necesario
        var anchoDisponible = pagina.Width - margenIzquierdo - margenDerecho;
        var sumaAnchos = anchoNumero + anchoArticulo + anchoCantidad + anchoPrecio +
                         anchoImpuesto + anchoDescuento + anchoTotal;

        if (sumaAnchos > anchoDisponible) {
            // Reducir el ancho del artículo proporcionalmente
            anchoArticulo -= (sumaAnchos - (int) anchoDisponible.Value);
            anchoArticulo = Math.Max(anchoArticulo, 100); // Mínimo 100 puntos
        }

        // Encabezados de la tabla de productos
        gfx.DrawString("#", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo, yPoint, anchoNumero, 15), XStringFormats.TopCenter);

        gfx.DrawString("Artículo", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero, yPoint, anchoArticulo, 15), XStringFormats.TopLeft);

        gfx.DrawString("Cantidad", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo, yPoint, anchoCantidad, 15), XStringFormats.TopRight);

        gfx.DrawString("Precio", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo + anchoCantidad, yPoint, anchoPrecio, 15), XStringFormats.TopRight);

        gfx.DrawString("Impuesto", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo + anchoCantidad + anchoPrecio, yPoint, anchoImpuesto, 15), XStringFormats.TopRight);

        gfx.DrawString("Descuento", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo + anchoCantidad + anchoPrecio + anchoImpuesto, yPoint, anchoDescuento, 15), XStringFormats.TopRight);

        gfx.DrawString("Total", fontEncabezado, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo + anchoCantidad + anchoPrecio + anchoImpuesto + anchoDescuento, yPoint, anchoTotal, 15), XStringFormats.TopRight);

        yPoint += 15;
        gfx.DrawLine(XPens.Black, margenIzquierdo, yPoint, pagina.Width - margenDerecho, yPoint);
        yPoint += 5;
    }

    private static void DibujarFilaEntrada(XGraphics gfx, XFont fontContenido, string[] fila, int numeroFila,
                                         int margenIzquierdo, ref double yPoint, int alturaFila,
                                         CultureInfo culture, ref decimal subtotal) {
        // Definir anchos de columnas (consistentes con los encabezados)
        var anchoNumero = 30;
        var anchoArticulo = 220;
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
            new XRect(margenIzquierdo + anchoNumero, yPoint, anchoArticulo, alturaFila), XStringFormats.TopLeft);

        // Cantidad
        gfx.DrawString(fila[2], fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo, yPoint, anchoCantidad, alturaFila), XStringFormats.TopRight);

        // Precio
        var precio = decimal.TryParse(fila.Length > 3 ? fila[3] : "0", NumberStyles.Any, CultureInfo.InvariantCulture, out var valorPrecio)
            ? valorPrecio
            : 0.00m;
        gfx.DrawString(precio.ToString("N2", culture), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo + anchoCantidad, yPoint, anchoPrecio, alturaFila), XStringFormats.TopRight);

        // Impuesto
        var impuesto = decimal.TryParse(fila.Length > 4 ? fila[4] : "0", NumberStyles.Any, CultureInfo.InvariantCulture, out var valorImpuesto)
            ? valorImpuesto
            : 0.00m;
        gfx.DrawString(impuesto.ToString("N2", culture), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo + anchoCantidad + anchoPrecio, yPoint, anchoImpuesto, alturaFila), XStringFormats.TopRight);

        // Descuento
        var descuento = fila.Length > 5 ? fila[5] : "0.00%";
        gfx.DrawString(descuento, fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo + anchoCantidad + anchoPrecio + anchoImpuesto, yPoint, anchoDescuento, alturaFila), XStringFormats.TopRight);

        // Total
        var total = decimal.TryParse(fila.Length > 6 ? fila[6] : "0", NumberStyles.Any, CultureInfo.InvariantCulture, out var valorTotal)
            ? valorTotal
            : precio * decimal.Parse(fila[2]);
        gfx.DrawString(total.ToString("N2", culture), fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo + anchoCantidad + anchoPrecio + anchoImpuesto + anchoDescuento, yPoint, anchoTotal, alturaFila), XStringFormats.TopRight);

        subtotal += total;
        yPoint += alturaFila;
    }

    private static void DibujarPiePaginaEntrada(XGraphics gfx, PdfPage pagina, XFont fontNegrita, XFont fontContenido,
                                              XFont fontSubtitulo, decimal subtotal, int margenIzquierdo,
                                              int margenDerecho, int margenInferior, ref double yPoint,
                                              int paginaActual, int totalPaginas, CultureInfo culture) {
        // Definir anchos de columnas (consistentes con los encabezados)
        var anchoNumero = 30;
        var anchoArticulo = 220;
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
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo + anchoCantidad + anchoPrecio + anchoImpuesto, yPoint, anchoDescuento, 15), XStringFormats.TopRight);

        gfx.DrawString("0.00 $", fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo + anchoCantidad + anchoPrecio + anchoImpuesto + anchoDescuento, yPoint, anchoTotal, 15), XStringFormats.TopRight);
        yPoint += 15;

        // Subtotal
        gfx.DrawString("Subtotal:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo + anchoCantidad + anchoPrecio + anchoImpuesto, yPoint, anchoDescuento, 15), XStringFormats.TopRight);

        gfx.DrawString(subtotal.ToString("N2", culture) + " $", fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo + anchoCantidad + anchoPrecio + anchoImpuesto + anchoDescuento, yPoint, anchoTotal, 15), XStringFormats.TopRight);
        yPoint += 15;

        // Total
        gfx.DrawString("Total:", fontNegrita, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo + anchoCantidad + anchoPrecio + anchoImpuesto, yPoint, anchoDescuento, 15), XStringFormats.TopRight);

        gfx.DrawString(subtotal.ToString("N2", culture) + " $", fontContenido, XBrushes.Black,
            new XRect(margenIzquierdo + anchoNumero + anchoArticulo + anchoCantidad + anchoPrecio + anchoImpuesto + anchoDescuento, yPoint, anchoTotal, 15), XStringFormats.TopRight);
        yPoint += 20;

        // Pie de página
        var fechaGeneracion = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        var textoPie = $"{fechaGeneracion} - Página {paginaActual} de {totalPaginas}";

        gfx.DrawString(textoPie, fontSubtitulo, XBrushes.Black,
            new XRect(margenIzquierdo, pagina.Height - margenInferior, pagina.Width - margenIzquierdo - margenDerecho, 20),
            XStringFormats.BottomRight);
    }
}