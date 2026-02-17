using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dc.en;
using IngameDebugConsole;
using Midjourney.Core.Utilities;
using ModCore.Modules;

namespace Midjourney.Core.Extensions
{
    public static class DebugConsoleExtensions
    {
        [ConsoleMethod("remove-all-mobs", "移除所有怪物")]
        public static void RemoveAllMob(TextWriter writer)
        {
            Hero hero = Game.Instance.HeroInstance!;
            ValidationHelper.NotNull(hero, nameof(hero));
            Game.Instance.HeroInstance!._level.RemoveAllMobsSafe();
        }
    }
}