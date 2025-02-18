using Manigest.Core.Utiles;
using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Ventas.MVP.Vistas.DetallePagoTransferencia.Plantillas;
using Manigest.Modulos.Ventas.Properties;

using QRCoder;

namespace Manigest.Modulos.Ventas.MVP.Vistas.DetallePagoTransferencia {
    public partial class VistaRegistroDetallePagoTransferencia : Form, IVistaRegistroDetallePagoTransferencia {
        private bool _modoEdicion;
        private string _numeroTarjeta;

        public VistaRegistroDetallePagoTransferencia() {
            InitializeComponent();
            Inicializar();
        }

        public bool Habilitada {
            get => Enabled;
            set => Enabled = value;
        }

        public Point Coordenadas {
            get => Location;
            set => Location = value;
        }

        public Size Dimensiones {
            get => Size;
            set => Size = value;
        }

        public string Alias {
            get => fieldAlias.Text;
            set => fieldAlias.Text = value;
        }

        public string NumeroConfirmacion {
            get => fieldNumeroMovilConfirmacion.Text;
            set => fieldNumeroMovilConfirmacion.Text = value;
        }

        public string NumeroTransaccion {
            get => fieldNumeroTransaccion.Text;
            set => fieldNumeroTransaccion.Text = value;
        }

        public bool RecordarNumeroConfirmacion {
            get => fieldRecordarNumeroConfirmacion.Checked;
            set => fieldRecordarNumeroConfirmacion.Checked = value;
        }

        public Image? QR {
            get => fieldCodigoQr.BackgroundImage;
            set => fieldCodigoQr.BackgroundImage = value;
        }

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnRegistrar.Text = value ? "Actualizar transferencia" : "Confirmar transferencia";
                _modoEdicion = value;
            }
        }

        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        public void Inicializar() {
            separador1.Visible = false;
            layoutQrDatos.Visible = false;

            // Eventos            
            btnCerrar.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
            fieldAlias.SelectedIndexChanged += delegate (object? sender, EventArgs args) {
                var idCuenta = UtilesCuenta.ObtenerIdCuenta(Alias);
                var idPropietario = UtilesCuenta.ObtenerIdPropietario(idCuenta);                
                var movilPropietario = UtilesTelefonoContacto.ObtenerTelefonoContacto(idPropietario, true);
                var numeroConfirmacion = string.IsNullOrEmpty(UtilesCuenta.NumeroConfirmacion)
                    ? movilPropietario
                    : UtilesCuenta.NumeroConfirmacion;

                _numeroTarjeta = UtilesCuenta.ObtenerNumeroTarjeta(idCuenta) ?? string.Empty;
                NumeroConfirmacion = numeroConfirmacion ?? string.Empty;
                
                fieldRecordarNumeroConfirmacion.Checked = NumeroConfirmacion.Equals(UtilesCuenta.NumeroConfirmacion);
            };
            fieldNumeroMovilConfirmacion.TextChanged += delegate (object? sender, EventArgs args) {
                if (NumeroConfirmacion.Length == 8 && !string.IsNullOrEmpty(Alias))
                    CargarCodigoQR($"{Alias},{_numeroTarjeta.Replace(" ", "")},{NumeroConfirmacion}");
                else {
                    separador1.Visible = false;
                    layoutQrDatos.Visible = false;
                    fieldRecordarNumeroConfirmacion.Checked = false;
                }
            };
            fieldNumeroTransaccion.TextChanged += delegate (object? sender, EventArgs args) {
                btnRegistrar.Enabled = NumeroTransaccion.Length == 13;
            };
            fieldRecordarNumeroConfirmacion.CheckedChanged += delegate (object? sender, EventArgs args) {
                UtilesCuenta.NumeroConfirmacion = !RecordarNumeroConfirmacion
                    ? string.Empty
                    : NumeroConfirmacion;                
            };
            btnRegistrar.Click += delegate (object? sender, EventArgs args) {
                if (ModoEdicionDatos)
                    EditarDatos?.Invoke(sender, args);
                else
                    Salir?.Invoke(sender, args);
            };
            btnSalir.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
        }

        public void CargarAliasTarjetas(string[] aliasTarjetas) {
            fieldAlias.Items.AddRange(aliasTarjetas);
            fieldAlias.SelectedIndex = -1;
        }

        public void CargarCodigoQR(string datos) {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator()) {
                var datosSplit = datos.Split(',');
                var datosTransferencia = $"TRANSFERMOVIL_ETECSA,TRANSFERENCIA,{datosSplit[1]},{datosSplit[2]},";

                fieldAliasQR.Text = datosSplit[0];
                fieldTarjetaQR.Text = datosSplit[1].AgregarEspacioCadaXCaracteres(4);
                fieldNumeroMovilConfirmacionQR.Text = $"+53 {datosSplit[2]}";

                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(datosTransferencia, QRCodeGenerator.ECCLevel.Q)) {
                    using (QRCode qrCode = new QRCode(qrCodeData)) {
                        var qrCodeImage = qrCode.GetGraphic(3, Color.FromArgb(40, 37, 35), Color.FromArgb(248, 244, 242), Resources.images2, 20);

                        QR = qrCodeImage;
                        separador1.Visible = true;
                        layoutQrDatos.Visible = true;
                    }
                }
            }
        }

        public void Mostrar() {
            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            Alias = string.Empty;
            fieldAlias.SelectedIndex = -1;
            NumeroConfirmacion = string.Empty;
            NumeroTransaccion = string.Empty;
            RecordarNumeroConfirmacion = false;
            separador1.Visible = false;
            layoutQrDatos.Visible = false;
            ModoEdicionDatos = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
