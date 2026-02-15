using System.Security.Cryptography.X509Certificates;
using dc._Data;
using dc.hl.types;
using ModCore.Utilities;

namespace Midjourney.Utils
{
    public class RoomGroup
    {
        public RoomGroup()
        {
            InitializeRoomGroup();
        }
        public void InitializeRoomGroup()
        {
            var obj = Room_group_Impl_.Class.NAMES;
            obj.pushDyn("BackGarden".AsHaxeString());
        }



    }
}