using ModCore.Events;
using ModEntryLevelinit;

namespace Midjourney.Core.HookInitialize
{   
    [Event]
    public interface IOnHookInitialize
    {
        void HookInitialize(Levelinit entry);
    }
}