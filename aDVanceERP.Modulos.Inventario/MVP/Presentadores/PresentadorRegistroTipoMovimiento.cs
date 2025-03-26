using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoMovimiento.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorRegistroTipoMovimiento : PresentadorRegistroBase<IVistaRegistroTipoMovimiento, TipoMovimiento, DatosTipoMovimiento, CriterioBusquedaTipoMovimiento> {
        public PresentadorRegistroTipoMovimiento(IVistaRegistroTipoMovimiento vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(TipoMovimiento objeto) {
            Vista.Nombre = objeto.Nombre;
            Vista.Efecto = objeto.Efecto.ToString();
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override async Task<TipoMovimiento?> ObtenerObjetoDesdeVista() {
            return new TipoMovimiento(
                id: _objeto?.Id ?? 0,
                nombre: Vista.Nombre,
                efecto: (EfectoMovimiento) (Enum.TryParse(typeof(EfectoMovimiento), Vista.Efecto, out var efecto) ? efecto : default(EfectoMovimiento))
                );
        }
    }
}
