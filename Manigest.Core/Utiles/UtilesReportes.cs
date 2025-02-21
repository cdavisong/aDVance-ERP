namespace Manigest.Core.Utiles {
    public static class UtilesReportes {
        public static void GenerarReporteVentas(DateTime fecha, List<string[]> filas) {
            /*using (PdfWriter escritorPdf = new PdfWriter(@".\reporte.pdf")) {
                using (PdfDocument pdf = new PdfDocument(escritorPdf)) {
                    using (Document documento = new Document(pdf)) {
                        // Agregar título
                        documento.Add(new Paragraph("Reporte de Ventas")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(18)
                            .SetBold());

                        // Agregar fecha
                        documento.Add(new Paragraph($"Fecha: {fecha.ToShortDateString()}")
                            .SetTextAlignment(TextAlignment.RIGHT)
                            .SetFontSize(12));

                        // Espacio en blanco
                        documento.Add(new Paragraph("\n"));

                        // Crear una tabla con 4 columnas
                        Table tabla = new Table(new float[] { 1, 2, 1, 1 }).UseAllAvailableWidth();
                        tabla.AddHeaderCell("ID Venta").SetBold();
                        tabla.AddHeaderCell("Nombre Almacén").SetBold();
                        tabla.AddHeaderCell("Cantidad Vendida").SetBold();
                        tabla.AddHeaderCell("Total").SetBold();

                        // Datos de ejemplo
                        float sumaTotal = 0;

                        for (int i = 0; i < filas.Count(); i++) {
                            var tupla = filas.ElementAt(i);

                            tabla.AddCell(i.ToString());
                            tabla.AddCell(tupla[0]);
                            tabla.AddCell(tupla[1]);
                            float total = float.Parse(tupla[2]);
                            tabla.AddCell($"${total}");
                            sumaTotal += total;
                        }

                        // Agregar fila con la suma total
                        tabla.AddCell(new Cell(1, 3).Add(new Paragraph("Total").SetTextAlignment(TextAlignment.LEFT)));
                        tabla.AddCell(new Cell().Add(new Paragraph($"${sumaTotal}").SetTextAlignment(TextAlignment.LEFT)));

                        // Agregar tabla al documento
                        documento.Add(tabla);
                    }
                }
            }

            // Mostrar el documento PDF al usuario
            Process.Start(new ProcessStartInfo {
                FileName = @".\reporte.pdf",
                UseShellExecute = true
            });*/
        }
    }
}
