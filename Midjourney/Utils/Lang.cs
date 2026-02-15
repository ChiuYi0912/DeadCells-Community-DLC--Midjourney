using BackGarden;
using ModCore.Events;
using ModEntryLevelinit;

namespace Midjourney.Utils
{
    public class DLCLang :
        IEventReceiver
    {
        public DLCLang(Levelinit levelinit)
        {
            EventSystem.AddReceiver(this);
            ModCore.Modules.GetText.Instance.RegisterMod("BackGardenLang");
            levelinit.Logger.Information("\x1b[34m Language Module Loading]\x1b[0m");
        }
    }
}