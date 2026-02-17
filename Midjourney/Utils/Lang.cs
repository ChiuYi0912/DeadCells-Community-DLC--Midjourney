using Midjourney.Core.Extensions;
using Midjourney.Core.Utilities;
using Midjourney.EntryPoint;
using ModCore.Events;

namespace Midjourney.Utils
{
    public class DLCLang :
        IEventReceiver
    {
        public DLCLang(ModInitializer levelinit)
        {
            levelinit.Logger.LogInformation("Language Module initialisation commences", "DLCLang");
            EventSystem.AddReceiver(this);
            ModCore.Modules.GetText.Instance.RegisterMod("BackGardenLang");

        }
    }
}