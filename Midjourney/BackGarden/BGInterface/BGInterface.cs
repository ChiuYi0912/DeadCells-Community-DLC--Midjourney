using ModCore.Events;

namespace BackGarden.BGinterface.HookInitialize
{   
    [Event]
    public interface IOnHookInitialize
    {
        void HookInitialize(BackGardenEntry entry);
    }
}