using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLibrary.Core.Utilities;
using ModCore.Events;

namespace Midjourney.EntryPoint
{
    public class EntityManager:
    IEventReceiver
    {
        public readonly Serilog.ILogger GetLogger;
        public EntityManager(ModInitializer entry)
        {
            GetLogger =entry.Logger;
            GetLogger.LogInformation("Entity Manager initialisation commences");
            EventSystem.AddReceiver(this);
        }
    }
}