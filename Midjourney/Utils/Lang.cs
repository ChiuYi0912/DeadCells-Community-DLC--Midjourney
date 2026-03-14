
using CoreLibrary.Core.Utilities;
using Midjourney.EntryPoint;
using ModCore.Events;

namespace Midjourney.Utils
{
    public class DLCLang :
        IEventReceiver
    {
        public readonly Serilog.ILogger GetLogger;
        public DLCLang(ModInitializer levelinit)
        {
            GetLogger =levelinit.Logger;
            GetLogger.LogInformation("Language Module initialisation commences", "DLCLang");
            EventSystem.AddReceiver(this);
            ModCore.Modules.GetText.Instance.RegisterMod("BackGardenLang");

        }
    }
}