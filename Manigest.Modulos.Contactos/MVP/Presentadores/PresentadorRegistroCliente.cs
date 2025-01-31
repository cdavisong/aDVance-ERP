using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Contactos.MVP.Modelos;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios;
using Manigest.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorRegistroCliente : PresentadorRegistroBase<IVistaRegistroCliente, Cliente, DatosCliente, CriterioBusquedaCliente> {
        public PresentadorRegistroCliente(IVistaRegistroCliente vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Cliente objeto) {
            var datosContacto = new DatosContacto();
            var contacto = datosContacto.Obtener(CriterioBusquedaContacto.Id, objeto.IdContacto.ToString()).FirstOrDefault();

            Vista.Numero = objeto.Numero;
            Vista.RazonSocial = objeto.RazonSocial;
            Vista.NombreContacto = contacto?.Nombre ?? string.Empty;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override Cliente ObtenerObjetoDesdeVista() {
            var datosContacto = new DatosContacto();

            return new Cliente(_objeto?.Id ?? 0,
                    numero: Vista.Numero,
                    razonSocial: Vista.RazonSocial,
                    idContacto: datosContacto.Obtener(CriterioBusquedaContacto.Nombre, Vista.NombreContacto).FirstOrDefault()?.Id ?? 0
                );
        }
    }
}
