using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Contactos.MVP.Modelos;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios;
using Manigest.Modulos.Contactos.MVP.Vistas.Contacto.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorRegistroContacto : PresentadorRegistroBase<IVistaRegistroContacto, Contacto, DatosContacto, CriterioBusquedaContacto> {
        private TelefonoContacto _movil;
        private TelefonoContacto _fijo;

        public PresentadorRegistroContacto(IVistaRegistroContacto vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Contacto objeto) {
            var datosTelefonoContacto = new DatosTelefonoContacto();
            var telefonosContacto = datosTelefonoContacto.Obtener(CriterioBusquedaTelefonoContacto.IdContacto, objeto.Id.ToString());

            Vista.Nombre = objeto.Nombre;

            try {
                var telefonoMovil = telefonosContacto.FirstOrDefault(t => t.Categoria == CategoriaTelefonoContacto.Movil);

                Vista.TelefonoMovil = telefonoMovil.Numero;
                _movil = telefonoMovil;
            } catch (InvalidOperationException) {
                Vista.TelefonoMovil = string.Empty;
            }

            try {
                var telefonoFijo = telefonosContacto.FirstOrDefault(t => t.Categoria == CategoriaTelefonoContacto.Fijo);

                Vista.TelefonoFijo = telefonoFijo.Numero;
                _movil = telefonoFijo;
            } catch (InvalidOperationException) {
                Vista.TelefonoFijo = string.Empty;
            }

            Vista.CorreoElectronico = objeto.DireccionCorreoElectronico;
            Vista.Direccion = objeto.Direccion;
            Vista.Notas = objeto.Notas;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override Contacto ObtenerObjetoDesdeVista() {
            return new Contacto(_objeto?.Id ?? 0,
                    nombre: Vista.Nombre,
                    direccionCorreoElectronico: Vista.CorreoElectronico,
                    direccion: Vista.Direccion,
                    notas: Vista.Notas
                );
        }

        /// <summary>
        /// Registro o actualización de teléfonos para el contacto.
        /// </summary>
        protected override void RegistroAuxiliar() {
            var datosTelefonoContacto = new DatosTelefonoContacto();
            var telefonos = new List<TelefonoContacto>();

            // Teléfono móvil
            if (!string.IsNullOrEmpty(Vista.TelefonoMovil))
                telefonos.Add(new TelefonoContacto(
                    idTelefonoContacto: _movil?.Id ?? 0,
                    prefijo: "+53",
                    numero: Vista.TelefonoMovil,
                    categoria: CategoriaTelefonoContacto.Movil,
                    idContacto: _objeto.Id
                    ));
            else if (Vista.ModoEdicionDatos && _movil.Id != 0)
                datosTelefonoContacto.Eliminar(_movil.Id);

            // Teléfono fijo
            if (!string.IsNullOrEmpty(Vista.TelefonoFijo))
                telefonos.Add(new TelefonoContacto(
                    idTelefonoContacto: _fijo?.Id ?? 0,
                    prefijo: "+53",
                    numero: Vista.TelefonoFijo,
                    categoria: CategoriaTelefonoContacto.Fijo,
                    idContacto: _objeto.Id
                    ));
            else if (Vista.ModoEdicionDatos && _fijo.Id != 0)
                datosTelefonoContacto.Eliminar(_fijo.Id);

            foreach (var telefono in telefonos)
                if (Vista.ModoEdicionDatos && telefono.Id != 0)
                    datosTelefonoContacto.Editar(telefono);
                else if (telefono.Id != 0)
                    datosTelefonoContacto.Editar(telefono);
                else
                    datosTelefonoContacto.Adicionar(telefono);
        }
    }
}
