using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLibrary.Core.Extensions;
using CoreLibrary.Core.Interfaces;
using CoreLibrary.Core.Utilities;
using dc.en;
using dc.pr;
using HaxeProxy.Runtime;
using Midjourney.Entities;
using Midjourney.Entities.Mob;
using Midjourney.Entities.Mob.FlyMob;
using ModCore.Events;

namespace Midjourney.EntryPoint
{
    public class EntityManager :
    IEventReceiver,
    IOnHookInitialize
    {
        public static Serilog.ILogger GetLogger = null!;
        public EntityManager(ModInitializer entry)
        {
            GetLogger = entry.Logger;
            GetLogger.LogInformation("Entity Manager initialisation commences");
            EventSystem.AddReceiver(this);
        }

        void IOnHookInitialize.HookInitialize()
        {
            dc.en.Hook__Mob.create += Hook__Mob_create;
        }

        private Mob Hook__Mob_create(Hook__Mob.orig_create orig, dc.String k, Level level, int cx, int cy, int dmgTier, Ref<int> lifeTier)
        {
            if (k.ToString().EqualsIgnoreCase(EntitiesConstants.MOBs.FlyMob.Bees.id))
                return BomberBee.CreateBees(level, cx, cy, dmgTier, lifeTier);
                
            return orig(k, level, cx, cy, dmgTier, lifeTier);
        }
    }
}