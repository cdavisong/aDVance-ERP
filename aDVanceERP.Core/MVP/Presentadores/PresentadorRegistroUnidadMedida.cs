using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.MVP.Vistas.UnidadMedida.Plantillas;
using aDVanceERP.Core.Presentadores.Comun;
using aDVanceERP.Core.Repositorios.Modulos.Inventario;

namespace aDVanceERP.Core.MVP.Presentadores;

public class PresentadorRegistroUnidadMedida : PresentadorVistaRegistro<IVistaRegistroUnidadMedida, UnidadMedida, RepoUnidadMedida, FiltroBusquedaUnidadMedida> {
    public PresentadorRegistroUnidadMedida(IVistaRegistroUnidadMedida vista) : base(vista) { }

    public override void PopularVistaDesdeEntidad(UnidadMedida objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.Nombre = objeto.Nombre;
        Vista.Abreviatura = objeto.Abreviatura;
        Vista.Descripcion = objeto.Descripcion ?? string.Empty; // Asegurar que no sea null

        _entidad = objeto;
    }

    protected override bool EntidadCorrecta() {
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