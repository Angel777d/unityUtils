namespace ru.angelovich.flash_event
{
    public class FlashEvent
    {
        public FlashEvent(string type)
        {
            Type = type;
        }

        public string Type;
        public IFlashEventDispatcher Target;
    }
}