using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Core.Modelos.BD; 

public class ConfBd : IEntidad {
    public string? Servidor { get; set; }
    public string? BaseDatos { get; set; }
    public string? Usuario { get; set; }
    public string? Password { get; set; }
    public bool RecordarConfiguracion { get; set; }
}