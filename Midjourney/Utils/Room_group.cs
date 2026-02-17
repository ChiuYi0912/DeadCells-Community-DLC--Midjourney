using System.Security.Cryptography.X509Certificates;
using dc._Data;
using dc.hl.types;
using Midjourney.Core.Extensions;
using Midjourney.Core.Interfaces;
using Midjourney.Core.Utilities;
using Midjourney.EntryPoint;
using ModCore.Events;
using ModCore.Utilities;

namespace Midjourney.Utils
{
    public class RoomGroup :
    IEventReceiver,
    IOnHookInitialize
    {
        public RoomGroup(ModInitializer entry)
        {
            entry.Logger.LogInformation("Room Group initialisation commences", "RoomGroup");
            EventSystem.AddReceiver(this);

        }
        void IOnHookInitialize.HookInitialize(ModInitializer entry)
        {
            var obj = Room_group_Impl_.Class.NAMES;
            obj.pushDyn("BackGarden".AsHaxeString());
        }
    }
}