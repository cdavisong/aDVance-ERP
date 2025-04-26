using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Contacto.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores; 

public class PresentadorRegistroContacto : PresentadorRegistroBase<IVistaRegistroContacto, Contacto, DatosContacto,
    CriterioBusquedaContacto> {
    private TelefonoContacto _fijo;
    private TelefonoContacto _movil;

    public PresentadorRegistroContacto(IVistaRegistroContacto vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(Contacto objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.Nombre = objeto.Nombre ?? string.Empty;
        Vista.TelefonoMovil = UtilesTelefonoContacto.ObtenerTelefonoContacto(objeto.Id, true) ?? string.Empty;
        Vista.TelefonoFijo = UtilesTelefonoContacto.ObtenerTelefonoContacto(objeto.Id, false) ?? string.Empty;
        Vista.CorreoElectronico = objeto.DireccionCorreoElectronico ?? string.Empty;
        Vista.Direccion = objeto.Direccion ?? string.Empty;
        Vista.Notas = objeto.Notas ?? string.Empty;        

        Objeto = objeto;
    }

    protected override bool RegistroEdicionDatosAutorizado() {
        var nombreEncontrado = UtilesContacto.ObtenerIdContacto(Vista.Nombre).Result > 0;
        var nombreOk = !string.IsNullOrEmpty(Vista.Nombre) && !nombreEncontrado;
        
        if (!string.IsNullOrEmpty(Vista.TelefonoMovil)) {
            var noLetrasTelefonosOk = !Vista.TelefonoMovil.Replace(" ", "").Any(char.IsLetter);
            var numeroDijitos = Vista.TelefonoMovil.Select(char.IsDigit).Count(result => result == true);
            var numeroDijitosOk = numeroDijitos == 8;

            if (!noLetrasTelefonosOk || !numeroDijitosOk)
                CentroNotificaciones.Mostrar("El campo del teléfono móvil tiene caracteres no permitidos o no tiene la cantidad de dígitos correcta, corrija los datos por favor", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
            
            return false;
        }

        if (!string.IsNullOrEmpty(Vista.TelefonoFijo)) {
            var noLetrasTelefonosOk = !Vista.TelefonoFijo.Replace(" ", "").Any(char.IsLetter);
            var numeroDijitos = Vista.TelefonoFijo.Select(char.IsDigit).Count(result => result == true);
            var numeroDijitosOk = numeroDijitos == 8;

            if (!noLetrasTelefonosOk || !numeroDijitosOk)
                CentroNotificaciones.Mostrar("El campo del teléfono fijo tiene caracteres no permitidos o no tiene la cantidad de dígitos correcta, corrija los datos por favor", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);

            return false;
        }

        if (!nombreOk)
            CentroNotificaciones.Mostrar("Existe un contacto con el mismo nombre registrado o el campo de nombre se encuentra vacío, corrija los datos por favor", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
        

        return nombreOk;
    }

    protected override Task<Contacto?> ObtenerObjetoDesdeVista() {
        return Task.FromResult<Contacto?>(new Contacto(Objeto?.Id ?? 0,
            Vista.Nombre,
            Vista.CorreoElectronico,
            Vista.Direccion,
            Vista.Notas
        ));
    }

    /// <summary>
    ///     Registro o actualización de teléfonos para el contacto.
    /// </summary>
    protected override void RegistroAuxiliar() {
        var datosTelefonoContacto = new DatosTelefonoContacto();
        var telefonos = new List<TelefonoContacto>();

        // Teléfono móvil
        if (!string.IsNullOrEmpty(Vista.TelefonoMovil))
            telefonos.Add(new TelefonoContacto(
                _movil?.Id ?? 0,
                "+53",
                Vista.TelefonoMovil,
                CategoriaTelefonoContacto.Movil,
                Objeto?.Id ?? 0
            ));
        else if (Vista.ModoEdicionDatos && _movil.Id != 0)
            datosTelefonoContacto.Eliminar(_movil.Id);

        // Teléfono fijo
        if (!string.IsNullOrEmpty(Vista.TelefonoFijo))
            telefonos.Add(new TelefonoContacto(
                _fijo?.Id ?? 0,
                "+53",
                Vista.TelefonoFijo,
                CategoriaTelefonoContacto.Fijo,
                Objeto.Id
            ));
        else if (Vista.ModoEdicionDatos && _fijo.Id != 0)
            datosTelefonoContacto.Eliminar(_fijo.Id);

        foreach (var telefono in telefonos)
            if (Vista.ModoEdicionDatos && telefono.Id != 0)
                datosTelefonoContacto.Editar(telefono);
            else if (telefono.Id != 0)
                datosTelefonoContacto.Editar(telefono);
            else
                datosTelefonoContacto.Adicionar(telefono);
    }
}