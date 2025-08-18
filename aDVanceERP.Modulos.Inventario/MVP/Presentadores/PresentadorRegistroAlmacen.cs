using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;
using aDVanceERP.Modulos.Inventario.Repositorios;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores;

public class PresentadorRegistroAlmacen : PresentadorRegistroBase<IVistaRegistroAlmacen, Almacen, RepoAlmacen, FiltroBusquedaAlmacen> {
    public PresentadorRegistroAlmacen(IVistaRegistroAlmacen vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(Almacen objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.Nombre = objeto.Nombre ?? string.Empty;
        Vista.Direccion = objeto.Direccion ?? string.Empty;
        Vista.AutorizoVenta = objeto.AutorizoVenta;
        Vista.Notas = objeto.Notas ?? string.Empty;
        Vista.ModoEdicionDatos = true;

        Entidad = objeto;
    }

    protected override bool RegistroEdicionDatosAutorizado() {
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

        return new Almacen(
            Vista.ModoEdicionDatos && Entidad != null ? Entidad.Id : 0,
            Vista.Nombre ?? string.Empty,
            Vista.Direccion ?? string.Empty,
            Vista.AutorizoVenta,
            Vista.Notas ?? string.Empty
        );
    }
}