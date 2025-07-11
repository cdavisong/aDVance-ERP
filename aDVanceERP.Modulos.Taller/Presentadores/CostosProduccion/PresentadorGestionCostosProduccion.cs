using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;

using aDVanceERP.Modulos.Taller.Interfaces;
using aDVanceERP.Modulos.Taller.Modelos;
using aDVanceERP.Modulos.Taller.Repositorios;
using aDVanceERP.Modulos.Taller.Vistas.CostosProduccion;

namespace aDVanceERP.Modulos.Taller.Presentadores.CostosProduccion {
    public class PresentadorGestionCostosProduccion : PresentadorGestionBase<PresentadorTuplaCostoProduccion, IVistaGestionCostosProduccion,
        IVistaTuplaCostoProduccion, CostoDirecto, RepoCostoDirecto, FiltroBusquedaCostoProduccion> {
        public PresentadorGestionCostosProduccion(IVistaGestionCostosProduccion vista) : base(vista) {
        }

        protected override PresentadorTuplaCostoProduccion ObtenerValoresTupla(CostoDirecto objeto) {
            var presentadorTupla = new PresentadorTuplaCostoProduccion(new VistaTuplaCostoDirecto(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.FechaRegistro = objeto.FechaRegistro.ToString("yyyy-MM-dd");
            presentadorTupla.Vista.NombreProducto = UtilesProducto.ObtenerNombreProducto(objeto.IdProducto).Result ?? string.Empty;
            presentadorTupla.Vista.CostoMateriaPrima = objeto.CostoMateriaPrima;
            presentadorTupla.Vista.CostoManoObra = objeto.CostoManoObra;
            presentadorTupla.Vista.CostoIndirectoFabricacion = objeto.OtrosCostos;
            presentadorTupla.Vista.CostoTotal = objeto.CostoTotal;
            presentadorTupla.Vista.Observaciones = objeto.Observaciones ?? "No hay observaciones";

            return presentadorTupla;
        }
    }
}