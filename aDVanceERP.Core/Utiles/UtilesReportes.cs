using PdfSharp.Drawing;
using PdfSharp.Pdf;

using System.Diagnostics;
using System.Globalization;

namespace aDVanceERP.Core.Utiles {
    public static class UtilesReportes {
        public static void GenerarReporteVentas(DateTime fecha, List<string[]> filas) {
            // Crear un nuevo documento PDF
            PdfDocument documento = new PdfDocument();
            documento.Info.Title = "Reporte de Ventas";
            documento.Options.NoCompression = false;
            documento.Options.CompressContentStreams = true;
            documento.Options.ColorMode = PdfColorMode.Rgb;

            // Agregar una página al documento
            PdfPage pagina = documento.AddPage();
            pagina.Size = PdfSharp.PageSize.Letter;

            // Configurar márgenes (en puntos, 1 punto = 1/72 pulgadas)
            const int margenIzquierdo = 50;
            const int margenDerecho = 50;
            const int margenSuperior = 50;
            const int margenInferior = 50;

            XGraphics gfx = XGraphics.FromPdfPage(pagina);
            XFont fontTitulo = new XFont("Verdana", 18, XFontStyleEx.Bold);
            XFont fontSubtitulo = new XFont("Verdana", 12, XFontStyleEx.Regular);
            XFont fontContenido = new XFont("Verdana", 10, XFontStyleEx.Regular);

            // Agregar título
            gfx.DrawString("Reporte de Ventas", fontTitulo, XBrushes.Black, new XRect(margenIzquierdo, margenSuperior, pagina.Width - margenIzquierdo - margenDerecho, pagina.Height), XStringFormats.TopCenter);

            // Agregar fecha
            gfx.DrawString($"Fecha: {fecha.ToShortDateString()}", fontSubtitulo, XBrushes.Black, new XRect(margenIzquierdo, margenSuperior + 30, pagina.Width - margenIzquierdo - margenDerecho, pagina.Height), XStringFormats.TopRight);

            // Crear espacio en blanco
            int yPoint = margenSuperior + 50;
            gfx.DrawString(" ", fontContenido, XBrushes.Black, new XRect(margenIzquierdo, yPoint, pagina.Width - margenIzquierdo - margenDerecho, pagina.Height), XStringFormats.TopLeft);

            // Crear encabezados de la tabla
            yPoint += 20;
            gfx.DrawString("ID Venta", fontContenido, XBrushes.Black, new XRect(margenIzquierdo, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
            gfx.DrawString("Nombre Almacén", fontContenido, XBrushes.Black, new XRect(margenIzquierdo + 100, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
            gfx.DrawString("Cantidad Vendida", fontContenido, XBrushes.Black, new XRect(margenIzquierdo + 200, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
            gfx.DrawString("Total", fontContenido, XBrushes.Black, new XRect(margenIzquierdo + 300, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);

            // Agregar filas de datos
            yPoint += 20;
            decimal sumaTotal = 0;

            for (int i = 0; i < filas.Count; i++) {
                var tupla = filas[i];

                gfx.DrawString((i + 1).ToString(), fontContenido, XBrushes.Black, new XRect(margenIzquierdo, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
                gfx.DrawString(tupla[0], fontContenido, XBrushes.Black, new XRect(margenIzquierdo + 100, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
                gfx.DrawString(tupla[1], fontContenido, XBrushes.Black, new XRect(margenIzquierdo + 200, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
                decimal total = decimal.TryParse(tupla[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var valorTotal) ? valorTotal : 0.00m;
                gfx.DrawString($"${total}", fontContenido, XBrushes.Black, new XRect(margenIzquierdo + 300, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);

                sumaTotal += total;
                yPoint += 20;
            }

            // Agregar fila con la suma total
            gfx.DrawString("Total", fontContenido, XBrushes.Black, new XRect(margenIzquierdo + 100, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
            gfx.DrawString($"${sumaTotal}", fontContenido, XBrushes.Black, new XRect(margenIzquierdo + 300, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);

            // Guardar el documento en el archivo
            documento.Save(@".\reporte.pdf");

            // Mostrar el documento PDF al usuario
            Process.Start(new ProcessStartInfo {
                FileName = @".\reporte.pdf",
                UseShellExecute = true
            });
        }
    }
}
