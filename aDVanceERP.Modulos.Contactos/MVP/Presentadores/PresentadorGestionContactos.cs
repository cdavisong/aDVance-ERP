using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Contacto;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Contacto.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorGestionContactos : PresentadorGestionBase<PresentadorTuplaContacto, IVistaGestionContactos, IVistaTuplaContacto, Contacto, DatosContacto, CriterioBusquedaContacto> {
        public PresentadorGestionContactos(IVistaGestionContactos vista) : base(vista) {
        }

        protected override PresentadorTuplaContacto ObtenerValoresTupla(Contacto objeto) {
            var presentadorTupla = new PresentadorTuplaContacto(new VistaTuplaContacto(), objeto);
            
            using (var datosTelefonoContacto = new DatosTelefonoContacto()) {                
                var telefonosContacto = datosTelefonoContacto.Obtener(CriterioBusquedaTelefonoContacto.IdContacto, objeto.Id.ToString());
                var telefonoString = string.Empty;

                presentadorTupla.Vista.Id = objeto.Id.ToString();
                presentadorTupla.Vista.Nombre = objeto.Nombre ?? string.Empty;

                foreach (var telefono in telefonosContacto)
                    telefonoString += $"{telefono.Prefijo} {telefono.Numero}, ";
                if (!string.IsNullOrEmpty(telefonoString))
                    telefonoString = telefonoString.Substring(0, telefonoString.Length - 2);

                presentadorTupla.Vista.Telefonos = telefonoString;
                presentadorTupla.Vista.CorreoElectronico = objeto.DireccionCorreoElectronico ?? string.Empty;
                presentadorTupla.Vista.Direccion = objeto.Direccion ?? string.Empty;
            }

            return presentadorTupla;
        }
    }
}
