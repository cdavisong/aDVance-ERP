using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Presentadores.Comun.Interfaces;

public interface IPresentadorVistaTupla<Vt, Eb> : IPresentadorVistaBase<Vt>
    where Vt : class, IVistaTupla
    where Eb : class, IEntidadBaseDatos, new()
{
   
    Eb Entidad { get; }

    bool EstadoSeleccion { get; set; }

    event EventHandler? EntidadSeleccionada;
    event EventHandler? EntidadDeseleccionada;
    event EventHandler? EditarEntidad;
    event EventHandler? EliminarEntidad;
}