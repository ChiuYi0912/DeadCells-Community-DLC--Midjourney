using ModCore.Mods;
using ModCore.Utilities;
using ModCore.Events;
using ModCore.Events.Interfaces.Game;
using ModCore.Modules;
using dc.tool.mod;
using Midjourney.Core.Interfaces;
using Midjourney.Core.Utilities;
using Midjourney.Core.Extensions;
using Midjourney.Utils;
using Midjourney.EntryPoint;
using dc;
using dc.hl.types;
using ModCore.Events.Interfaces.Game.Hero;
using dc.en;


namespace Midjourney.EntryPoint;

public class ModInitializer(ModInfo info) : ModBase(info),
    IOnHookInitialize,
    IOnGameEndInit,
    IOnAfterLoadingCDB,
    IOnHeroUpdate
{
    public static ModCore.Storage.Config<Core.Configuration.CoreCfig> Config = new("MidjourneyCoreConfig");

    public override void Initialize()
    {
        Config.Value.debugMode = true;
        Config.Save();
        Logger.LogModInitializer("Commencing initialisation of the Midjourney DLC module", LoggingHelper.LogLevel.Information);

        using (Logger.LogPerformance("Module initialisation", LoggingHelper.Modules.ModInitializer))
        {
            _ = new RoomGroup(this);
            _ = new DLCLang(this);
            _ = new LevelManager(this);
            _ = new WeaponManager(this);
            _ = new EntityManager(this);

            Logger.LogEvents("Broadcast the IOnHookInitialize event", LoggingHelper.LogLevel.Verbose);
            EventSystem.BroadcastEvent<IOnHookInitialize, ModInitializer>(this);
        }
    }

    void IOnHookInitialize.HookInitialize(ModInitializer entry)
    {

    }

    void IOnAfterLoadingCDB.OnAfterLoadingCDB(_Data_ cdb)
    {

    }

    void IOnGameEndInit.OnGameEndInit()
    {
        using (Logger.LogMethodScope(nameof(IOnGameEndInit.OnGameEndInit)))
        {
            try
            {
                Logger.LogInformation("Commencing loading of mod resources");

                var resPath = Info.ModRoot!.GetFilePath("res.pak");

                if (string.IsNullOrWhiteSpace(resPath))
                {
                    Logger.LogResources("Resource path is empty", LoggingHelper.LogLevel.Error);
                    return;
                }
                Logger.LogDebug($"Resource path: {resPath}", LoggingHelper.Modules.Resources);

                Logger.LogResources("Loading resource package file", LoggingHelper.LogLevel.Debug);
                FsPak.Instance.FileSystem.loadPak(resPath.AsHaxeString());

                Logger.LogResources("Retrieving altered CDB data", LoggingHelper.LogLevel.Debug);
                var json = CDBManager.Class.instance.getAlteredCDB();


                var jsonStr = json.ToString();
                Logger.LogResources("Load CDB data into the game", LoggingHelper.LogLevel.Debug);
                dc.Data.Class.loadJson(
                   json,
                   default);
            }
            catch (Exception ex)
            {
                Logger.LogError("An error occurred while loading module resources.", ex, LoggingHelper.Modules.Resources);

                Logger.LogResources($"Error Details: {ex.Message}", LoggingHelper.LogLevel.Error);
            }
        }
    }


    void IOnHeroUpdate.OnHeroUpdate(double dt)
    {

        List<Entity> entities = Game.Instance.HeroInstance!._level.RemoveAllMobsSafe();
        for (int i = 0; i < entities.Count; i++)
        {
            Logger.LogInformation($"Removing entity: {entities[i]}");
        }
    }
}