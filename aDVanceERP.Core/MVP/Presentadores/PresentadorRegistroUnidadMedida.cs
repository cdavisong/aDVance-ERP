using aDVanceERP.Core.MVP.Modelos;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.MVP.Vistas.UnidadMedida.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores;

public class PresentadorRegistroUnidadMedida : PresentadorRegistroBase<IVistaRegistroUnidadMedida, UnidadMedida, RepoUnidadMedida, FiltroBusquedaUnidadMedida> {
    public PresentadorRegistroUnidadMedida(IVistaRegistroUnidadMedida vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(UnidadMedida objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.Nombre = objeto.Nombre;
        Vista.Abreviatura = objeto.Abreviatura;
        Vista.Descripcion = objeto.Descripcion ?? string.Empty; // Asegurar que no sea null

        Entidad = objeto;
    }

    protected override bool RegistroEdicionDatosAutorizado() {
        var nombreOk = !string.IsNullOrEmpty(Vista.Nombre);
        var abreviaturaOk = !string.IsNullOrEmpty(Vista.Abreviatura);

        return nombreOk && abreviaturaOk;
    }

    protected override UnidadMedida? ObtenerEntidadDesdeVista() {
        return new UnidadMedida(
            Vista.ModoEdicionDatos && Entidad != null ? Entidad.Id : 0,
            Vista.Nombre,
            Vista.Abreviatura,
            string.IsNullOrEmpty(Vista.Descripcion) ? null : Vista.Descripcion
        );
    }
}