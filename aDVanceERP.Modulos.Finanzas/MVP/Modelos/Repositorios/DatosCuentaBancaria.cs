using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios {
    public class DatosCuentaBancaria : RepositorioDatosBase<CuentaBancaria, CriterioBusquedaCuentaBancaria>, IRepositorioCuentaBancaria {
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_cuenta_bancaria) FROM adv__cuenta_bancaria;";
        }

        public override string ComandoAdicionar(CuentaBancaria objeto) {
            return $"INSERT INTO adv__cuenta_bancaria (alias, numero_tarjeta, moneda, id_contacto) VALUES ('{objeto.Alias}', '{objeto.NumeroTarjeta}', {(int) objeto.Moneda}, {objeto.IdContacto});";
        }

        public override string ComandoEditar(CuentaBancaria objeto) {
            return $"UPDATE adv__cuenta_bancaria SET alias='{objeto.Alias}', numero_tarjeta='{objeto.NumeroTarjeta}', moneda={(int) objeto.Moneda}, id_contacto={objeto.IdContacto} WHERE id_cuenta_bancaria={objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM adv__cuenta_bancaria WHERE id_cuenta_bancaria={id};";
        }

        public override string ComandoObtener(CriterioBusquedaCuentaBancaria criterio, string dato) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaCuentaBancaria.Id:
                    comando = $"SELECT * FROM adv__cuenta_bancaria WHERE id_cuenta_bancaria={dato};";
                    break;
                case CriterioBusquedaCuentaBancaria.Alias:
                    comando = $"SELECT * FROM adv__cuenta_bancaria WHERE alias LIKE '%{dato}%';";
                    break;
                default:
                    comando = "SELECT * FROM adv__cuenta_bancaria;";
                    break;
            }

            return comando;
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT COUNT(1) FROM adv__cuenta_bancaria WHERE id_cuenta_bancaria = {dato};";
        }

        public override CuentaBancaria ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new CuentaBancaria(
                id: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_cuenta_bancaria")),
                alias: lectorDatos.GetString(lectorDatos.GetOrdinal("alias")),
                numeroTarjeta: lectorDatos.GetString(lectorDatos.GetOrdinal("numero_tarjeta")),
                moneda: (TipoMoneda) lectorDatos.GetInt32(lectorDatos.GetOrdinal("moneda")),
                idContacto: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_contacto"))
            );
        }
    }
}
