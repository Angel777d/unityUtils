using System;
using System.Collections;
using System.Collections.Generic;
using ru.angelovich.flash_events;

namespace ru.angelovich.core
{
    public class Hub : FlashEventDispatcher
    {
        private readonly Dictionary<Type, ICollection> _items = new Dictionary<Type, ICollection>();

        public T Add<T>(T component)
        {
            GetCollection<T>().Add(component);
            Dispatch(new HubEvent<T>(HubEvent.Added, component));
            return component;
        }

        public T Remove<T>(T component)
        {
            GetCollection<T>().Remove(component);
            Dispatch(new HubEvent<T>(HubEvent.Removed, component));
            return component;
        }

        public List<T> GetCollection<T>()
        {
            var type = typeof(T);
            if (!_items.ContainsKey(type))
            {
                _items[type] = new List<T>();
            }
            return _items[type] as List<T>;
        }
    }

    public class HubEvent : FlashEvent
    {
        public const string Added = "HubEvent.Added";
        public const string Removed = "HubEvent.Removed";

        public HubEvent(string type) : base(type)
        {
        }
    }

    public class HubEvent<T> : HubEvent
    {
        public T component;
        public HubEvent(string type, T component) : base(type)
        {
            this.component = component;
        }
    }
}