using System;

namespace ru.angelovich.flash_events
{
    public interface IFlashEventDispatcher
    {
        void AddEventListener(string type, Action<FlashEvent> callback);
        void RemoveEventListener(string type, Action<FlashEvent> callback);

        void Dispatch(FlashEvent ev);
    }
}