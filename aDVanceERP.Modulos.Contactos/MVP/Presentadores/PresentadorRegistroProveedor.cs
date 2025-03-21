using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorRegistroProveedor : PresentadorRegistroBase<IVistaRegistroProveedor, Proveedor, DatosProveedor, CriterioBusquedaProveedor> {
        public PresentadorRegistroProveedor(IVistaRegistroProveedor vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Proveedor objeto) {
            Vista.NumeroIdentificacionTributaria = objeto.NumeroIdentificacionTributaria ?? string.Empty;
            Vista.RazonSocial = objeto.RazonSocial ?? string.Empty;
            Vista.NombreRepresentante = UtilesContacto.ObtenerNombreContacto(objeto.IdContactoRepresentante) ?? string.Empty;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override Proveedor? ObtenerObjetoDesdeVista() {
            return new Proveedor(_objeto?.Id ?? 0,
                    numeroIdentificacionTributaria: Vista.NumeroIdentificacionTributaria,
                    razonSocial: Vista.RazonSocial,
                    idContactoRepresentante: UtilesContacto.ObtenerIdContacto(Vista.NombreRepresentante)
                );
        }
    }
}
