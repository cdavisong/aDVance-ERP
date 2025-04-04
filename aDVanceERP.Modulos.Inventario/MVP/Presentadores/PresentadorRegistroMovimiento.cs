using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores; 

public class PresentadorRegistroMovimiento : PresentadorRegistroBase<IVistaRegistroMovimiento, Movimiento,
    DatosMovimiento, CriterioBusquedaMovimiento> {
    private Movimiento? _movimiento;

    public PresentadorRegistroMovimiento(IVistaRegistroMovimiento vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(Movimiento objeto) {
        Vista.NombreArticulo = UtilesArticulo.ObtenerNombreArticulo(objeto.IdArticulo).Result ?? string.Empty;
        Vista.NombreAlmacenOrigen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenOrigen) ?? string.Empty;
        Vista.NombreAlmacenDestino = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenDestino) ?? string.Empty;
        Vista.Fecha = objeto.Fecha;
        Vista.CantidadMovida = objeto.CantidadMovida;
        Vista.TipoMovimiento = UtilesMovimiento.ObtenerNombreTipoMovimiento(objeto.IdTipoMovimiento) ?? string.Empty;
        Vista.ModoEdicionDatos = true;

        Objeto = objeto;
    }

    protected override async Task<Movimiento?> ObtenerObjetoDesdeVista() {
        _movimiento = new Movimiento(
            Objeto?.Id ?? 0,
            await UtilesArticulo.ObtenerIdArticulo(Vista.NombreArticulo),
            await UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacenOrigen),
            await UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacenDestino),
            Vista.Fecha,
            Vista.CantidadMovida,
            UtilesMovimiento.ObtenerIdTipoMovimiento(Vista.TipoMovimiento)
        );

        return _movimiento;
    }

    protected override void RegistroAuxiliar() {
        if (_movimiento != null)
            UtilesMovimiento.ModificarStockArticuloAlmacen(_movimiento.IdArticulo, _movimiento.IdAlmacenOrigen,
                _movimiento.IdAlmacenDestino, _movimiento.CantidadMovida);
    }
}