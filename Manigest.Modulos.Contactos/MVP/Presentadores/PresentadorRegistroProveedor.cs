using Manigest.Core.MVP.Presentadores;
using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Contactos.MVP.Modelos;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios;
using Manigest.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorRegistroProveedor : PresentadorRegistroBase<IVistaRegistroProveedor, Proveedor, DatosProveedor, CriterioBusquedaProveedor> {
        public PresentadorRegistroProveedor(IVistaRegistroProveedor vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Proveedor objeto) {
            Vista.NumeroIdentificacionTributaria = objeto.NumeroIdentificacionTributaria;
            Vista.RazonSocial = objeto.RazonSocial;
            Vista.NombreRepresentante = UtilesContacto.ObtenerNombreContacto(objeto.IdContactoRepresentante) ?? string.Empty;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override Proveedor ObtenerObjetoDesdeVista() {
            return new Proveedor(_objeto?.Id ?? 0,
                    numeroIdentificacionTributaria: Vista.NumeroIdentificacionTributaria,
                    razonSocial: Vista.RazonSocial,
                    idContactoRepresentante: UtilesContacto.ObtenerIdContacto(Vista.NombreRepresentante)
                );
        }
    }
}
