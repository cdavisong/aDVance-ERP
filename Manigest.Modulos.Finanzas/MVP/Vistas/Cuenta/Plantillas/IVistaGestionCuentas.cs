using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;
using Manigest.Modulos.Finanzas.MVP.Modelos;

namespace Manigest.Modulos.Finanzas.MVP.Vistas.Cuenta.Plantillas {
    public interface IVistaGestionCuentas : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaCuenta>, IGestorTablaDatos { }
}
