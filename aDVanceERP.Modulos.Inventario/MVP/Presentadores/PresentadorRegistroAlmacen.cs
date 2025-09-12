using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.Presentadores.Comun;
using aDVanceERP.Core.Repositorios.Modulos.Inventario;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores;

public class PresentadorRegistroAlmacen : PresentadorVistaRegistro<IVistaRegistroAlmacen, Almacen, RepoAlmacen, FiltroBusquedaAlmacen> {
    public PresentadorRegistroAlmacen(IVistaRegistroAlmacen vista) : base(vista) { }

    public override void PopularVistaDesdeEntidad(Almacen entidad) {
        Vista.ModoEdicionDatos = true;
        Vista.Nombre = entidad.Nombre ?? string.Empty;
        Vista.Direccion = entidad.Direccion ?? string.Empty;
        Vista.AutorizoVenta = true;
        Vista.Descripcion = entidad.Descripcion ?? string.Empty;
        Vista.ModoEdicionDatos = true;

        _entidad = entidad;
    }

    protected override bool EntidadCorrecta() {
        var nombreOk = !string.IsNullOrEmpty(Vista.Nombre);

        if (!nombreOk)
            CentroNotificaciones.Mostrar("El campo de nombre es obligatorio para el almacén, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);

        return nombreOk;
    }

    protected override Almacen? ObtenerEntidadDesdeVista() {
        if (Vista == null) {
            CentroNotificaciones.Mostrar("La vista no está inicializada.", Core.Mensajes.MVP.Modelos.TipoNotificacion.Error);
            return null;
        }

        //TODO: Trabajar en los campos que faltan para adicionar en el almacen
        return new Almacen(
            Vista.ModoEdicionDatos && Entidad != null ? Entidad.Id : 0,
            Vista.Nombre ?? string.Empty,
            Vista.Descripcion ?? string.Empty,
            Vista.Direccion ?? string.Empty,
            0, 
            TipoAlmacen.Principal,
            true,
            null
        );
    }
}