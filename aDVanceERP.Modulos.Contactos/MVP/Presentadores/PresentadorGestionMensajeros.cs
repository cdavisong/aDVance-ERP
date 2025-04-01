using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores;

public class PresentadorGestionMensajeros : PresentadorGestionBase<PresentadorTuplaMensajero, IVistaGestionMensajeros, IVistaTuplaMensajero, Mensajero, DatosMensajero, CriterioBusquedaMensajero> {
    public PresentadorGestionMensajeros(IVistaGestionMensajeros vista) : base(vista) { }

    protected override PresentadorTuplaMensajero ObtenerValoresTupla(Mensajero objeto) {
        var presentadorTupla = new PresentadorTuplaMensajero(new VistaTuplaMensajero(), objeto);

        presentadorTupla.Vista.Id = objeto.Id.ToString();
        presentadorTupla.Vista.Nombre = objeto.Nombre;
        
        using (var datosTelefonoContacto = new DatosTelefonoContacto()) {
            var telefonosContacto = datosTelefonoContacto.Obtener(CriterioBusquedaTelefonoContacto.IdContacto, objeto.IdContacto.ToString());
            var telefonoString = telefonosContacto.Aggregate(string.Empty, (current, telefono) => current + $"{telefono.Prefijo} {telefono.Numero}, ");

            if (!string.IsNullOrEmpty(telefonoString))
                telefonoString = telefonoString[..^2];

            presentadorTupla.Vista.Telefonos = telefonoString;
        }

        using (var datosContacto = new DatosContacto()) {
            var contacto = datosContacto.Obtener(CriterioBusquedaContacto.Id, objeto.IdContacto.ToString()).FirstOrDefault();

            presentadorTupla.Vista.Direccion = contacto?.Direccion ?? string.Empty;
        }

        presentadorTupla.Vista.Activo = objeto.Activo;

        return presentadorTupla;
    }
}