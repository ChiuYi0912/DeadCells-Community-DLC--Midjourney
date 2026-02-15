using dc;
using dc.hl.types;
using dc.level;
using dc.libs;
using Hashlink.Virtuals;
using HaxeProxy.Runtime;
using Microsoft.VisualBasic;
using ModCore.Utilities;
using Serilog;

namespace BackGarden.Struct
{
    public class GardenStruct : LevelStruct
    {
        public GardenStruct(User user, virtual_baseLootLevel_biome_bonusTripleScrollAfterBC_cellBonus_dlc_doubleUps_eliteRoomChance_eliteWanderChance_flagsProps_group_icon_id_index_loreDescriptions_mapDepth_minGold_mobDensity_mobs_name_nextLevels_parallax_props_quarterUpsBC3_quarterUpsBC4_specificLoots_specificSubBiome_transitionTo_tripleUps_worldDepth_ level, Rand rng) : base(user, level, rng)
        {
        }


        public override RoomNode buildMainRooms()
        {
            #region 入口
            RoomNode entranceNode = base.createNode(null, "BasicEntrance_R".AsHaxeString(), null, "start".AsHaxeString());
            entranceNode.addFlag(new RoomFlag.NoExitSizeCheck());
            entranceNode.addNpc(new NpcId.PlagueDoctor());
            entranceNode.addFlag(new RoomFlag.Outside());


            virtual_specificBiome_ virtual_add = new virtual_specificBiome_();
            virtual_add.specificBiome = "BackGarden".AsHaxeString(); ;
            var clockTowerGenData = virtual_add.ToVirtual<virtual_altarItemGroup_brLegendaryMultiTreasure_broken_cells_doorCost_doorCurse_flaskRefill_forcedMerchantType_forcePauseTimer_isCliffPath_itemInWall_itemLevelBonus_killsMultiTreasure_locked_maxPerks_mins_noHealingShop_shouldBeFlipped_specificBiome_subTeleportTo_timedMultiTreasure_zDoorLock_zDoorType_>();
            entranceNode.addGenData(clockTowerGenData);
            #endregion

            RoomNode roomNode = base.createNode(null, "LabArt".AsHaxeString(), null, "lab".AsHaxeString());
            roomNode.set_parent(entranceNode);
            roomNode.addFlag(new RoomFlag.Outside());

            RoomNode roomNode3 = base.createExit("LabArt".AsHaxeString(), null, null, "exit".AsHaxeString()).set_parent(roomNode);
            Log.Debug($"{base.all.array}");
            return base.nodes.get("start".AsHaxeString());

        }

    }
}