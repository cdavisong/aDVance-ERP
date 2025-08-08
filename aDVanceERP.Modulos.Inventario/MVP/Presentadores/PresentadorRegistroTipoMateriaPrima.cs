using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoMateriaPrima.Plantillas;
using aDVanceERP.Modulos.Inventario.Repositorios;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores;

public class PresentadorRegistroTipoMateriaPrima : PresentadorVistaRegistroEdicionBase<IVistaRegistroTipoMateriaPrima, TipoMateriaPrima, DatosTipoMateriaPrima, CriterioBusquedaTipoMateriaPrima> {
    public PresentadorRegistroTipoMateriaPrima(IVistaRegistroTipoMateriaPrima vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(TipoMateriaPrima objeto) {
        Vista.ModoEdicion = true;
        Vista.Nombre = objeto.Nombre;
        Vista.Descripcion = objeto.Descripcion ?? string.Empty;

        Objeto = objeto;
    }

    protected override bool RegistroEdicionDatosAutorizado() {
        var nombreOk = !string.IsNullOrEmpty(Vista.Nombre);

        if (!nombreOk)
            CentroNotificaciones.Mostrar("El campo de nombre es obligatorio para el tipo de materia prima, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);

        return nombreOk;
    }

    protected override Task<TipoMateriaPrima?> ObtenerObjetoDesdeVista() {
        return Task.FromResult<TipoMateriaPrima?>(new TipoMateriaPrima(
            Objeto?.Id ?? 0,
            Vista.Nombre,
            string.IsNullOrEmpty(Vista.Descripcion) ? null : Vista.Descripcion
        ));
    }
}