using aDVanceERP.Core.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores;

public class PresentadorGestionClientes : PresentadorVistaGestionBase<PresentadorTuplaCliente, IVistaGestionClientes,
    IVistaTuplaCliente, Cliente, DatosCliente, CriterioBusquedaCliente> {
    public PresentadorGestionClientes(IVistaGestionClientes vista) : base(vista) { }

    protected override PresentadorTuplaCliente ObtenerValoresTupla(Cliente objeto) {
        var presentadorTupla = new PresentadorTuplaCliente(new VistaTuplaCliente(), objeto);

        presentadorTupla.Vista.Id = objeto.Id.ToString();
        presentadorTupla.Vista.Numero = objeto.Numero ?? string.Empty;
        presentadorTupla.Vista.RazonSocial = objeto.RazonSocial ?? string.Empty;

        using (var datosContacto = new DatosContacto()) {
            var contacto = datosContacto.Obtener(CriterioBusquedaContacto.Id, objeto.IdContacto.ToString()).FirstOrDefault();

            if (contacto != null) {
                using (var datosTelefonoContacto = new DatosTelefonoContacto()) {
                    var telefonosContacto =
                        datosTelefonoContacto.Obtener(CriterioBusquedaTelefonoContacto.IdContacto, contacto.Id.ToString());
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

        return presentadorTupla;
    }
}