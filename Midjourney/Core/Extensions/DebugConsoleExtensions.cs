using dc;
using dc.en;
using dc.hl.types;
using IngameDebugConsole;
using Midjourney.Core.Utilities;
using ModCore.Modules;

namespace Midjourney.Core.Extensions
{
    public static class DebugConsoleExtensions
    {
        private static List<Entity>? Entities;
        [ConsoleMethod("remove-all-mobs", "移除所有怪物")]
        public static void RemoveAllMob(TextWriter writer)
        {
            Hero hero = Game.Instance.HeroInstance!;
            ValidationHelper.NotNull(hero, nameof(hero));
            Entities = Game.Instance.HeroInstance!._level.RemoveAllMobsSafe();

        }

        [ConsoleMethod("show-removemobs", "显示所有移除的实体")]
        public static async Task ShowAllEntities(TextWriter writer)
        {
            if (Entities == null)
            {
                writer.WriteLine("没有可显示的实体");
                return;
            }
            ValidationHelper.NotNull(Entities, nameof(Entities));
            ArrayObj obj = Entities.ToArrayObj();
            await foreach (var entity in obj.AsEnumerableAsync())
            {
                writer.WriteLine($"实体: {entity}");
            }
        }

        [ConsoleMethod("show-port", "照亮所有传送门")]
        public static async Task ShowAllTeleports(TextWriter writer)
        {
            Hero hero = Game.Instance.HeroInstance!;
            if (hero == null)
            {
                writer.WriteLine("无法找到英雄实例");
                return;
            }
            ValidationHelper.NotNull(hero, nameof(hero));
            await hero._level.ShowTheTransmission();
        }
    }
}