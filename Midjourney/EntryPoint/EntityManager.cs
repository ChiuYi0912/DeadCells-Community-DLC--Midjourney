using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Midjourney.EntryPoint
{
    public class EntityManager
    {
        public EntityManager(ModInitializer entry)
        {
            entry.Logger.Information("\x1b[34m Entity Manager Loading]\x1b[0m");
        }
    }
}