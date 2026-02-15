using System.Security.Cryptography.X509Certificates;
using dc._Data;
using dc.hl.types;
using ModCore.Utilities;

namespace Utils.RoomGroup
{
    public class Room_group
    {
        public Room_group()
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