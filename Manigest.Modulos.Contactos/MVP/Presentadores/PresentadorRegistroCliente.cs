using Manigest.Core.MVP.Presentadores;
using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Contactos.MVP.Modelos;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios;
using Manigest.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorRegistroCliente : PresentadorRegistroBase<IVistaRegistroCliente, Cliente, DatosCliente, CriterioBusquedaCliente> {
        public PresentadorRegistroCliente(IVistaRegistroCliente vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Cliente objeto) {
            Vista.Numero = objeto.Numero;
            Vista.RazonSocial = objeto.RazonSocial;
            Vista.NombreContacto = UtilesContacto.ObtenerNombreContacto(objeto.IdContacto) ?? string.Empty;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override Cliente ObtenerObjetoDesdeVista() {
            return new Cliente(_objeto?.Id ?? 0,
                    numero: Vista.Numero,
                    razonSocial: Vista.RazonSocial,
                    idContacto: UtilesContacto.ObtenerIdContacto(Vista.NombreContacto)
                );
        }
    }
}
