using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoMovimiento.Plantillas;
using aDVanceERP.Modulos.Inventario.Repositorios;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores;

public class PresentadorRegistroTipoMovimiento : PresentadorRegistroBase<IVistaRegistroTipoMovimiento, TipoMovimiento,
    DatosTipoMovimiento, CriterioBusquedaTipoMovimiento> {
    public PresentadorRegistroTipoMovimiento(IVistaRegistroTipoMovimiento vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(TipoMovimiento objeto) {
        Vista.Nombre = objeto.Nombre;
        Vista.Efecto = objeto.Efecto.ToString();
        Vista.ModoEdicionDatos = true;

        Objeto = objeto;
    }

    protected override bool RegistroEdicionDatosAutorizado() {
        var nombreOk = !string.IsNullOrEmpty(Vista.Nombre);
        var efectoOk = !string.IsNullOrEmpty(Vista.Efecto) && !Vista.Efecto.Equals("Ninguno");

        if (!nombreOk)
            CentroNotificaciones.Mostrar("El campo de nombre es obligatorio para el tipo de movimiento, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
        if (!efectoOk)
            CentroNotificaciones.Mostrar("Debe seleccionar un efecto para el nuevo tipo de movimiento, el campo no puede estar vacío", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);

        return nombreOk && efectoOk;
    }

    protected override Task<TipoMovimiento?> ObtenerObjetoDesdeVista() {
        return Task.FromResult<TipoMovimiento?>(new TipoMovimiento(
            Objeto?.Id ?? 0,
            Vista.Nombre,
            (EfectoMovimiento)(Enum.TryParse(typeof(EfectoMovimiento), Vista.Efecto, out var efecto)
                ? efecto
                : default(EfectoMovimiento))
        ));
    }
}