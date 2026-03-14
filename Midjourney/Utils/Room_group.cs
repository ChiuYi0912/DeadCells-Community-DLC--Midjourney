using CoreLibrary.Core.Utilities;
using dc._Data;
using Midjourney.Core.Interfaces;
using Midjourney.EntryPoint;
using ModCore.Events;
using ModCore.Utilities;

namespace Midjourney.Utils
{
    public class RoomGroup :
    IEventReceiver,
    IOnHookInitialize
    {
        public readonly Serilog.ILogger GetLogger;
        public RoomGroup(ModInitializer entry)
        {
            GetLogger =entry.Logger;
            GetLogger.LogInformation("Room Group initialisation commences", "RoomGroup");
            EventSystem.AddReceiver(this);
        }
        void IOnHookInitialize.HookInitialize(ModInitializer entry)
        {
            var obj = Room_group_Impl_.Class.NAMES;
            obj.pushDyn("BackGarden".AsHaxeString());
        }
    }
}