using aDVanceERP.Core.MVP.Modelos;
using aDVanceERP.Core.MVP.Vistas.UnidadMedida.Plantillas;
using aDVanceERP.Core.Repositorios;

namespace aDVanceERP.Core.MVP.Presentadores;

public class PresentadorRegistroUnidadMedida : PresentadorRegistroBase<IVistaRegistroUnidadMedida, UnidadMedida, RepoUnidadMedida, FbUnidadMedida> {
    public PresentadorRegistroUnidadMedida(IVistaRegistroUnidadMedida vista) : base(vista) { }

    public override void PopularVistaDesdeEntidad(UnidadMedida objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.Nombre = objeto.Nombre;
        Vista.Abreviatura = objeto.Abreviatura;
        Vista.Descripcion = objeto.Descripcion ?? string.Empty; // Asegurar que no sea null

        Entidad = objeto;
    }

    protected override bool DatosEntidadCorrectos() {
        var nombreOk = !string.IsNullOrEmpty(Vista.Nombre);
        var abreviaturaOk = !string.IsNullOrEmpty(Vista.Abreviatura);

        return nombreOk && abreviaturaOk;
    }

    protected override UnidadMedida? ObtenerEntidadDesdeVista() {
        return new UnidadMedida(Entidad?.Id ?? 0,
            Vista.Nombre,
            Vista.Abreviatura,
            string.IsNullOrEmpty(Vista.Descripcion) ? "No hay descripción disponible" : Vista.Descripcion
        );
    }
}