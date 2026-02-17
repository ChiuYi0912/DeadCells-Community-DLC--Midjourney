using Midjourney.EntryPoint;
using ModCore.Events;

namespace Midjourney.Core.Interfaces
{
    [Event]
    public interface IOnHookInitialize
    {
        void HookInitialize(ModInitializer entry);
    }
}