using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;

namespace aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas {
    public interface IVistaGestionCajas : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaCaja>, IGestorTablaDatos {
    }
}
