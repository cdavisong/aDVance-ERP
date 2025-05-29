using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.DisenoProducto.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores;

public class PresentadorRegistroDisenoProducto : PresentadorRegistroBase<IVistaRegistroDisenoProducto, DisenoProducto, DatosDisenoProducto, CriterioBusquedaDisenoProducto> {
    public PresentadorRegistroDisenoProducto(IVistaRegistroDisenoProducto vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(DisenoProducto objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.Nombre = objeto.Nombre;
        Vista.Descripcion = objeto.Descripcion ?? string.Empty;

        Objeto = objeto;
    }

    protected override bool RegistroEdicionDatosAutorizado() {
        var nombreOk = !string.IsNullOrEmpty(Vista.Nombre);

        if (!nombreOk)
            CentroNotificaciones.Mostrar("El campo de nombre es obligatorio para el diseño del producto, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);

        return nombreOk;
    }

    protected override Task<DisenoProducto?> ObtenerObjetoDesdeVista() {
        return Task.FromResult<DisenoProducto?>(new DisenoProducto(
            Objeto?.Id ?? 0,
            Vista.Nombre,
            string.IsNullOrEmpty(Vista.Descripcion) ? null : Vista.Descripcion
        ));
    }
}