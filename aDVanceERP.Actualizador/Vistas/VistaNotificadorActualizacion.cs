using aDVanceERP.Actualizador.Interfaces;
using aDVanceERP.Actualizador.Modelos;

namespace aDVanceERP.Actualizador.Vistas {
    public partial class VistaNotificadorActualizacion : Form {
        private readonly IServicioActualizacion _updateService;
        private readonly InfoActualizacion _updateInfo;

        public VistaNotificadorActualizacion(IServicioActualizacion updateService, InfoActualizacion updateInfo) {
            InitializeComponent();

            _updateService = updateService;
            _updateInfo = updateInfo;

            // Eventos de la vista
            Load += OnVistaCargada;
            btnActualizar.Click += async (s, e) => {
                btnActualizar.Enabled = false;
                await Actualizar();
            };
        }

        private void OnVistaCargada(object? sender, EventArgs e) {
            // Configurar el texto HTML con la información de la actualización
            var htmlContent = GenerateUpdateHtmlContent();

            fieldTexto.Text = htmlContent;
        }

        private string GenerateUpdateHtmlContent() {
            return $@"
        <!DOCTYPE html>
        <html lang='es'>
        <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <style>
            body {{
                font-family: Segoe UI, sans-serif;
                text-align: center;
                padding: 10px;
                margin: 0;
                line-height: 1.4;
            }}
            .header {{
                color: #FFFFFF;
                padding: 5px 0;
                border-radius: 8px;
                margin-bottom: 15px;
            }}
            .logo {{
                font-family: Segoe UI, sans-serif;
                font-size: 24px;
                line-height: 1.2;
            }}
            .dv {{
                color: Gray;
                font-weight: bold;
            }}
            .advance {{
                color: #333333;
                font-weight: bold;
            }}
            .erp {{
                background-color: Firebrick;
                color: white;
                font-weight: bold;
                padding: 2px 4px;
            }}
            .version {{
                color: Gray;
                font-size: 10px;
                vertical-align: super;
            }}
            .welcome-text {{
                margin-top: 15px;
                font-size: 24px;
                line-height: 1.3;
            }}
            .description {{
                margin-top: 10px;
                font-size: 16px;
                line-height: 1.4;
            }}
            .info-section {{
                margin-top: 15px;
                background: #f8f9fa;
                padding: 12px;
                border-radius: 8px;
                text-align: left;
            }}
            .info-table {{
                width: 100%;
                border-collapse: collapse;
                font-family: Segoe UI;
                font-size: 14px;
            }}
            .info-table td {{
                padding: 6px 8px;
                vertical-align: top;
            }}
            .info-label {{
                font-weight: bold;
                color: #333333;
                width: 140px;
            }}
            .info-value {{
                color: Gray;
            }}
            .release-notes {{
                margin-top: 15px;
                text-align: left;
            }}
            .notes-title {{
                font-size: 18px;
                font-weight: bold;
                color: #333333;
                margin-bottom: 8px;
            }}
            .notes-content {{
                background: #e8f4fd;
                padding: 12px;
                border-radius: 8px;
                border-left: 4px solid Firebrick;
                color: #333333;
                font-size: 14px;
                line-height: 1.5;
            }}
            .trust-section {{
                margin-top: 25px;
                padding: 15px;
            }}
            .trust-title {{
                font-size: 18px;
                font-weight: bold;
                margin-bottom: 10px;
                color: #333333;
            }}
        </style>
        </head>
        <body>
            <div class='header'>
                <div class='logo'>
                    <span class='advance'>a</span><span class='dv'>DV</span><span class='advance'>ance</span> <span class='erp'>ERP</span> <span class='version'>v{_updateInfo.UltimaVersion}</span>
                </div>
            </div>
            
            <div class='welcome-text'>
                <p>¡Nueva actualización disponible!</p>
                <p>Mantén tu sistema al día con las últimas mejoras.</p>
            </div>
            
            <div class='description'>
                <div class='info-section'>
                    <table class='info-table'>
                        <tr>
                            <td class='info-label'>Versión Actual:</td>
                            <td class='info-value'>{Application.ProductVersion}</td>
                        </tr>
                        <tr>
                            <td class='info-label'>Nueva Versión:</td>
                            <td class='info-value' style='color: Firebrick; font-weight: bold;'>v{_updateInfo.UltimaVersion}</td>
                        </tr>
                        <tr>
                            <td class='info-label'>Fecha:</td>
                            <td class='info-value'>{_updateInfo.FechaLanzamiento:dd/MM/yyyy HH:mm}</td>
                        </tr>
                        <tr>
                            <td class='info-label'>Tamaño:</td>
                            <td class='info-value'>{FormatFileSize(_updateInfo.TamanoArchivo)}</td>
                        </tr>
                    </table>
                </div>
            </div>
            
            <div class='release-notes'>
                <div class='notes-title'>Notas de la Versión:</div>
                <div class='notes-content'>
                    {FormatReleaseNotes(_updateInfo.NotasVersion)}
                </div>
            </div>
            
            <div class='trust-section'>
                    <div class='trust-title'>Gracias por confiar en nosotros</div>
                    <p style='color: Gray; font-style: italic;'>Continuamos trabajando para mejorar tu experiencia.</p>
            </div>
        </body>
        </html>";
        }

        private void ShowNoUpdatesNotification() {
            fieldTexto.Text = @"
                <div style='font-family: Segoe UI, sans-serif; text-align: center; padding: 10px;'>
                    <div style='color: #FFFFFF; padding: 20px; border-radius: 8px;'>
                        <div style='font-family: Segoe UI, sans-serif; font-size: 24px;'>
                            <span style='color: #333333; font-weight: bold;'>a</span>
                            <span style='color: Gray; font-weight: bold;'>DV</span>
                            <span style='color: #333333; font-weight: bold;'>ance</span>
                            <span style='background-color: Firebrick; color: white; font-weight: bold; padding: 2px;'> ERP</span>
                            <span style='color: Gray; font-size: 10px;'> v" + Application.ProductVersion + @"</span>
                        </div>
                    </div>
                
                    <div style='margin-top: 30px; font-size: 24px; color: #27ae60;'>
                        <p>¡Tu aplicación está actualizada!</p>
                    </div>
                
                    <div style='margin-top: 20px; font-size: 16px; color: #333333;'>
                        <p>No hay actualizaciones disponibles en este momento.</p>
                        <p>Estás utilizando la versión más reciente de aDVance ERP.</p>
                    </div>
                
                    <div style='margin-top: 40px; padding: 20px;'>
                        <div style='font-size: 18px; font-weight: bold; margin-bottom: 15px; color: #333333;'>
                            Gracias por confiar en nosotros
                        </div>
                        <p style='color: Gray; font-style: italic;'>
                            Continuamos trabajando para mejorar tu experiencia.
                        </p>
                    </div>
                </div>";
        }

        private void ShowErrorNotification(string errorMessage) {
            fieldTexto.Text = @"
                <div style='font-family: Segoe UI, sans-serif; text-align: center; padding: 10px;'>
                    <div style='color: #FFFFFF; padding: 20px; border-radius: 8px;'>
                        <div style='font-family: Segoe UI, sans-serif; font-size: 24px;'>
                            <span style='color: #333333; font-weight: bold;'>a</span>
                            <span style='color: Gray; font-weight: bold;'>DV</span>
                            <span style='color: #333333; font-weight: bold;'>ance</span>
                            <span style='background-color: Firebrick; color: white; font-weight: bold; padding: 2px;'> ERP</span>
                        </div>
                    </div>
                
                    <div style='margin-top: 30px; font-size: 24px; color: #e74c3c;'>
                        <p>Error de conexión</p>
                    </div>
                
                    <div style='margin-top: 20px; font-size: 16px; color: #333333;'>
                        <p>No se pudo verificar las actualizaciones.</p>
                        <p style='color: Gray; font-size: 14px;'>" + errorMessage + @"</p>
                    </div>
                
                    <div style='margin-top: 30px; font-size: 14px; color: #7f8c8d;'>
                        <p>Por favor, verifica tu conexión a internet e intenta nuevamente.</p>
                    </div>
                </div>";
        }


        private string FormatReleaseNotes(string releaseNotes) {
            if (string.IsNullOrEmpty(releaseNotes))
                return "<div style='color: Gray; font-style: italic;'>No hay notas de versión disponibles para esta actualización.</div>";

            // Limpiar y formatear las notas de versión
            string formattedNotes = releaseNotes

                // Eliminar caracteres formato
                .Replace("**", string.Empty)
                .Replace("###", string.Empty)

                // Convertir saltos de línea
                .Replace("\r\n", "<br>")
                .Replace("\n", "<br>")
                .Replace("\r", "<br>")

                // Convertir viñetas
                .Replace("•", "•")

                // Manejar enlaces
                .Replace("Full Changelog:", "<br><br><strong>Full Changelog:</strong>");

            return $@"
        <div style='line-height: 1.5; font-size: 13px; color: #2c3e50;'>
            {formattedNotes}
        </div>";
        }

        private string FormatFileSize(long bytes) {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            double size = bytes;

            while (size >= 1024 && order < sizes.Length - 1) {
                order++;
                size = size / 1024;
            }

            return $"{size:0.##} {sizes[order]}";
        }

        private async Task Actualizar() {
            try {
                // Ocultar texto de actualizacion
                fieldTexto.Visible = false;

                // Mostrar progreso de descarga
                var progressForm = new VistaProgresoDescarga();
                progressForm.Dock = DockStyle.Fill;
                progressForm.TopLevel = false;

                panelCentral.Controls.Add(progressForm);

                progressForm.BringToFront();
                progressForm.Show();

                var progress = new Progress<double>(p => {
                    progressForm.UpdateProgress(p);
                });

                var success = await _updateService.DescargarActualizacion(_updateInfo, progress);

                if (success) {
                    progressForm.UpdateStatus("Aplicando actualización...");
                    await Task.Delay(1000);

                    panelCentral.Controls.Remove(progressForm);
                    progressForm.Dispose();

                    _updateService.AplicarActualizacion(_updateInfo.UrlDescarga);
                }
            } catch (Exception ex) {
                MessageBox.Show($"Error durante la actualización: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
