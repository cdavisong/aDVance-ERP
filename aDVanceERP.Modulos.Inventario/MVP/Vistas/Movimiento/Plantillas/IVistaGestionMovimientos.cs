using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;

public interface IVistaGestionMovimientos : IVistaContenedor, IGestorEntidades, IBuscadorEntidades<FiltroBusquedaMovimiento>,
    INavegadorTuplasEntidades { }