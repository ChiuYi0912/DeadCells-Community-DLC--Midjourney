using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Midjourney.Core.Extensions;
using Midjourney.Core.Utilities;
using ModCore.Events;

namespace Midjourney.EntryPoint
{
    public class EntityManager:
    IEventReceiver
    {
        public EntityManager(ModInitializer entry)
        {
                entry.Logger.LogEntityManager("Entity Manager initialisation commences", LoggingHelper.LogLevel.Information);
                EventSystem.AddReceiver(this);
        }
    }
}