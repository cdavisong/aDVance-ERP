using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas;
using aDVanceERP.Modulos.Contactos.Repositorios;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores; 

public class PresentadorGestionClientes : PresentadorGestionBase<PresentadorTuplaCliente, IVistaGestionClientes,
    IVistaTuplaCliente, Cliente, RepoCliente, FbCliente> {
    public PresentadorGestionClientes(IVistaGestionClientes vista) : base(vista) { }

    protected override PresentadorTuplaCliente ObtenerValoresTupla(Cliente objeto) {
        var presentadorTupla = new PresentadorTuplaCliente(new VistaTuplaCliente(), objeto);

        presentadorTupla.Vista.Id = objeto.Id.ToString();
        presentadorTupla.Vista.Numero = objeto.Numero ?? string.Empty;
        presentadorTupla.Vista.RazonSocial = objeto.RazonSocial ?? string.Empty;

        using (var datosContacto = new RepoContacto()) {
            var contacto = datosContacto.Buscar(FbContacto.Id, objeto.IdContacto.ToString()).resultados.FirstOrDefault();

            if (contacto != null) {
                using (var datosTelefonoContacto = new RepoTelefonoContacto()) {
                    var telefonosContacto = datosTelefonoContacto.Buscar(FbTelefonoContacto.IdContacto, contacto.Id.ToString()).resultados;
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