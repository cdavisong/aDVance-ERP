using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Core.Eventos {
    public class EventoEntidadActualizada<En> : EventoBase
        where En : class, IEntidad, new() {
        public EventoEntidadActualizada(En entidadActualizada) {
            EntidadActualizada = entidadActualizada;
        }

        public En EntidadActualizada { get; }
    }
}