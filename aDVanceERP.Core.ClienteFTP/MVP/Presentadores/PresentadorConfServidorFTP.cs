using aDVanceERP.Core.ClienteFTP.MVP.Modelos;
using aDVanceERP.Core.ClienteFTP.MVP.Vistas.Plantillas;
using aDVanceERP.Core.MVP.Presentadores;

namespace aDVanceERP.Core.ClienteFTP.MVP.Presentadores {
    public class PresentadorConfServidorFTP : PresentadorBase<IVistaConfServidorFTP> {
        public PresentadorConfServidorFTP(IVistaConfServidorFTP vista) : base(vista) {
            vista.AlmacenarConfiguracion += AlmacenarConfServidorFTP;
        }

        private void AlmacenarConfServidorFTP(object? sender, EventArgs e) {
            var modelo = new ConfServidorFTP(
                Vista.Servidor,
                Vista.Usuario,
                Vista.Password);

            // Almacenamiento en settings.
            if (!Directory.Exists(@".\settings"))
                Directory.CreateDirectory(@".\settings");

            using (var fs = new FileStream(@".\settings\ftpsrv.config", FileMode.Create)) {
                using (var sw = new StreamWriter(fs)) {
                    sw.Write(modelo.ToString());
                }
            }
        }
    }
}
