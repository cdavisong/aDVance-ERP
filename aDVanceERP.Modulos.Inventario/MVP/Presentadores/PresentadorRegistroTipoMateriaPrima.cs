using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoMateriaPrima.Plantillas;
using aDVanceERP.Modulos.Inventario.Repositorios;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores;

public class PresentadorRegistroTipoMateriaPrima : PresentadorRegistroBase<IVistaRegistroTipoMateriaPrima, TipoMateriaPrima, DatosTipoMateriaPrima, CriterioBusquedaTipoMateriaPrima> {
    public PresentadorRegistroTipoMateriaPrima(IVistaRegistroTipoMateriaPrima vista) : base(vista) { }

    public override void PopularVistaDesdeEntidad(TipoMateriaPrima objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.Nombre = objeto.Nombre;
        Vista.Descripcion = objeto.Descripcion ?? string.Empty;

        Entidad = objeto;
    }

    protected override bool DatosEntidadCorrectos() {
        var nombreOk = !string.IsNullOrEmpty(Vista.Nombre);

        if (!nombreOk)
            CentroNotificaciones.Mostrar("El campo de nombre es obligatorio para el tipo de materia prima, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);

        return nombreOk;
    }

    protected override Task<TipoMateriaPrima?> ObtenerEntidadDesdeVista() {
        return Task.FromResult<TipoMateriaPrima?>(new TipoMateriaPrima(
            Entidad?.Id ?? 0,
            Vista.Nombre,
            string.IsNullOrEmpty(Vista.Descripcion) ? null : Vista.Descripcion
        ));
    }
}