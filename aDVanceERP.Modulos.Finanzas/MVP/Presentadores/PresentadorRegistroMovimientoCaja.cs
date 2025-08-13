using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores;

public class PresentadorRegistroMovimientoCaja : PresentadorRegistroBase<IVIstaRegistroMovimientoCaja, MovimientoCaja, DatosMovimientoCaja, FiltroBusquedaMovimientoCaja> {
    public PresentadorRegistroMovimientoCaja(IVIstaRegistroMovimientoCaja vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(MovimientoCaja objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.Fecha = objeto.Fecha;
        Vista.Monto = objeto.Monto;
        Vista.TipoMovimiento = objeto.Tipo.ToString();
        Vista.Concepto = objeto.Concepto ?? string.Empty;
        Vista.Observaciones = objeto.Observaciones;

        Entidad = objeto;
    }

    protected override MovimientoCaja? ObtenerEntidadDesdeVista() {
        return new MovimientoCaja(
            Entidad?.Id ?? 0,
            UtilesCaja.ObtenerIdCajaActiva(),
            Vista.Fecha,
            Vista.Monto,
            Enum.Parse<TipoMovimientoCaja>(Vista.TipoMovimiento),
            Vista.Concepto,
            0,
            UtilesCuentaUsuario.UsuarioAutenticado?.Id ?? 0,
            Vista.Observaciones
        );
    }
}