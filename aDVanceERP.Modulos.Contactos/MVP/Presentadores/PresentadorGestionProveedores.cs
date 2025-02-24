using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores {
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
