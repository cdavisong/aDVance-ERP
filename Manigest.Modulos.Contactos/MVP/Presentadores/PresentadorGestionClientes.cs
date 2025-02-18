using Manigest.Core.MVP.Presentadores;
using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Contactos.MVP.Modelos;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios;
using Manigest.Modulos.Contactos.MVP.Vistas.Cliente;
using Manigest.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorGestionClientes : PresentadorGestionBase<PresentadorTuplaCliente, IVistaGestionClientes, IVistaTuplaCliente, Cliente, DatosCliente, CriterioBusquedaCliente> {
        public PresentadorGestionClientes(IVistaGestionClientes vista) : base(vista) {
        }

        protected override PresentadorTuplaCliente ObtenerValoresTupla(Cliente objeto) {
            var presentadorTupla = new PresentadorTuplaCliente(new VistaTuplaCliente(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.Numero = objeto.Numero;
            presentadorTupla.Vista.RazonSocial = objeto.RazonSocial;
            presentadorTupla.Vista.NombreContacto = UtilesContacto.ObtenerNombreContacto(objeto.IdContacto) ?? string.Empty;

            return presentadorTupla;
        }
    }
}
