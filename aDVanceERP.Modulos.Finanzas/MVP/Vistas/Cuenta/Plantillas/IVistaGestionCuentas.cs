using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;

namespace aDVanceERP.Modulos.Finanzas.MVP.Vistas.Cuenta.Plantillas {
    public interface IVistaGestionCuentas : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaCuenta>, IGestorTablaDatos { }
}
