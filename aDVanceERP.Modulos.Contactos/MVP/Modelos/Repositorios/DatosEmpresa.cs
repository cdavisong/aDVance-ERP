using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios {
    public class DatosEmpresa : RepositorioDatosEntidadBase<Empresa, CriterioBusquedaEmpresa>, IRepositorioEmpresa {
        public override string ComandoCantidad() {
            return """
                SELECT COUNT(id_empresa) 
                FROM adv__empresa;
                """;
        }

        public override string ComandoAdicionar(Empresa objeto) {
            return $"""
                INSERT INTO adv__empresa (
                    nombre,
                    logotipo,
                    id_contacto) 
                VALUES (
                    @nombre,
                    @logotipo,
                    @idContacto);
                """;
        }

        public override long Insertar(Empresa objeto) {
            var logoBytes = objeto.ObtenerDatosDbLogotipo();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                conexion.Open();

                using (var comando = new MySqlCommand(ComandoAdicionar(objeto), conexion)) {
                    comando.Parameters.AddWithValue("@nombre", objeto.Nombre);
                    comando.Parameters.Add("@logotipo", MySqlDbType.LongBlob).Value = logoBytes.Length > 0 ? logoBytes : DBNull.Value;
                    comando.Parameters.AddWithValue("@idContacto", objeto.IdContacto);

                    comando.ExecuteNonQuery();

                    return comando.LastInsertedId;
                }
            }
        }

        public override async Task<long> AdicionarAsync(Empresa objeto) {
            var logoBytes = objeto.ObtenerDatosDbLogotipo();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                await conexion.OpenAsync().ConfigureAwait(false);

                using (var comando = new MySqlCommand(ComandoAdicionar(objeto), conexion)) {
                    comando.Parameters.AddWithValue("@nombre", objeto.Nombre);
                    comando.Parameters.Add("@logotipo", MySqlDbType.LongBlob).Value = logoBytes.Length > 0 ? logoBytes : DBNull.Value;
                    comando.Parameters.AddWithValue("@idContacto", objeto.IdContacto);

                    await comando.ExecuteNonQueryAsync().ConfigureAwait(false);

                    return comando.LastInsertedId;
                }
            }
        }

        public override string ComandoEditar(Empresa objeto) {
            return $"""
                UPDATE adv__empresa
                SET
                    nombre = @nombre,
                    logotipo = @logotipo,
                    id_contacto = @idContacto
                WHERE id_empresa = {objeto.Id};
                """;
        }

        public override bool Actualizar(Empresa objeto, long nuevoId = 0) {
            var logoBytes = objeto.ObtenerDatosDbLogotipo();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                conexion.Open();

                using (var comando = new MySqlCommand(ComandoEditar(objeto), conexion)) {
                    comando.Parameters.AddWithValue("@nombre", objeto.Nombre);
                    comando.Parameters.Add("@logotipo", MySqlDbType.LongBlob).Value = logoBytes.Length > 0 ? logoBytes : DBNull.Value;
                    comando.Parameters.AddWithValue("@idContacto", objeto.IdContacto);

                    comando.ExecuteNonQuery();

                    return true;
                }
            }
        }

        public override async Task<bool> EditarAsync(Empresa objeto, long nuevoId = 0) {
            var logoBytes = objeto.ObtenerDatosDbLogotipo();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                await conexion.OpenAsync().ConfigureAwait(false);

                using (var comando = new MySqlCommand(ComandoEditar(objeto), conexion)) {
                    comando.Parameters.AddWithValue("@nombre", objeto.Nombre);
                    comando.Parameters.Add("@logotipo", MySqlDbType.LongBlob).Value = logoBytes.Length > 0 ? logoBytes : DBNull.Value;
                    comando.Parameters.AddWithValue("@idContacto", objeto.IdContacto);

                    await comando.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }

            return true;
        }

        public override string ComandoEliminar(long id) {
            return $"""
                DELETE FROM adv__empresa 
                WHERE id_empresa = {id};
                """;
        }

        public override string ComandoObtener(CriterioBusquedaEmpresa criterio, string dato) {
            string? comando;

            switch (criterio) {
                case CriterioBusquedaEmpresa.Id:
                    comando = $"SELECT * FROM adv__empresa WHERE id_empresa='{dato}';";
                    break;
                case CriterioBusquedaEmpresa.Nombre:
                    comando = $"SELECT * FROM adv__empresa WHERE LOWER(nombre) LIKE LOWER('%{dato}%');";
                    break;
                default:
                    comando = "SELECT * FROM adv__empresa;";
                    break;
            }

            return comando;
        }

        public override Empresa MapearEntidad(MySqlDataReader lectorDatos) {
            var empresa = new Empresa(
                lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_empresa")),
                null,
                lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
                long.TryParse(lectorDatos.GetValue(lectorDatos.GetOrdinal("id_contacto")).ToString(), out var idContacto)
                    ? idContacto
                    : 0
            );

            if (!lectorDatos.IsDBNull(lectorDatos.GetOrdinal("logotipo"))) {
                var bytesImagen = (byte[]) lectorDatos["logotipo"];

                if (!EsImagenValida(bytesImagen)) {
                    System.Diagnostics.Debug.WriteLine("Advertencia: Datos de imagen no válidos en BD");
                    bytesImagen = Array.Empty<byte>();
                }

                empresa.EstablecerLogotipoDesdeBytes(bytesImagen);
            }

            return empresa;
        }

        private bool EsImagenValida(byte[] bytes) {
            try {
                using (var ms = new MemoryStream(bytes)) {
                    // Intenta leer solo los primeros bytes para verificar el formato
                    var header = new byte[8];
                    ms.Read(header, 0, 8);

                    // Verificar firmas de formatos comunes
                    if (header.Take(8).SequenceEqual(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A })) // PNG
                        return true;
                    if (header.Take(2).SequenceEqual(new byte[] { 0xFF, 0xD8 })) // JPEG
                        return true;
                }
                return false;
            } catch {
                return false;
            }
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT * FROM adv__empresa WHERE nombre='{dato}';";
        }
    }
}
