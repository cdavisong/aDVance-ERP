using Manigest.Core.MVP.Modelos.Repositorios;
using Manigest.Modulos.Inventario.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace Manigest.Modulos.Inventario.MVP.Modelos.Repositorios {
    public class DatosMovimiento : RepositorioDatosBase<Movimiento, CriterioBusquedaMovimiento>, IRepositorioMovimiento {
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_movimiento) FROM mg__movimiento;";
        }

        public override string ComandoAdicionar(Movimiento objeto) {
            return $"INSERT INTO mg__movimiento (id_articulo, id_almacen_origen, id_almacen_destino, cantidad_inicial, cantidad_movida, cantidad_final, motivo, fecha) VALUES ('{objeto.IdArticulo}', '{objeto.IdAlmacenOrigen}', '{objeto.IdAlmacenDestino}', '{objeto.CantidadInicial}', '{objeto.CantidadMovida}', '{objeto.CantidadFinal}', '{objeto.Motivo}', '{objeto.Fecha:yyyy-MM-dd HH:mm:ss}');";
        }

        public override string ComandoEditar(Movimiento objeto) {
            return $"UPDATE mg__movimiento SET id_articulo='{objeto.IdArticulo}', id_almacen_origen='{objeto.IdAlmacenOrigen}', id_almacen_destino='{objeto.IdAlmacenDestino}', cantidad_inicial='{objeto.CantidadInicial}', cantidad_movida='{objeto.CantidadMovida}', cantidad_final='{objeto.CantidadFinal}', motivo='{objeto.Motivo}', fecha='{objeto.Fecha:yyyy-MM-dd HH:mm:ss}' WHERE id_movimiento='{objeto.Id}';";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM mg__movimiento WHERE id_movimiento='{id}';";
        }

        public override string ComandoObtener(CriterioBusquedaMovimiento criterio, string dato) {
            string? comando;

            switch (criterio) {
                case CriterioBusquedaMovimiento.Id:
                    comando = $"SELECT * FROM mg__movimiento WHERE id_movimiento='{dato}';";
                    break;
                case CriterioBusquedaMovimiento.Articulo:
                    comando = $"SELECT * FROM mg__movimiento WHERE id_articulo='{dato}';";
                    break;
                case CriterioBusquedaMovimiento.AlmacenOrigen:
                    comando = $"SELECT * FROM mg__movimiento WHERE id_almacen_origen='{dato}';";
                    break;
                case CriterioBusquedaMovimiento.AlmacenDestino:
                    comando = $"SELECT * FROM mg__movimiento WHERE id_almacen_destino='{dato}';";
                    break;
                case CriterioBusquedaMovimiento.Fecha:
                    comando = $"SELECT * FROM mg__movimiento WHERE DATE(fecha)='{dato}';";
                    break;
                case CriterioBusquedaMovimiento.Motivo:
                    comando = $"SELECT * FROM mg__movimiento WHERE motivo='{dato}';";
                    break;
                default:
                    comando = "SELECT * FROM mg__movimiento;";
                    break;
            }

            return comando;
        }

        public override Movimiento ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new Movimiento(
                id: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_movimiento")),
                idArticulo: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_articulo")),
                idAlmacenOrigen: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_almacen_origen")),
                idAlmacenDestino: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_almacen_destino")),
                cantidadInicial: lectorDatos.GetInt32(lectorDatos.GetOrdinal("cantidad_inicial")),
                cantidadMovida: lectorDatos.GetInt32(lectorDatos.GetOrdinal("cantidad_movida")),
                cantidadFinal: lectorDatos.GetInt32(lectorDatos.GetOrdinal("cantidad_final")),
                motivo: Enum.Parse<MotivoMovimiento>(lectorDatos.GetString(lectorDatos.GetOrdinal("motivo"))),
                fecha: lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha"))
            );
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT COUNT(1) FROM mg__movimiento WHERE id_movimiento='{dato}';";
        }
    }
}
