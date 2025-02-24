using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Contacto;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionContactos _gestionContactos;

        private void InicializarVistaGestionContactos() {
            _gestionContactos = new PresentadorGestionContactos(new VistaGestionContactos());
            _gestionContactos.EditarObjeto += MostrarVistaEdicionContacto;
            _gestionContactos.Vista.RegistrarDatos += MostrarVistaRegistroContacto;
            _gestionContactos.Vista.CargarCriteriosBusqueda(UtilesBusquedaContacto.CriterioBusquedaContacto);

            Vista.Vistas.Registrar("vistaGestionContactos", _gestionContactos.Vista);
        }

        private void MostrarVistaGestionContactos(object? sender, EventArgs e) {
            _gestionContactos.Vista.Mostrar();
            _gestionContactos.Vista.Restaurar();
            _gestionContactos.RefrescarListaObjetos();
        }
    }
}
