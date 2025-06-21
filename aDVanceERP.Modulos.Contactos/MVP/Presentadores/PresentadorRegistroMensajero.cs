using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero.Plantillas;
using aDVanceERP.Modulos.Contactos.Repositorios;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores;

public class PresentadorRegistroMensajero : PresentadorRegistroBase<IVistaRegistroMensajero, Mensajero, RepoMensajero,
    FbMensajero> {
    public PresentadorRegistroMensajero(IVistaRegistroMensajero vista) : base(vista) { }

    public override void PopularVistaDesdeEntidad(Mensajero objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.Nombre = objeto.Nombre;

        using (var datosContacto = new RepoContacto()) {
            var contacto = datosContacto.Buscar(FbContacto.Id, objeto.IdContacto.ToString()).resultados.FirstOrDefault();

            if (contacto != null) {
                Vista.TelefonoMovil = UtilesTelefonoContacto.ObtenerTelefonoContacto(contacto.Id, true) ?? string.Empty;
            }
        }

        Entidad = objeto;
    }

    protected override bool DatosEntidadCorrectos() {
        var nombreEncontrado = UtilesContacto.ObtenerIdContacto(Vista.Nombre).Result > 0 && !Vista.ModoEdicionDatos;
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

    protected override void RegistroAuxiliar(RepoMensajero datosMensajero, long id) {
        using (var datosContacto = new RepoContacto()) {
            // Contacto
            var contacto = datosContacto.ObtenerPorId(Entidad?.IdContacto) ??
                new Contacto();

            contacto.Nombre = Vista.Nombre;
            contacto.Notas = "Mensajero";

            if (Vista.ModoEdicionDatos && contacto.Id != 0)
                datosContacto.Actualizar(contacto);
            else if (contacto.Id != 0)
                datosContacto.Actualizar(contacto);
            else if (Entidad != null) {
                Entidad.IdContacto = datosContacto.Insertar(contacto);

                // Editar mensajero para modificar Id del contacto
                datosMensajero.Actualizar(Entidad);
            }

            using (var datosTelefonoContacto = new RepoTelefonoContacto()) {
                var telefonos = datosTelefonoContacto.Buscar(FbTelefonoContacto.IdContacto, (Entidad?.IdContacto ?? 0).ToString()).resultados ??
                    new List<TelefonoContacto>();
                var indiceTelefonoMovil = telefonos.FindIndex(t => t.Categoria == CategoriaTelefonoContacto.Movil);
                var indiceTelefonoFijo = telefonos.FindIndex(t => t.Categoria == CategoriaTelefonoContacto.Fijo);

                // Teléfono móvil
                if (!string.IsNullOrEmpty(Vista.TelefonoMovil)) {
                    if (indiceTelefonoMovil != -1) {
                        telefonos[indiceTelefonoMovil].Numero = Vista.TelefonoMovil;
                    } else {
                        var telefonoMovil = new TelefonoContacto(
                            0,
                            "+53",
                            Vista.TelefonoMovil,
                            CategoriaTelefonoContacto.Movil,
                            Entidad?.IdContacto ?? 0);

                        telefonos.Add(telefonoMovil);
                    }
                } else {
                    if (Vista.ModoEdicionDatos && indiceTelefonoMovil != -1) {
                        datosTelefonoContacto.Eliminar(telefonos[indiceTelefonoMovil].Id);
                        telefonos.RemoveAt(indiceTelefonoMovil);
                    }
                }

                foreach (var telefono in telefonos)
                    if (Vista.ModoEdicionDatos && telefono.Id != 0)
                        datosTelefonoContacto.Actualizar(telefono);
                    else if (telefono.Id != 0)
                        datosTelefonoContacto.Actualizar(telefono);
                    else
                        datosTelefonoContacto.Insertar(telefono);
            }
        }
    }

    protected override Mensajero? ObtenerEntidadDesdeVista() {
        return new Mensajero(Entidad?.Id ?? 0,
            Vista.Nombre,
            true,
            UtilesContacto.ObtenerIdContacto(Vista.Nombre).Result
        );
    }
}