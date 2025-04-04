using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios; 

public class DatosSeguimientoEntrega : RepositorioDatosBase<SeguimientoEntrega, CriterioBusquedaSeguimientoEntrega>, IRepositorioSeguimientoEntrega {
    public override string ComandoCantidad() {
        return "SELECT COUNT(*) FROM adv__seguimiento_entrega";
    }

    public override string ComandoAdicionar(SeguimientoEntrega objeto) {
        return $"INSERT INTO adv__seguimiento_entrega (id_venta, id_mensajero, fecha_asignacion, fecha_entrega, fecha_pago, observaciones) VALUES ({objeto.IdVenta}, {objeto.IdMensajero}, '{objeto.FechaAsignacion:yyyy-MM-dd HH:mm:ss}', '{objeto.FechaEntrega:yyyy-MM-dd HH:mm:ss}', '{objeto.FechaPago:yyyy-MM-dd HH:mm:ss}', '{objeto.Observaciones}')";
    }

    public override string ComandoEditar(SeguimientoEntrega objeto) {
        return $"UPDATE adv__seguimiento_entrega SET id_venta = {objeto.IdVenta}, id_mensajero = {objeto.IdMensajero}, fecha_asignacion = '{objeto.FechaAsignacion:yyyy-MM-dd HH:mm:ss}', fecha_entrega = '{objeto.FechaEntrega:yyyy-MM-dd HH:mm:ss}', fecha_pago = '{objeto.FechaPago:yyyy-MM-dd HH:mm:ss}', observaciones = '{objeto.Observaciones}' WHERE id_seguimiento_entrega = {objeto.Id}";
    }

    public override string ComandoEliminar(long id) {
        return $"DELETE FROM adv__seguimiento_entrega WHERE id_seguimiento_entrega = {id}";
    }

    public override string ComandoObtener(CriterioBusquedaSeguimientoEntrega criterio, string dato) {
        var comando = string.Empty;

        switch (criterio) {
            case CriterioBusquedaSeguimientoEntrega.Id:
                comando = $"SELECT * FROM adv__seguimiento_entrega WHERE id_seguimiento_entrega = {dato}";
                break;
            case CriterioBusquedaSeguimientoEntrega.IdVenta:
                comando = $"SELECT * FROM adv__seguimiento_entrega WHERE id_venta = {dato}";
                break;
            case CriterioBusquedaSeguimientoEntrega.NombreMensajero:
                comando = $"SELECT se.* FROM adv__seguimiento_entrega se JOIN adv__mensajero m ON se.id_mensajero = m.id_mensajero WHERE m.nombre = {dato}";
                break;
            case CriterioBusquedaSeguimientoEntrega.FechaAsignacion:
                comando = $"SELECT * FROM adv__seguimiento_entrega WHERE DATE(fecha_asignacion) = {dato}";
                break;
            case CriterioBusquedaSeguimientoEntrega.FechaEntrega:
                comando = $"SELECT * FROM adv__seguimiento_entrega WHERE DATE(fecha_entrega) = {dato}";
                break;
            case CriterioBusquedaSeguimientoEntrega.FechaConfirmacion:
                comando = $"SELECT * FROM adv__seguimiento_entrega WHERE DATE(fecha_confirmacion) = {dato}";
                break;
            case CriterioBusquedaSeguimientoEntrega.FechaPago:
                comando = $"SELECT * FROM adv__seguimiento_entrega WHERE DATE(fecha_pago) = {dato}";
                break;
            default:
                comando = "SELECT * FROM adv__detalle_compra_articulo;";
                break;
        }

        return comando;
    }

    public override SeguimientoEntrega ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new SeguimientoEntrega( 
                id: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_seguimiento_entrega")),
                idVenta: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_venta")),
                idMensajero: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_mensajero")),
                fechaAsignacion: lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_asignacion")),
                fechaEntrega: lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_entrega")),
                fechaPago: lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_pago")),
                observaciones: lectorDatos.GetString(lectorDatos.GetOrdinal("observaciones"))
            );
    }

    public override string ComandoExiste(string dato) {
        return $"SELECT COUNT(*) FROM adv__seguimiento_entrega WHERE id_seguimiento_entrega = {dato}";
    }
}