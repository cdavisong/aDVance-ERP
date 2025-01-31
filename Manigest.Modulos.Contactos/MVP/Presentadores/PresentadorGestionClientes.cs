using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Contactos.MVP.Modelos;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios;
using Manigest.Modulos.Contactos.MVP.Vistas.Cliente;
using Manigest.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorGestionClientes : PresentadorGestionBase<PresentadorTuplaCliente, IVistaGestionClientes, IVistaTuplaCliente, Cliente, DatosCliente, CriterioBusquedaCliente> {
        public PresentadorGestionClientes(IVistaGestionClientes vista) : base(vista) {
        }

        public override CriterioBusquedaCliente CriterioBusquedaObjeto => CriterioBusquedaCliente.Nombre;

        protected override PresentadorTuplaCliente ObtenerValoresTupla(Cliente objeto) {
            var datosContacto = new DatosContacto();
            var presentadorTupla = new PresentadorTuplaCliente(new VistaTuplaCliente(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.Numero = objeto.Numero;
            presentadorTupla.Vista.RazonSocial = objeto.RazonSocial;
            presentadorTupla.Vista.NombreContacto = datosContacto.Obtener(CriterioBusquedaContacto.Id, objeto.IdContacto.ToString()).FirstOrDefault()?.Nombre;

            return presentadorTupla;
        }
    }
}
