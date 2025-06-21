using System.Globalization;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios; 

public class DatosPago : RepositorioDatosEntidadBase<Pago, CriterioBusquedaPago>, IRepositorioPago {
    public override string ComandoCantidad() {
        return "SELECT COUNT(id_pago) FROM adv__pago;";
    }

    public override string ComandoAdicionar(Pago objeto) {
        return $"INSERT INTO adv__pago (id_venta, metodo_pago, monto, fecha_confirmacion, estado) VALUES ({objeto.IdVenta}, '{objeto.MetodoPago}', {objeto.Monto.ToString(CultureInfo.InvariantCulture)}, '{objeto.FechaConfirmacion:yyyy-MM-dd HH:mm:ss}', '{objeto.Estado}');";
    }

    public override string ComandoEditar(Pago objeto) {
        return $"UPDATE adv__pago SET id_venta={objeto.IdVenta}, metodo_pago='{objeto.MetodoPago}', monto={objeto.Monto.ToString(CultureInfo.InvariantCulture)}, fecha_confirmacion='{objeto.FechaConfirmacion:yyyy-MM-dd HH:mm:ss}', estado='{objeto.Estado}' WHERE id_pago={objeto.Id};";
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

    public override Pago MapearEntidad(MySqlDataReader lectorDatos) {
        return new Pago(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_pago")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_venta")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("metodo_pago")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("monto"))
        ) {
            FechaConfirmacion = lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_confirmacion")),
            Estado = lectorDatos.GetString(lectorDatos.GetOrdinal("estado"))
        };
    }
}