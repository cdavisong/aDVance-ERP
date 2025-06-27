using aDVanceERP.Core.ClienteMySQL.MVP.Modelos;
using aDVanceERP.Core.ClienteMySQL.MVP.Vistas.Plantillas;
using aDVanceERP.Core.MVP.Presentadores;

namespace aDVanceERP.Core.ClienteMySQL.MVP.Presentadores; 

public class PresentadorConfServidorMySQL : PresentadorBase<IVistaConfServidorMySQL> {
    public PresentadorConfServidorMySQL(IVistaConfServidorMySQL vista) : base(vista) {
        Vista.AlmacenarConfiguracion += AlmacenarConfServidorMySQL;
    }

    private void AlmacenarConfServidorMySQL(object? sender, EventArgs e) {
        var modelo = new ConfServidorMySQL(
            Vista.Servidor,
            Vista.BaseDatos,
            Vista.Usuario,
            Vista.Password);

        // Almacenamiento en settings.
        if (!Directory.Exists(@".\settings"))
            Directory.CreateDirectory(@".\settings");

        using (var fs = new FileStream(@".\settings\mysqlsrv.config", FileMode.Create)) {
            using (var sw = new StreamWriter(fs)) {
                sw.Write(modelo.ToString());
            }
        }
    }
    public override void Dispose() {
        //...
    }
}