namespace aDVanceERP.Core.Datos.Interfaces; 

public interface IConfServidorMySQL {
    string Servidor { get; set; }
    string BaseDatos { get; set; }
    string Usuario { get; set; }
    string Password { get; set; }
}