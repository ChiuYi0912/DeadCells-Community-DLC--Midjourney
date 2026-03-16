using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dc.en;
using HaxeProxy.Runtime;
using IngameDebugConsole;
using Midjourney.Entities.Mob;
using Midjourney.Entities.Mob.FlyMob;

namespace Midjourney.Entities
{
    public class DebugMobs
    {
        [ConsoleMethod("bess", "创建蜜蜂")]
        public static void BomberBeecreate(TextWriter writer)
        {
            Hero hero = ModCore.Modules.Game.Instance.HeroInstance!;
            _ = BomberBee.CreateBees(hero._level, hero.cx, hero.cy, 10, Ref<int>.In(100));
        }


        [ConsoleMethod("osty", "创建手")]
        public static void Ostycreate(TextWriter writer)
        {
            Hero hero = ModCore.Modules.Game.Instance.HeroInstance!;
            _ = Osty.CreateBees(hero._level, hero.cx, hero.cy, 10, Ref<int>.In(100));
        }
    }
}