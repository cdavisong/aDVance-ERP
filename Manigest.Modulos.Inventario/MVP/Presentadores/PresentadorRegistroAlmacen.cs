using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Modelos.Repositorios;
using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorRegistroAlmacen : PresentadorRegistroBase<IVistaRegistroAlmacen, Almacen, DatosAlmacen, CriterioBusquedaAlmacen> {
        public PresentadorRegistroAlmacen(IVistaRegistroAlmacen vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Almacen objeto) {
            Vista.Nombre = objeto.Nombre;
            Vista.Direccion = objeto.Direccion;
            Vista.AutorizoVenta = objeto.AutorizoVenta;
            Vista.Notas = objeto.Notas;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override Almacen ObtenerObjetoDesdeVista() {
            return new Almacen(
                idAlmacen: _objeto?.Id ?? 0,
                nombre: Vista.Nombre,
                direccion: Vista.Direccion,
                autorizoVenta: Vista.AutorizoVenta,
                notas: Vista.Notas
            );
        }
    }

}
