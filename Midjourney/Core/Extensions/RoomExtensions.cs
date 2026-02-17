using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dc.level;

namespace Midjourney.Core.Extensions
{
    public static class RoomExtensions
    {
        public static RoomNode AddFlags(this RoomNode node, params RoomFlag[] flags)
        {
            foreach (RoomFlag flag in flags)
            {
                node.addFlag(flag);
            }
            return node;
        }

        public static RoomNode AddNPC(this RoomNode node, dc.NpcId npcId, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                node.addNpc(npcId);
            }
            return node;
        }
    }
}