using Midjourney.Core.Interfaces;
using Midjourney.Core.Utilities;
using ModCore.Events;

namespace Midjourney.EntryPoint
{
    public class WeaponManager :
    IEventReceiver,
    IOnHookInitialize
    {
        public WeaponManager(ModInitializer entry)
        {
            entry.Logger.LogInformation("Weapon Manager initialisation commences", "WeaponManager");
            EventSystem.AddReceiver(this);
        }

        void IOnHookInitialize.HookInitialize(ModInitializer entry)
        {

        }
    }
}