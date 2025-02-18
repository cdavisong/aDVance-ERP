using Manigest.Core.MVP.Modelos.Repositorios;
using Manigest.Modulos.Finanzas.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace Manigest.Modulos.Finanzas.MVP.Modelos.Repositorios {
    public class DatosCuenta : RepositorioDatosBase<Cuenta, CriterioBusquedaCuenta>, IRepositorioCuenta {
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_cuenta) FROM mg__cuenta;";
        }

        public override string ComandoAdicionar(Cuenta objeto) {
            return $"INSERT INTO mg__cuenta (alias, numero_tarjeta, moneda, id_contacto) VALUES ('{objeto.Alias}', '{objeto.NumeroTarjeta}', {(int) objeto.Moneda}, {objeto.IdContacto});";
        }

        public override string ComandoEditar(Cuenta objeto) {
            return $"UPDATE mg__cuenta SET alias='{objeto.Alias}', numero_tarjeta='{objeto.NumeroTarjeta}', moneda={(int) objeto.Moneda}, id_contacto={objeto.IdContacto} WHERE id_cuenta={objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM mg__cuenta WHERE id_cuenta={id};";
        }

        public override string ComandoObtener(CriterioBusquedaCuenta criterio, string dato) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaCuenta.Id:
                    comando = $"SELECT * FROM mg__cuenta WHERE id_cuenta={dato};";
                    break;
                case CriterioBusquedaCuenta.Alias:
                    comando = $"SELECT * FROM mg__cuenta WHERE alias LIKE '%{dato}%';";
                    break;
                default:
                    comando = "SELECT * FROM mg__cuenta;";
                    break;
            }

            return comando;
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT COUNT(1) FROM mg__cuenta WHERE id_cuenta = {dato};";
        }

        public override Cuenta ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new Cuenta(
                id: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_cuenta")),
                alias: lectorDatos.GetString(lectorDatos.GetOrdinal("alias")),
                numeroTarjeta: lectorDatos.GetString(lectorDatos.GetOrdinal("numero_tarjeta")),
                moneda: (TipoMoneda) lectorDatos.GetInt32(lectorDatos.GetOrdinal("moneda")),
                idContacto: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_contacto"))
            );
        }
    }
}
