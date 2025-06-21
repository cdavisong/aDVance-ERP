using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;
using aDVanceERP.Modulos.Inventario.Repositorios;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores;

public class PresentadorRegistroAlmacen : PresentadorRegistroBase<IVistaRegistroAlmacen, Almacen, DatosAlmacen,
    CriterioBusquedaAlmacen> {
    public PresentadorRegistroAlmacen(IVistaRegistroAlmacen vista) : base(vista) { }

    public override void PopularVistaDesdeEntidad(Almacen objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.Nombre = objeto.Nombre ?? string.Empty;
        Vista.Direccion = objeto.Direccion ?? string.Empty;
        Vista.AutorizoVenta = objeto.AutorizoVenta;
        Vista.Notas = objeto.Notas ?? string.Empty;
        Vista.ModoEdicionDatos = true;

        Entidad = objeto;
    }

    protected override bool DatosEntidadCorrectos() {
        var nombreOk = !string.IsNullOrEmpty(Vista.Nombre);

        if (!nombreOk)
            CentroNotificaciones.Mostrar("El campo de nombre es obligatorio para el almacén, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);

        return nombreOk;
    }

    protected override async Task<Almacen?> ObtenerEntidadDesdeVista() {
        return new Almacen(
            Entidad?.Id ?? 0,
            Vista.Nombre,
            Vista.Direccion,
            Vista.AutorizoVenta,
            Vista.Notas
        );
    }
}