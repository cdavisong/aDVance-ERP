using aDVanceERP.Core.Eventos.Interfaces;

namespace aDVanceERP.Core.Eventos {
    public class AgregadorEventos : IAgregadorEventos {
        private readonly Dictionary<Type, List<Delegate>> _handlers = new();

        public void Suscribir<TEvento>(Action<TEvento> handler) where TEvento : EventoBase {
            if (!_handlers.ContainsKey(typeof(TEvento))) {
                _handlers[typeof(TEvento)] = new List<Delegate>();
            }

            _handlers[typeof(TEvento)].Add(handler);
        }
        public void Desuscribir<TEvento>(Action<TEvento> handler) where TEvento : EventoBase {
            if (_handlers.TryGetValue(typeof(TEvento), out var handlers)) {
                handlers.Remove(handler);
            }
        }

        public void Publicar<TEvento>(TEvento @event) where TEvento : EventoBase {
            if (_handlers.TryGetValue(typeof(TEvento), out var handlers)) {
                foreach (var handler in handlers.ToList()) {
                    ((Action<TEvento>) handler)(@event);
                }
            }
        }
    }
}