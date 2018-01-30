using System.Collections.Generic;
using ru.angelovich.flash_event;

namespace ru.angelovich.core
{
    public class GameCore
    {
        public Hub Hub { get; private set; }

        public FlashEventDispatcher Bus { get; private set; }

        private readonly List<ISystem> _systems = new List<ISystem>();

        public GameCore(Hub hub, FlashEventDispatcher bus)
        {
            Hub = hub;
            Bus = bus;
        }

        public void AddSystem(ISystem system)
        {
            _systems.Add(system);
            system.Init(Hub, Bus);
        }

        public void RemoveSystem<T>()
        {
            foreach (var system in _systems)
            {
                if (system.GetType() == typeof(T))
                {
                    _systems.Remove(system);
                    break;
                }
            }
        }

        public void Update()
        {
            foreach (var system in _systems)
            {
                system.Update();
            }
        }
    
        public void OnGui()
        {
            foreach (var system in _systems)
            {
                system.OnGUI();
            }
        }
    
        public void FixedUpdate()
        {
            foreach (var system in _systems)
            {
                system.FixedUpdate();
            }
        }
    }
}