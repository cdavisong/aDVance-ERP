using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios {
    public class DatosPago : RepositorioDatosBase<Pago, CriterioBusquedaPago>, IRepositorioPago {
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_pago) FROM adv__pago;";
        }

        public override string ComandoAdicionar(Pago objeto) {
            return $"INSERT INTO adv__pago (id_venta, metodo_pago, monto) VALUES ({objeto.IdVenta}, '{objeto.MetodoPago}', {objeto.Monto});";
        }

        public override string ComandoEditar(Pago objeto) {
            return $"UPDATE adv__pago SET id_venta={objeto.IdVenta}, metodo_pago='{objeto.MetodoPago}', monto={objeto.Monto} WHERE id_pago={objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM adv__pago WHERE id_pago={id};";
        }

        public override string ComandoObtener(CriterioBusquedaPago criterio, string dato) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaPago.Id:
                    comando = $"SELECT * FROM adv__pago WHERE id_pago={dato};";
                    break;
                case CriterioBusquedaPago.IdVenta:
                    comando = $"SELECT * FROM adv__pago WHERE id_venta={dato};";
                    break;
                default:
                    comando = "SELECT * FROM adv__pago;";
                    break;
            }

            return comando;
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT COUNT(1) FROM adv__pago WHERE id_pago = {dato};";
        }

        public override Pago ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new Pago(
                id: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_pago")),
                idVenta: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_venta")),
                metodoPago: lectorDatos.GetString(lectorDatos.GetOrdinal("metodo_pago")),
                monto: lectorDatos.GetFloat(lectorDatos.GetOrdinal("monto"))
            );
        }
    }
}
