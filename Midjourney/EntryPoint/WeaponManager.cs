
using CoreLibrary.Core.Interfaces;
using CoreLibrary.Core.Utilities;
using ModCore.Events;

namespace Midjourney.EntryPoint
{
    public class WeaponManager :
    IEventReceiver,
    IOnHookInitialize
    {
        public readonly Serilog.ILogger GetLogger;
        public WeaponManager(ModInitializer entry)
        {
            GetLogger =entry.Logger;
            GetLogger.LogInformation("Weapon Manager initialisation commences", "WeaponManager");
            EventSystem.AddReceiver(this);
        }

        void IOnHookInitialize.HookInitialize()
        {

        }
    }
}