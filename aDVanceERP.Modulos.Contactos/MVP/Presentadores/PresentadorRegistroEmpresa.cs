using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Empresa.Plantillas;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Contactos.Properties;
using aDVanceERP.Core.Mensajes.Utiles;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorRegistroEmpresa : PresentadorRegistroBase<IVistaRegistroEmpresa, Empresa, DatosEmpresa, CriterioBusquedaEmpresa> {
        public PresentadorRegistroEmpresa(IVistaRegistroEmpresa vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Empresa objeto) {
            Vista.ModoEdicionDatos = true;
            Vista.Logotipo = objeto.Logotipo ?? Resources.logoF_96px;
            Vista.Nombre = objeto.Nombre ?? string.Empty;            

            using (var datosContacto = new DatosContacto()) {
                var contacto = datosContacto.Obtener(CriterioBusquedaContacto.Id, objeto.IdContacto.ToString()).FirstOrDefault();

                if (contacto != null) {
                    Vista.TelefonoMovil = UtilesTelefonoContacto.ObtenerTelefonoContacto(contacto.Id, true) ?? string.Empty;
                    Vista.TelefonoFijo = UtilesTelefonoContacto.ObtenerTelefonoContacto(contacto.Id, false) ?? string.Empty;
                    Vista.CorreoElectronico = contacto.DireccionCorreoElectronico ?? string.Empty;
                    Vista.Direccion = contacto.Direccion ?? string.Empty;
                }
            }

            Objeto = objeto;
        }

        protected override bool RegistroEdicionDatosAutorizado() {
            var nombreEncontrado = UtilesContacto.ObtenerIdContacto(Vista.Nombre).Result > 0 && !Vista.ModoEdicionDatos;
            var nombreOk = !string.IsNullOrEmpty(Vista.Nombre) && !nombreEncontrado;

            if (!string.IsNullOrEmpty(Vista.TelefonoMovil)) {
                var noLetrasTelefonosOk = !Vista.TelefonoMovil.Replace(" ", "").Any(char.IsLetter);
                var numeroDijitos = Vista.TelefonoMovil.Select(char.IsDigit).Count(result => result == true);
                var numeroDijitosOk = numeroDijitos == 8;

                if (!noLetrasTelefonosOk || !numeroDijitosOk) {
                    CentroNotificaciones.Mostrar("El campo del teléfono móvil tiene caracteres no permitidos o no tiene la cantidad de dígitos correcta, corrija los datos por favor", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(Vista.TelefonoFijo)) {
                var noLetrasTelefonosOk = !Vista.TelefonoFijo.Replace(" ", "").Any(char.IsLetter);
                var numeroDijitos = Vista.TelefonoFijo.Select(char.IsDigit).Count(result => result == true);
                var numeroDijitosOk = numeroDijitos == 8;

                if (!noLetrasTelefonosOk || !numeroDijitosOk) {
                    CentroNotificaciones.Mostrar("El campo del teléfono fijo tiene caracteres no permitidos o no tiene la cantidad de dígitos correcta, corrija los datos por favor", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
                    return false;
                }
            }

            if (!nombreOk)
                CentroNotificaciones.Mostrar("Existe un contacto con el mismo nombre registrado o el campo de nombre se encuentra vacío, corrija los datos por favor", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);


            return nombreOk;
        }

        protected override void RegistroAuxiliar() {
            using (var datosContacto = new DatosContacto()) {
                //TODO: Contacto
                var contactoBd = datosContacto.Obtener(CriterioBusquedaContacto.Id, (Objeto?.IdContacto ?? 0).ToString()).FirstOrDefault();
                var contacto = Vista. new Contacto(Objeto?.IdContacto ?? 0,
                    Vista.Nombre,
                    Vista.CorreoElectronico,
                    Vista.Direccion,
                    "Nuestra empresa");

                if (Vista.ModoEdicionDatos && contacto.Id != 0)
                    datosContacto.Editar(contacto);
                else if (contacto.Id != 0)
                    datosContacto.Editar(contacto);
                else
                    Objeto.IdContacto = datosContacto.Adicionar(contacto);

                using (var datosTelefonoContacto = new DatosTelefonoContacto()) {
                    var telefonos = new List<TelefonoContacto>();

                    // Teléfono móvil
                    if (!string.IsNullOrEmpty(Vista.TelefonoMovil))
                        telefonos.Add(new TelefonoContacto(
                            _movil?.Id ?? 0,
                            "+53",
                            Vista.TelefonoMovil,
                            CategoriaTelefonoContacto.Movil,
                            Objeto?.IdContacto ?? 0
                        ));
                    else if (Vista.ModoEdicionDatos && _movil.Id != 0)
                        datosTelefonoContacto.Eliminar(_movil.Id);

                    // Teléfono fijo
                    if (!string.IsNullOrEmpty(Vista.TelefonoFijo))
                        telefonos.Add(new TelefonoContacto(
                            0,
                            "+53",
                            Vista.TelefonoFijo,
                            CategoriaTelefonoContacto.Fijo,
                            Objeto?.IdContacto ?? 0
                        ));

                    foreach (var telefono in telefonos)
                        datosTelefonoContacto.Adicionar(telefono);
                }
            }
        }

        protected override async Task<Empresa?> ObtenerObjetoDesdeVista() {
            return new Empresa(Objeto?.Id ?? 0,
                Vista.Logotipo,
                Vista.Nombre,
                await UtilesContacto.ObtenerIdContacto(Vista.Nombre)
            );
        }
    }
}
