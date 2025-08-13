using aDVanceERP.Core.Modelos.BD;
using aDVanceERP.Core.Presentadores.Comun;
using aDVanceERP.Core.Repositorios.BD;
using aDVanceERP.Core.Vistas.BD;

namespace aDVanceERP.Core.Presentadores.BD {
    public class PresentadorConfServidorMySQL : PresentadorBase<VistaConfServidorMySQL, RepoConfServidorMySQL, ConfServidorMySQL> {
        public PresentadorConfServidorMySQL(VistaConfServidorMySQL vista, RepoConfServidorMySQL repositorio) : base(vista, repositorio) {
            Vista.AlmacenarConfiguracion += OnAlmacenarConfiguracion;            
        }

        private void OnAlmacenarConfiguracion(object? sender, ConfServidorMySQL e) {
            if (e == null) {
                throw new ArgumentNullException(nameof(e), "La configuración del servidor MySQL no puede ser nula.");
            }
            try {
                Repositorio.Salvar(string.Empty, e);
            } catch (Exception ex) {
                // Manejo de excepciones, por ejemplo, registrar el error o mostrar un mensaje al usuario
                throw new InvalidOperationException("Error al guardar la configuración del servidor MySQL.", ex);
            }
        }
    }
}