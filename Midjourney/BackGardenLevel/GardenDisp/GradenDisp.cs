using dc;
using dc.en.inter.npc;
using dc.h2d;
using dc.h2d.col;
using dc.h3d;
using dc.hl.types;
using dc.level;
using dc.libs;
using dc.libs.heaps;
using dc.libs.heaps.slib;
using dc.light;
using dc.pr;
using Hashlink.Virtuals;
using HaxeProxy.Runtime;
using ModCore.Utilities;
using Serilog;
using Serilog.Core;


namespace BackGarden.Disp
{
    public class GardenDisp : DynamicBiomeDisp
    {


        public GardenDisp(Level level, LevelMap map, dc.String mainBiomeKind, dc.String otherBiomeKind, virtual_blendAmbient_blendAmbientFog_blendCamDust_blendCamFog_blendGroundSmoke_blendLights_blendShadows_ blendConfiguration, ArrayObj parallaxInfo) : base(level, map, mainBiomeKind, otherBiomeKind, blendConfiguration, parallaxInfo)
        {
        }

        public HSpriteBatch sbAddWalls = null!;
        public HSpriteBatch sbAlcovesTorches = null!;



        public override void render()
        {
            base.render();
            renderBackWalls();
        }

        public override void renderBackWalls()
        {
            base.renderBackWalls();

            SpriteLib slib = this.level.slib;

            int backgroundClass = Const.Class.DP_BACKGROUND;
            double parallaxDepth = 0.02;

            Parallax parallax = base.createParallax(
                backgroundClass,
                parallaxDepth,
                parallaxDepth
            );


            dc.String tilePath = dc.String.Class.__add__("bg/".AsHaxeString(), "sky".AsHaxeString());
            HlFunc<int, int> randomFlip = new HlFunc<int, int>(base.rng.random);
            Bitmap skyBitmap = new Bitmap(
                slib.getTileRandom(tilePath, Ref<double>.Null, Ref<double>.Null, randomFlip, null),
                parallax
            );

            skyBitmap.posChanged = true;

            double viewportWidth = parallax.vwid;
            Bounds parallaxBounds = parallax.bounds;

            double horizontalScale = parallaxBounds.xMax - parallaxBounds.xMin - viewportWidth;
            horizontalScale *= parallax.scrollX;
            horizontalScale += viewportWidth;
            horizontalScale /= (double)skyBitmap.tile.width;
            skyBitmap.scaleX = horizontalScale;

            double viewportHeight = parallax.vhei;
            parallaxBounds = parallax.bounds;

            double verticalScale = parallaxBounds.yMax - parallaxBounds.yMin - viewportHeight;
            verticalScale *= parallax.scrollY;
            verticalScale += viewportHeight;
            verticalScale /= (double)skyBitmap.tile.height;
            skyBitmap.scaleY = verticalScale;
            skyBitmap.blendMode = new BlendMode.Alpha();



            backgroundClass = Const.Class.DP_BACKGROUND;
            float parallaxFactor = 0.04f;
            Parallax parallax2 = base.createParallax(backgroundClass, parallaxFactor, parallaxFactor);


            parallax2.posChanged = true;
            Bounds bounds = base.lmap.bounds;
            parallax2.x = (bounds.xMax - bounds.xMin) * 0.33f;
            parallax2.y = (bounds.yMax - bounds.yMin) * 0.5f;


            Scatterer scatterer = new Scatterer(parallax2);
            tilePath = "bg/Moon".AsHaxeString();
            HlFunc<int, int> flipMode = new HlFunc<int, int>(base.rng.random);

            double randomX = 0.5f, randomY = 0.5f;
            Bitmap bitmap2 = new Bitmap(
                slib.getTileRandom(tilePath, Ref<double>.From(ref randomX), Ref<double>.From(ref randomY), flipMode, null),
                scatterer
            );


            base.applyScatterConf(scatterer, base.lmap.biome.scatterConf);

            randomX = 1.0f;
            randomY = 0.918f;
            double VectorZ = 0.710f;
            double VectorW = 1.0F;
            bitmap2.color = new Vector(Ref<double>.From(ref randomX), Ref<double>.From(ref randomY), Ref<double>.From(ref VectorZ), Ref<double>.From(ref VectorW));
            bitmap2.blendMode = new BlendMode.AlphaAdd();

        }

        public override void updateBiomeFx()
        {

        }

        public override void decorateZone(DecoZone z)
        {
            base.decorateZone(z);
            bool shouldAddAlcoves = (z.gFlags & 64) == 0 && z.hasGround && (z.gFlags & 8) != 0 && (z.flags & 16) == 0 && z.xmax - z.xmin >= 7 && z.ymax - z.ymin >= 5;
            if (shouldAddAlcoves)
            {
                this.AddAlcoves(z);
            }

        }

        public void AddAlcoves(DecoZone size)
        {
            double zoneWidth = size.xmax - size.xmin;
            int alcoveCount = (int)(zoneWidth / 7.0);
            if (alcoveCount == 0) return;

            SpriteLib spriteLib = base.level.slib;
            LevelMap levelMap = base.lmap;

            double minScale = 0.5;
            double maxScale = 1.0;
            HlFunc<int, int> randomFunc = new HlFunc<int, int>(base.rng.random);
            Tile randomAlcoveTile = spriteLib.getTileRandom("alcove".AsHaxeString(),
                Ref<double>.From(ref minScale), Ref<double>.From(ref maxScale), randomFunc, null);
            if (randomAlcoveTile == null) return;


            int totalPixelWidth = (size.xmax - size.xmin) * 24;
            int totalAlcoveWidth = alcoveCount * randomAlcoveTile.width;
            double spacing = (double)(totalPixelWidth - totalAlcoveWidth) / (alcoveCount + 1);
            int yPosition = size.ymax * 24;

            for (int i = 0; i < alcoveCount; i++)
            {

                if (!spriteLib.groups.exists("alcove".AsHaxeString()))
                {
                    throw null!;
                }

                var group = spriteLib.groups.get("alcove".AsHaxeString());
                int frameCount = group.frames.length;
                int frameIndex = randomFunc.Invoke(frameCount);

                double scale = 0.5;
                double rotation = 1.0;
                Tile alcoveTile = spriteLib.getTile("alcove".AsHaxeString(),
                    Ref<int>.From(ref frameIndex), Ref<double>.From(ref scale),
                    Ref<double>.From(ref rotation), null);

                if (alcoveTile == null) continue;


                double baseX = size.xmin * 24;
                double spacingOffset = (spacing + alcoveTile.width) * (i + 1);
                double centerOffset = alcoveTile.width * 0.5;
                int xPosition = (int)(baseX + spacingOffset - centerOffset);


                double leftEdge = (xPosition - alcoveTile.width * 0.5) / 24.0;
                int xMin = (int)System.Math.Floor(leftEdge);
                double rightEdge = (xPosition + alcoveTile.width * 0.5) / 24.0;
                int xMax = (int)System.Math.Ceiling(rightEdge);

                DecoZone alcoveZone = new DecoZone(xMin, size.ymax, xMax, size.ymax + 1);
                alcoveZone.init(levelMap);


                if ((alcoveZone.flags & 128) == 0)
                {
                    int? abortFlags = 786432;
                    var addedTile = base.addPixelTile(
                        base.groupBackWallProps, alcoveTile, xPosition, yPosition,
                        abortFlags, null, null, null, null, null
                    );
                }
            }
        }


        public override void decorateRoom(Room r)
        {
            base.decorateRoom(r);
            //AddMushrooms(r);
        }


        public void AddMushrooms(Room r)
        {
            SpriteLib spriteLib = Assets.Class.tryGetAtlas(new DynamicLoadAtlas.LevelCandle());
            ArrayObj alcoveMarkers = r.getMarkersOfType("CustomDeco".AsHaxeString());


            for (int i = 0; i < alcoveMarkers.length; i++)
            {
                dynamic arraymarker = alcoveMarkers.array[i]!;
                Marker marker = arraymarker;
                if (marker == null) continue;

                if (marker.customId.ToString() == "Alcove")
                {
                    int tileX = r.x + marker.cx;
                    int tileY = r.y + marker.cy;


                    base.addTile(base.groupBackWallProps, "mushrooms".AsHaxeString(),
                                tileX, tileY, 0.0, 0.0, 0.0, 0.0,
                                262144, null, null, null, null, null);
                }
            }


            if (spriteLib != null)
            {
                HSpriteBatch spriteBatch = this.sbAlcovesTorches;
                if (spriteBatch != null && spriteBatch.tile.isDisposed())
                {
                    dynamic tile = spriteLib.pages.array[0]!;
                    Tile atlasTile = tile;
                    if (atlasTile != null)
                    {
                        spriteBatch.tile.setTexture(atlasTile.innerTex);
                    }
                }
            }
        }
    }
}