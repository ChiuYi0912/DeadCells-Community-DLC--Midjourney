using dc;
using dc.level;
using dc.libs;
using dc.pr;
using Hashlink.Virtuals;
using HaxeProxy.Runtime;
using ModCore.Utilities;
using Midjourney.Core.Interfaces;
using Serilog;
using Midjourney.Utils;
using Midjourney.Levels.Struct;
using Midjourney.Levels.Disp;

namespace Midjourney.Levels.BackGarden
{
    public class BackGardenLevel : ILevel
    {
        public static ModCore.Storage.Config<BackGardenConfig> Config { get; } = new("BackGardenConfig");
        public BackGardenLevel()
        {
        }

        public string LevelId => Config.Value.LevelId;

        public string DisplayName => Config.Value.DisplayName;

        public string Biome => Config.Value.Biome;

        public string DynamicBiome => Config.Value.Biome2;


        public LevelStruct CreateLevelStruct(User user, virtual_baseLootLevel_biome_bonusTripleScrollAfterBC_cellBonus_dlc_doubleUps_eliteRoomChance_eliteWanderChance_flagsProps_group_icon_id_index_loreDescriptions_mapDepth_minGold_mobDensity_mobs_name_nextLevels_parallax_props_quarterUpsBC3_quarterUpsBC4_specificLoots_specificSubBiome_transitionTo_tripleUps_worldDepth_ levelData, Rand rng)
        {
            return new GardenStruct(user, levelData, rng);
        }


        public dc.level.LevelDisp CreateLevelDisplay(dc.pr.Level level, dc.level.LevelMap map)
        {
            return InitializeGardenDisp.CreateGardenDisp(level, map, this.Biome);
        }


        public void InitializeLevel(dc.pr.Level level)
        {
        }

        public object GetConfig()
        {
            return Config;
        }

        public void RegisterHooks()
        {

        }

        public void UnregisterHooks()
        {

        }
    }
}