using dc;
using dc.level;
using dc.libs;
using dc.pr;
using Hashlink.Virtuals;
using HaxeProxy.Runtime;
using ModCore.Utilities;
using Midjourney.Core.Interfaces;
using Serilog;
using Utils.Config;
using BackGarden.Struct;
using BackGarden.GardenDisp;

namespace BackGarden
{
    public class BackGardenLevel : ILevel
    {
        public static ModCore.Storage.Config<BaGaConfig> _config { get; } = new("BaGaConfig");
        public BackGardenLevel()
        {
        }

        public string LevelId => _config.Value.LevelId;

        public string DisplayName => _config.Value.DisplayName;

        public string Biome => _config.Value.Biome;

        public string dynamicBiome => _config.Value.Biome2;


        public LevelStruct CreateLevelStruct(User user, virtual_baseLootLevel_biome_bonusTripleScrollAfterBC_cellBonus_dlc_doubleUps_eliteRoomChance_eliteWanderChance_flagsProps_group_icon_id_index_loreDescriptions_mapDepth_minGold_mobDensity_mobs_name_nextLevels_parallax_props_quarterUpsBC3_quarterUpsBC4_specificLoots_specificSubBiome_transitionTo_tripleUps_worldDepth_ levelData, Rand rng)
        {
            return new GardenStruct(user, levelData, rng);
        }


        public dc.level.LevelDisp CreateLevelDisplay(dc.pr.Level level, dc.level.LevelMap map)
        {
            return InitializeGardenDisp.createGardenDisp(level, map);
        }


        public void InitializeLevel(dc.pr.Level level)
        {
        }

        public object GetConfig()
        {
            return _config;
        }

        public void RegisterHooks()
        {

        }

        public void UnregisterHooks()
        {

        }
    }
}