using System.Security.Cryptography.X509Certificates;
using dc._Data;
using dc.hl.types;
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
        public RoomGroup(ModInitializer entry)
        {
            EventSystem.AddReceiver(this);
            entry.Logger.Information("\x1b[34m Room Group Loading]\x1b[0m");
        }
        void IOnHookInitialize.HookInitialize(ModInitializer entry)
        {
            var obj = Room_group_Impl_.Class.NAMES;
            obj.pushDyn("BackGarden".AsHaxeString());
        }
    }
}