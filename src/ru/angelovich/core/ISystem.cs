using ru.angelovich.flash_event;

namespace ru.angelovich.core
{
    public interface ISystem
    {
        ISystem Init(Hub hub, IFlashEventDispatcher eventBus);
        void Destroy();
        void Update();
        void FixedUpdate();
        void OnGUI();
    }
}