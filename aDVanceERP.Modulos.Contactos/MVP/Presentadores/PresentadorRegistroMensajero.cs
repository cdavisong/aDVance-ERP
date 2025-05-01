using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores;

public class PresentadorRegistroMensajero : PresentadorRegistroBase<IVistaRegistroMensajero, Mensajero, DatosMensajero,
    CriterioBusquedaMensajero> {
    public PresentadorRegistroMensajero(IVistaRegistroMensajero vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(Mensajero objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.Nombre = objeto.Nombre;

        using (var datosContacto = new DatosContacto()) {
            var contacto = datosContacto.Obtener(CriterioBusquedaContacto.Id, objeto.IdContacto.ToString()).FirstOrDefault();

            if (contacto != null) {
                Vista.TelefonoMovil = UtilesTelefonoContacto.ObtenerTelefonoContacto(contacto.Id, true) ?? string.Empty;
            }
        }

        Objeto = objeto;
    }

    protected override bool RegistroEdicionDatosAutorizado() {
        var nombreEncontrado = UtilesContacto.ObtenerIdContacto(Vista.Nombre).Result > 0;
        var nombreOk = !string.IsNullOrEmpty(Vista.Nombre) && !nombreEncontrado;
        var telefonoOk = !string.IsNullOrEmpty(Vista.TelefonoMovil);

        if (!string.IsNullOrEmpty(Vista.TelefonoMovil)) {
            var noLetrasTelefonosOk = !Vista.TelefonoMovil.Replace(" ", "").Any(char.IsLetter);
            var numeroDijitos = Vista.TelefonoMovil.Select(char.IsDigit).Count(result => result == true);
            var numeroDijitosOk = numeroDijitos == 8;

            if (!noLetrasTelefonosOk || !numeroDijitosOk) {
                CentroNotificaciones.Mostrar("El campo del teléfono móvil tiene caracteres no permitidos o no tiene la cantidad de dígitos correcta, corrija los datos por favor", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
                return false;
            }
        }

        if (!nombreOk)
            CentroNotificaciones.Mostrar("Existe un contacto con el mismo nombre registrado o el campo de nombre se encuentra vacío, corrija los datos por favor", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
        if (!telefonoOk)
            CentroNotificaciones.Mostrar("EL campo del teléfono móvil es obligatorio para el mensajero, rellene los datos necesarios de forma correcta y proceda al registro", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);

        return nombreOk && telefonoOk;
    }

    protected override void RegistroAuxiliar() {
        if (Vista.ModoEdicionDatos)
            return;

        using (var datosContacto = new DatosContacto()) {
            // Contacto
            var contacto = new Contacto(0,
                Vista.Nombre,
                string.Empty,
                string.Empty,
                "Mensajero");

            var idContacto = datosContacto.Adicionar(contacto);

            // Actualizar el ID del contacto
            if (Objeto != null)
                Objeto.IdContacto = idContacto;

            using (var datosTelefonoContacto = new DatosTelefonoContacto())
                datosTelefonoContacto.Adicionar(new TelefonoContacto(
                        0,
                        "+53",
                        Vista.TelefonoMovil,
                        CategoriaTelefonoContacto.Movil,
                        idContacto
                    ));

            using (var datosMensajero = new DatosMensajero())
                datosMensajero.Editar(Objeto);
        }
    }

    protected override async Task<Mensajero?> ObtenerObjetoDesdeVista() {
        return new Mensajero(Objeto?.Id ?? 0,
            Vista.Nombre,
            true,
            await UtilesContacto.ObtenerIdContacto(Vista.Nombre)
        );
    }
}