using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Taller.Modelos;

namespace aDVanceERP.Modulos.Taller.Interfaces {
    public interface IVistaGestionCostosProduccion : IVistaContenedor, IGestorDatos, IBuscadorDatos<FiltroBusquedaCostoProduccion>, IGestorTablaDatos {
    }
}