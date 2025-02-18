using Manigest.Core.MVP.Presentadores;
using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Contactos.MVP.Modelos;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios;
using Manigest.Modulos.Contactos.MVP.Vistas.Proveedor;
using Manigest.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorGestionProveedores : PresentadorGestionBase<PresentadorTuplaProveedor, IVistaGestionProveedores, IVistaTuplaProveedor, Proveedor, DatosProveedor, CriterioBusquedaProveedor> {
        public PresentadorGestionProveedores(IVistaGestionProveedores vista) : base(vista) {
        }

        protected override PresentadorTuplaProveedor ObtenerValoresTupla(Proveedor objeto) {
            var presentadorTupla = new PresentadorTuplaProveedor(new VistaTuplaProveedor(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.NumeroIdentificacionTributaria = objeto.NumeroIdentificacionTributaria;
            presentadorTupla.Vista.RazonSocial = objeto.RazonSocial;
            presentadorTupla.Vista.NombreRepresentante = UtilesContacto.ObtenerNombreContacto(objeto.IdContactoRepresentante) ?? string.Empty;

            return presentadorTupla;
        }
    }
}
