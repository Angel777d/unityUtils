using System;
using System.Collections.Generic;

namespace ru.angelovich.flash_events
{
    public class FlashEventDispatcher : IFlashEventDispatcher
    {
        private readonly Dictionary<string, List<Action<FlashEvent>>> _callbacks = new Dictionary<string, List<Action<FlashEvent>>>();

        public void AddEventListener(string type, Action<FlashEvent> callback)
        {
            GetCallbackList(type).Add(callback);
        }

        public void RemoveEventListener(string type, Action<FlashEvent> callback)
        {
            GetCallbackList(type).Remove(callback);
        }

        public void Dispatch(FlashEvent ev)
        {
            foreach (var func in GetCallbackList(ev.Type))
            {
                func(ev);
            }
        }

        private List<Action<FlashEvent>> GetCallbackList(string type)
        {
            if (!_callbacks.ContainsKey(type))
            {
                _callbacks[type] = new List<Action<FlashEvent>>();
            }
            return _callbacks[type];
        }
    }
}