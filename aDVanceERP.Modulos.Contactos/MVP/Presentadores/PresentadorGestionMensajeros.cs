using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero.Plantillas;
using aDVanceERP.Modulos.Contactos.Repositorios;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores;

public class PresentadorGestionMensajeros : PresentadorGestionBase<PresentadorTuplaMensajero, IVistaGestionMensajeros,
    IVistaTuplaMensajero, Mensajero, RepoMensajero, FbMensajero> {
    public PresentadorGestionMensajeros(IVistaGestionMensajeros vista) : base(vista) {
        vista.HabilitarDeshabilitarMensajero += IntercambiarHabilitacionMensajero;
        vista.EditarDatos += delegate {
            Vista.MostrarBtnHabilitarDeshabilitarMensajero = false;
        };
    }

    protected override PresentadorTuplaMensajero ObtenerValoresTupla(Mensajero objeto) {
        var presentadorTupla = new PresentadorTuplaMensajero(new VistaTuplaMensajero(), objeto);

        presentadorTupla.Vista.Id = objeto.Id.ToString();
        presentadorTupla.Vista.Nombre = objeto.Nombre;

        using (var datosContacto = new RepoContacto()) {
            var contacto = datosContacto.Buscar(FbContacto.Id, objeto.IdContacto.ToString()).resultados.FirstOrDefault();

            if (contacto != null) {
                using (var datosTelefonoContacto = new RepoTelefonoContacto()) {
                    var telefonosContacto =
                        datosTelefonoContacto.Buscar(FbTelefonoContacto.IdContacto, contacto.Id.ToString()).resultados;
                    var telefonoString = telefonosContacto.Aggregate(string.Empty,
                        (current, telefono) => current + $"{telefono.Prefijo} {telefono.Numero}, ");

                    if (!string.IsNullOrEmpty(telefonoString))
                        telefonoString = telefonoString[..^2];

                    presentadorTupla.Vista.Telefonos = telefonoString;
                }

                presentadorTupla.Vista.Direccion = contacto.Direccion ?? string.Empty;
            } else {
                presentadorTupla.Vista.Telefonos = string.Empty;
                presentadorTupla.Vista.Direccion = string.Empty;
            }
        }

        presentadorTupla.Vista.Activo = objeto.Activo;
        presentadorTupla.EntidadSeleccionada += CambiarVisibilidadBtnHabilitacionMensajero;
        presentadorTupla.EntidadDeseleccionada += CambiarVisibilidadBtnHabilitacionMensajero;

        return presentadorTupla;
    }

    public override Task PopularTuplasDatosEntidades() {
        // Cambiar la visibilidad de los botones
        Vista.MostrarBtnHabilitarDeshabilitarMensajero = false;

        return base.PopularTuplasDatosEntidades();
    }

    private void IntercambiarHabilitacionMensajero(object? sender, EventArgs e) {
        // 1. Filtrar primero las tuplas seleccionadas para evitar procesamiento innecesario
        var tuplasSeleccionadas = _tuplasEntidades.Where(t => t.TuplaSeleccionada).ToList();

        if (!tuplasSeleccionadas.Any()) {
            Vista.MostrarBtnHabilitarDeshabilitarMensajero = false;
            return;
        }

        // 2. Mover la instancia de DatosMensajero fuera del bucle
        using (var datosMensajero = new RepoMensajero()) {
            foreach (var tupla in tuplasSeleccionadas) {
                var mensajero = new Mensajero(
                        long.Parse(tupla.Vista.Id),
                        tupla.Vista.Nombre,
                        !tupla.Vista.Activo,
                        tupla.Entidad.IdContacto
                    );

                // 3. Actualizar el mensajero 1 vez por tupla
                datosMensajero.Actualizar(mensajero);
            }
        }

        Vista.MostrarBtnHabilitarDeshabilitarMensajero = false;
        _ = PopularTuplasDatosEntidades();
    }

    private void CambiarVisibilidadBtnHabilitacionMensajero(object? sender, EventArgs e) {
        Vista.MostrarBtnHabilitarDeshabilitarMensajero = _tuplasEntidades.Any(t => t.TuplaSeleccionada);
    }
}