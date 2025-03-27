using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorRegistroAlmacen : PresentadorRegistroBase<IVistaRegistroAlmacen, Almacen, DatosAlmacen, CriterioBusquedaAlmacen> {
        public PresentadorRegistroAlmacen(IVistaRegistroAlmacen vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Almacen objeto) {
            Vista.ModoEdicionDatos = true;
            Vista.Nombre = objeto.Nombre ?? string.Empty;
            Vista.Direccion = objeto.Direccion ?? string.Empty;
            Vista.AutorizoVenta = objeto.AutorizoVenta;
            Vista.Notas = objeto.Notas ?? string.Empty;
            Vista.ModoEdicionDatos = true;

            Objeto = objeto;
        }

        protected override async Task<Almacen?> ObtenerObjetoDesdeVista() {
            return new Almacen(
                idAlmacen: Objeto?.Id ?? 0,
                nombre: Vista.Nombre,
                direccion: Vista.Direccion,
                autorizoVenta: Vista.AutorizoVenta,
                notas: Vista.Notas
            );
        }
    }

}
