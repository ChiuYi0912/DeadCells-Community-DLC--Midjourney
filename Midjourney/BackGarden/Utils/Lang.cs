using BackGarden;
using ModCore.Events;

namespace BackGarden.Utils.Lang
{
    public class BackGardenLang :
        IEventReceiver
    {
        public BackGardenLang(BackGardenEntry entry)
        {

            EventSystem.AddReceiver(this);
            ModCore.Modules.GetText.Instance.RegisterMod("BackGardenLang");
            entry.Logger.Information("\x1b[34m Language Module Loading]\x1b[0m");
        }
    }
}