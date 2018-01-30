using System.Collections.Generic;
using ru.angelovich.flash_event;

namespace ru.angelovich.core
{
    public abstract class BaseSystem : ISystem
    {
        protected Hub Hub { get; private set; }

        protected IFlashEventDispatcher EventBus { get; private set; }

        public ISystem Init(Hub hub, IFlashEventDispatcher eventDispatcher)
        {
            Hub = hub;
            EventBus = eventDispatcher;
            BeforeInit();
            OnInit();
            return this;
        }

        public void Destroy()
        {
            OnDestroy();
            Hub = null;
            EventBus = null;
        }

        public virtual void Update()
        {
        }

        public virtual void FixedUpdate()
        {
        }

        public virtual void OnGUI()
        {
        }


        protected abstract void OnInit();
        protected abstract void OnDestroy();

        protected virtual void BeforeInit()
        {
        }
    }

    public abstract class BaseSystem<T> : BaseSystem
    {
        protected virtual void OnAdd(T component)
        {
        }

        protected virtual void OnRemove(T component)
        {
        }

        protected List<T> GetCollection()
        {
            return Hub.GetCollection<T>();
        }

        private void OnComponentAdded(FlashEvent ev)
        {
            var hubEv = ev as HubEvent<T>;
            if (hubEv != null)
            {
                OnAdd(hubEv.component);
            }
        }

        private void OnComponentRemoved(FlashEvent ev)
        {
            var hubEv = ev as HubEvent<T>;
            if (hubEv != null)
            {
                OnRemove(hubEv.component);
            }
        }

        protected override void BeforeInit()
        {
            //TODO: move to Core - avoid system type selection
            Hub.AddEventListener(HubEvent.Added, OnComponentAdded);
            Hub.AddEventListener(HubEvent.Removed, OnComponentRemoved);
        }
    }
}