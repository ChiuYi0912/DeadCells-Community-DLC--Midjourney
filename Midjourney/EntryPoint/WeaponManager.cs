using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Midjourney.Core.Interfaces;
using ModCore.Events;

namespace Midjourney.EntryPoint
{
    public class WeaponManager:
    IEventReceiver,
    IOnHookInitialize
    {
        public WeaponManager(ModInitializer entry)
        {
            EventSystem.AddReceiver(this);
            entry.Logger.Information("\x1b[34m Weapon Manager Loading]\x1b[0m");
        }

        void IOnHookInitialize.HookInitialize(ModInitializer entry)
        {
            
        }
    }
}