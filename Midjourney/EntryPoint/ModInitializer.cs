
using ModCore.Mods;
using ModCore.Utilities;
using ModCore.Events;
using ModCore.Events.Interfaces.Game;
using ModCore.Modules;
using dc.tool.mod;
using Midjourney.Core.Interfaces;
using Midjourney.Utils;
using Midjourney.EntryPoint;


namespace Midjourney.EntryPoint;

public class ModInitializer : ModBase,
    IOnHookInitialize,
    IOnGameEndInit
{
    public ModInitializer(ModInfo info) : base(info)
    {
    }


    public override void Initialize()
    {
        _ = new RoomGroup(this);
        _ = new DLCLang(this);
        _ = new LevelManager(this);
        _ = new WeaponManager(this);
        EventSystem.BroadcastEvent<IOnHookInitialize, ModInitializer>(this);
    }

    void IOnHookInitialize.HookInitialize(ModInitializer entry)
    {

    }

    void IOnGameEndInit.OnGameEndInit()
    {
        var resPath = Info.ModRoot!.GetFilePath("res.pak");
        FsPak.Instance.FileSystem.loadPak(resPath.AsHaxeString());
        var json = CDBManager.Class.instance.getAlteredCDB();
        dc.Data.Class.loadJson(
           json,
           default);
    }

}