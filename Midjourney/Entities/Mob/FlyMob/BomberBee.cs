using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CoreLibrary.Core.Extensions;
using CoreLibrary.Core.Utilities;
using dc;
using dc.en.mob;
using dc.libs.heaps.slib;
using dc.pr;
using HaxeProxy.Runtime;
using Midjourney.EntryPoint;

namespace Midjourney.Entities.Mob.FlyMob
{
    public class BomberBee : BatKamikazeTemplate
    {
        public BomberBee(Level lvl, int x, int y, dc.String kind, int dmgTier, int lifeTier) : base(lvl, x, y, kind, dmgTier, lifeTier)
        {
        }

        public override void initGfx()
        {
            base.initGfx();
            SpriteLib lib = Assets.Class.lib.get("atlas/BomberBee.atlas".ToHaxeString());
            base.initSprite(lib, "idle".ToHaxeString(), 0.5, 0.5, Const.Class.DP_FOREGROUND, true, null, null);
            HlFunc<bool> condition = new(() => { return !awake; });
            base.spr.get_anim().registerStateAnim("idle".ToHaxeString(), 1, 0.5, condition, Ref<bool>.Null, null);
            base.spr.get_anim().registerStateAnim("idle".ToHaxeString(), 0, 0.5, null, Ref<bool>.Null, null);
        }


        public static BomberBee CreateBees(Level level, int cx, int cy, int dmgTier, Ref<int> lifeTier)
        {
            var BomberBee = new BomberBee(level, cx, cy, "BomberBee".ToHaxeString(), dmgTier, lifeTier.value);
            BomberBee.init();
            EntityManager.GetLogger.LogInformation($"位置:x{BomberBee.cx} y:{BomberBee.cy}");
            return BomberBee;
        }
    }
}