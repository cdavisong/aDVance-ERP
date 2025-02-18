using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Modelos.Repositorios;
using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;
using Manigest.Modulos.Inventario.MVP.Vistas.Almacen;

namespace Manigest.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorGestionAlmacenes : PresentadorGestionBase<PresentadorTuplaAlmacen, IVistaGestionAlmacenes, IVistaTuplaAlmacen, Almacen, DatosAlmacen, CriterioBusquedaAlmacen> {
        public PresentadorGestionAlmacenes(IVistaGestionAlmacenes vista) : base(vista) {
        }

        protected override PresentadorTuplaAlmacen ObtenerValoresTupla(Almacen objeto) {
            var presentadorTupla = new PresentadorTuplaAlmacen(new VistaTuplaAlmacen(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.Nombre = objeto.Nombre;
            presentadorTupla.Vista.Direccion = objeto.Direccion;
            presentadorTupla.Vista.Notas = objeto.Notas;

            return presentadorTupla;
        }
    }

}
