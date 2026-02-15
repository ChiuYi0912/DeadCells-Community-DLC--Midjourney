using ModCore.Events;
using ModEntryLevelinit;

namespace Midjourney.Core.Interfaces
{
    [Event]
    public interface IOnHookInitialize
    {
        void HookInitialize(Levelinit entry);
    }
}