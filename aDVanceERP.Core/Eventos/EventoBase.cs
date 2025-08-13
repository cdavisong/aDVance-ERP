namespace aDVanceERP.Core.Eventos;

public abstract class EventoBase {
    public DateTime MarcaTiempo { get; } = DateTime.Now;
}
