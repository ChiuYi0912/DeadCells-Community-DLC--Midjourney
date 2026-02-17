using Hashlink.Virtuals;
using dc.level;
using ModCore.Utilities;
using dc.hl.types;
using dc;
using HaxeProxy.Runtime;
using dc.libs.heaps.slib;
using dc.h2d;
using Midjourney.Levels.Display;

namespace Midjourney.Levels.Disp
{
    public static class InitializeGardenDisp
    {
        public static dc.level.LevelDisp CreateGardenDisp(dc.pr.Level level, dc.level.LevelMap map ,string biome1)
        {
            virtual_blendAmbient_blendAmbientFog_blendCamDust_blendCamFog_blendGroundSmoke_blendLights_blendShadows_
            data = new virtual_blendAmbient_blendAmbientFog_blendCamDust_blendCamFog_blendGroundSmoke_blendLights_blendShadows_();
            data.blendLights = true;
            data.blendCamDust = true;
            data.blendCamFog = true;
            data.blendAmbientFog = false;
            data.blendAmbient = false;
            data.blendGroundSmoke = true;
            data.blendShadows = false;


            ArrayObj parallax = ((HaxeDynObj)Data.Class.level.byId.get(biome1.AsHaxeString())).ToVirtual<virtual_baseLootLevel_biome_bonusTripleScrollAfterBC_cellBonus_dlc_doubleUps_eliteRoomChance_eliteWanderChance_flagsProps_group_icon_id_index_loreDescriptions_mapDepth_minGold_mobDensity_mobs_name_nextLevels_parallax_props_quarterUpsBC3_quarterUpsBC4_specificLoots_specificSubBiome_transitionTo_tripleUps_worldDepth_>().parallax;

            ArrayObj array = (ArrayObj)ArrayUtils.CreateDyn().array;
            GardenDisp disp = new GardenDisp(level, map, biome1.AsHaxeString(), "Cliff_outside".AsHaxeString(), data, parallax);

            JunkMode junkMode = new JunkMode.OnlyInside();
            disp.junkMode = junkMode;
            disp.fxTorch = "fxTorchTurquoise".AsHaxeString();
            disp.fxCauldron = "fxTorchYellow".AsHaxeString();
            disp.fxBrasero = "fxTorchYellow".AsHaxeString();

            SpriteLib spriteLib = Assets.Class.tryGetAtlas(new DynamicLoadAtlas.LevelCandle());
            Tile tile = (dynamic)spriteLib.pages.array[0]!;

            disp.sbAddWalls = new HSpriteBatch(tile, null);
            disp.sbAddWalls.blendMode = new BlendMode.Alpha();
            disp.sbAddWalls.hasRotationScale = true;
            disp.level.scroller.addChildAt(disp.sbAddWalls, Const.Class.DP_ROOM_WALLS_FX);
            


            spriteLib = Assets.Class.tryGetAtlas(new DynamicLoadAtlas.LevelCandle());
            tile = (dynamic)spriteLib.pages.array[0]!;

            disp.sbAlcovesTorches = new HSpriteBatch(tile, null);
            disp.sbAlcovesTorches.blendMode = new BlendMode.Alpha();
            disp.sbAlcovesTorches.hasRotationScale = true;
            disp.level.scroller.addChildAt(disp.sbAlcovesTorches, Const.Class.DP_ROOM_WALLS_FX);

            return disp;
        }
    }
}