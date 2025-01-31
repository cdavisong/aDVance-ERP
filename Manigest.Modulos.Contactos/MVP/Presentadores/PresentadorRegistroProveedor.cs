using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Contactos.MVP.Modelos;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios;
using Manigest.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorRegistroProveedor : PresentadorRegistroBase<IVistaRegistroProveedor, Proveedor, DatosProveedor, CriterioBusquedaProveedor> {
        public PresentadorRegistroProveedor(IVistaRegistroProveedor vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Proveedor objeto) {
            var datosContacto = new DatosContacto();

            Vista.NumeroIdentificacionTributaria = objeto.NumeroIdentificacionTributaria;
            Vista.RazonSocial = objeto.RazonSocial;
            Vista.NombreRepresentante = datosContacto.Obtener(CriterioBusquedaContacto.Id, objeto.IdContactoRepresentante.ToString()).FirstOrDefault()?.Nombre ?? string.Empty;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override Proveedor ObtenerObjetoDesdeVista() {
            var datosContacto = new DatosContacto();

            return new Proveedor(_objeto?.Id ?? 0,
                    numeroIdentificacionTributaria: Vista.NumeroIdentificacionTributaria,
                    razonSocial: Vista.RazonSocial,
                    idContactoRepresentante: datosContacto.Obtener(CriterioBusquedaContacto.Nombre, Vista.NombreRepresentante).FirstOrDefault()?.Id ?? 0
                );
        }
    }
}
