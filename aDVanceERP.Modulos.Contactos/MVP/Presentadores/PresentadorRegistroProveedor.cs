using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores;

public class PresentadorRegistroProveedor : PresentadorRegistroBase<IVistaRegistroProveedor, Proveedor, DatosProveedor,
    CriterioBusquedaProveedor> {
    public PresentadorRegistroProveedor(IVistaRegistroProveedor vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(Proveedor objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.RazonSocial = objeto.RazonSocial ?? string.Empty;
        Vista.NumeroIdentificacionTributaria = objeto.NumeroIdentificacionTributaria ?? string.Empty;

        using (var datosContacto = new DatosContacto()) {
            var contacto = datosContacto.Obtener(CriterioBusquedaContacto.Nombre, objeto.RazonSocial).FirstOrDefault();

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
        var nombreEncontrado = UtilesContacto.ObtenerIdContacto(Vista.RazonSocial).Result > 0;
        var nombreOk = !string.IsNullOrEmpty(Vista.RazonSocial) && !nombreEncontrado;

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
            CentroNotificaciones.Mostrar("Existe un contacto con el mismo nombre registrado o el campo de razón social se encuentra vacío, corrija los datos por favor", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);


        return nombreOk;
    }

    protected override void RegistroAuxiliar() {
        if (Vista.ModoEdicionDatos)
            return;

        using (var datosContacto = new DatosContacto()) {
            // Contacto
            var contacto = new Contacto(0,
                Vista.RazonSocial,
                Vista.CorreoElectronico,
                Vista.Direccion,
                "Proveedor");

            var idContacto = datosContacto.Adicionar(contacto);

            // Actualizar el ID del contacto
            if (Objeto != null)
                Objeto.IdContacto = idContacto;

            using (var datosTelefonoContacto = new DatosTelefonoContacto()) {
                var telefonos = new List<TelefonoContacto>();

                // Teléfono móvil
                if (!string.IsNullOrEmpty(Vista.TelefonoMovil))
                    telefonos.Add(new TelefonoContacto(
                        0,
                        "+53",
                        Vista.TelefonoMovil,
                        CategoriaTelefonoContacto.Movil,
                        idContacto
                    ));

                // Teléfono fijo
                if (!string.IsNullOrEmpty(Vista.TelefonoFijo))
                    telefonos.Add(new TelefonoContacto(
                        0,
                        "+53",
                        Vista.TelefonoFijo,
                        CategoriaTelefonoContacto.Fijo,
                        idContacto
                    ));

                foreach (var telefono in telefonos)
                    datosTelefonoContacto.Adicionar(telefono);
            }

            using (var datosProveedor = new DatosProveedor())
                datosProveedor.Editar(Objeto);
        }
    }

    protected override async Task<Proveedor?> ObtenerObjetoDesdeVista() {
        return new Proveedor(Objeto?.Id ?? 0,            
            Vista.RazonSocial,
            Vista.NumeroIdentificacionTributaria,
            await UtilesContacto.ObtenerIdContacto(Vista.RazonSocial)
        );
    }
}