using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Vistas.Movimiento;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionMovimientos _gestionMovimientos;

        private void InicializarVistaGestionMovimientos() {
            _gestionMovimientos = new PresentadorGestionMovimientos(new VistaGestionMovimientos());            
            _gestionMovimientos.EditarObjeto += MostrarVistaEdicionMovimiento;
            _gestionMovimientos.Vista.RegistrarDatos += MostrarVistaRegistroMovimiento;
            _gestionMovimientos.Vista.CargarCriteriosBusqueda(UtilesBusquedaMovimiento.CriterioBusquedaMovimiento);

            Vista.Vistas.Registrar("vistaGestionMovimientos", _gestionMovimientos.Vista);
        }

        private void MostrarVistaGestionMovimientos(object? sender, EventArgs e) {
            _gestionMovimientos.Vista.Mostrar();
            _gestionMovimientos.Vista.Restaurar();
            _gestionMovimientos.RefrescarListaObjetos();
        }
    }
}
