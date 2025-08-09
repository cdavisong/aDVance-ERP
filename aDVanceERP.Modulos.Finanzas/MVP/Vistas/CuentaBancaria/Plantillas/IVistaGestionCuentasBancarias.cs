using aDVanceERP.Core.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;

namespace aDVanceERP.Modulos.Finanzas.MVP.Vistas.CuentaBancaria.Plantillas;

public interface IVistaGestionCuentasBancarias : IVistaContenedor, IGestorDatos,
    IBarraBusquedaEntidadesBd<CriterioBusquedaCuentaBancaria>, ITablaResultadosBusqueda { }