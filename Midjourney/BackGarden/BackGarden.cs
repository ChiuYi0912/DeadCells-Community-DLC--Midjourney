using dc;
using ModCore.Events;
using ModCore.Mods;
using BackGarden.BGinterface.HookInitialize;
using ModCore.Utilities;
using BackGarden.Utils.Lang;
using dc.level;
using ModCore.Events.Interfaces.Game;
using ModCore.Modules;
using dc.tool.mod;
using BackGarden.Information.Struct;
using Hashlink.Virtuals;
using dc.libs;
using dc.ui.hud;
using dc.h2d;
using Midjourney.Core.Interfaces;

namespace BackGarden;

public class BackGardenEntry :
    ModBase,
    IOnHookInitialize,
    IOnGameEndInit
{
    public BackGardenEntry(ModInfo info) : base(info)
    {
    }


    BackGardenLevel GetGardenLevel =new();

    public override void Initialize()
    {
        base.Initialize();

        BackGardenLang backGardenLang = new BackGardenLang(this);
        EventSystem.BroadcastEvent<IOnHookInitialize, BackGardenEntry>(this);
    }

    void IOnHookInitialize.HookInitialize(BackGardenEntry entry)
    {
        Hook__LevelStruct.get += Hook__LevelStruct_get;
        Hook_LevelLogos.getLevelLogo += Hook_LevelLogos_getLevelLogo;
    }

    private Tile Hook_LevelLogos_getLevelLogo(Hook_LevelLogos.orig_getLevelLogo orig, LevelLogos self, dc.String levelLogoCoordinate)
    {
        if (!self.textureCoordinateByLevelKind.exists.Invoke(levelLogoCoordinate))
        {
            return orig(self, "ClockTower".AsHaxeString());
        }
        else return orig(self, levelLogoCoordinate);
    }

    void IOnGameEndInit.OnGameEndInit()
    {
        var res = Info.ModRoot!.GetFilePath("res.pak");
        FsPak.Instance.FileSystem.loadPak(res.AsHaxeString());
        var json = CDBManager.Class.instance.getAlteredCDB();
        dc.Data.Class.loadJson(
           json,
           default);
    }


    private LevelStruct Hook__LevelStruct_get(Hook__LevelStruct.orig_get orig, User user, virtual_baseLootLevel_biome_bonusTripleScrollAfterBC_cellBonus_dlc_doubleUps_eliteRoomChance_eliteWanderChance_flagsProps_group_icon_id_index_loreDescriptions_mapDepth_minGold_mobDensity_mobs_name_nextLevels_parallax_props_quarterUpsBC3_quarterUpsBC4_specificLoots_specificSubBiome_transitionTo_tripleUps_worldDepth_ l, Rand rng)
    {

        var idStr = l.id.ToString();
        if (idStr.Equals("BackGarden", StringComparison.CurrentCultureIgnoreCase))
        {
            return GetGardenLevel.CreateLevelStruct(user, l, rng);
        }
        else return orig(user, l, rng);
    }
}
