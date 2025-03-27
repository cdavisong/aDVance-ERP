using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorRegistroCliente : PresentadorRegistroBase<IVistaRegistroCliente, Cliente, DatosCliente, CriterioBusquedaCliente> {
        public PresentadorRegistroCliente(IVistaRegistroCliente vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Cliente objeto) {
            Vista.Numero = objeto.Numero;
            Vista.RazonSocial = objeto.RazonSocial;
            Vista.NombreContacto = UtilesContacto.ObtenerNombreContacto(objeto.IdContacto) ?? string.Empty;
            Vista.ModoEdicionDatos = true;

            Objeto = objeto;
        }

        protected override async Task<Cliente?> ObtenerObjetoDesdeVista() {
            return new Cliente(Objeto?.Id ?? 0,
                    numero: Vista.Numero,
                    razonSocial: Vista.RazonSocial,
                    idContacto: await UtilesContacto.ObtenerIdContacto(Vista.NombreContacto)
                );
        }
    }
}
