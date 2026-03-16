using CoreLibrary.Core.Extensions;
using CoreLibrary.Core.Utilities;
using dc;
using dc.pr;
using HaxeProxy.Runtime;
using dc.libs.heaps.slib;
using Midjourney.EntryPoint;
using dc.en.mob;

namespace Midjourney.Entities.Mob
{
    public class Osty : dc.en.Mob
    {
        public Osty(Level lvl, int x, int y, dc.String kind, int dmgTier, int lifeTier) : base(lvl, x, y, kind, dmgTier, lifeTier)
        {
        }


        public override void initGfx()
        {
            base.initGfx();
            SpriteLib lib = Assets.Class.lib.get("atlas/Osty.atlas".ToHaxeString());
            initSprite(lib, "idle".ToHaxeString(), 0.5, 0.5, Const.Class.DP_FOREGROUND, true, null, null);
            HlFunc<bool> loop = () => isWalking();
            spr.get_anim().registerStateAnim("Walking".ToHaxeString(), 1, 0.5, loop, Ref<bool>.Null, null);
            spr.get_anim().registerStateAnim("idle".ToHaxeString(), 0, null, null, Ref<bool>.Null, null);
        }


        public static Osty CreateBees(Level level, int cx, int cy, int dmgTier, Ref<int> lifeTier)
        {
            var Osty = new Osty(level, cx, cy, "Osty".ToHaxeString(), dmgTier, lifeTier.value);
            Osty.init();
            EntityManager.GetLogger.LogInformation($"位置:x{Osty.cx} y:{Osty.cy}");
            return Osty;
        }
    }
}