using LindaEngine.Core.Infrastructure;
using LindaEngine.WorldModel.Map;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimental
{
    public class DemoWorld : IWorldLoader
    {
        ContentManager _contentManager;

        public int TileWidth { get { return 92; } }
        public int TileHeight { get { return 92; } }
        public int TileStepX { get { return 92; } }
        public int TileStepY { get { return 23; } }
        public int OddRowXOffset { get { return 46; } }
        public int HeightTileOffset { get { return 46; } }

        //public int TileWidth { get { return 82; } }
        //public int TileHeight { get { return 82; } }
        //public int TileStepX { get { return 82; } }
        //public int TileStepY { get { return 20; } }
        //public int OddRowXOffset { get { return 41; } }
        //public int HeightTileOffset { get { return 41; } }

        public int baseOffsetX { get { return 200; } }
        public int baseOffsetY { get { return 200; } }
        public float heightRowDepthMod { get { return 0.0000001f; } }

        public DemoWorld(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public void LoadMap(WorldSpace world)
        {
            var height = 8;
            var width = 3;
            var depth = 3;

            world.BuildNew(width, height, depth);
            var b = LoadContent<Texture2D>(@"Testing", "Herbe3.png");
            var b2 = LoadContent<Texture2D>(@"Testing\images\tiles\buildings\inside\decor", "0065.gif");
            var b3 = LoadContent<Texture2D>(@"Testing\images\tiles\buildings\inside\ground", "0005.gif");
            var b4 = LoadContent<Texture2D>(@"Testing\images\tiles\change_zones", "0004-2.gif");
            var b5 = LoadContent<Texture2D>(@"Testing\images\tiles\change_zones", "0004-1.gif");
            var i = 0;

            for (int mapx = 0; mapx < width; mapx++) // first floor
            {
                for (int mapy = 0; mapy < height; mapy++)
                {
                    var cell = world.GetAt(mapx, mapy);
                    cell.Tiles.Add(GetTile(b));
                }
            }

            var groundcell = world.GetAt(1, 5, 0);
            groundcell.Tiles.Add(GetTile(b2));

            //var groundcell2 = world.GetAt(2, 4, 0);
            //groundcell2.HeightTiles.Add(GetTile(b4));
            //var groundcell3 = world.GetAt(2, 3, 0);
            //groundcell3.HeightTiles.Add(GetTile(b5));

            //var topercell = world.GetAt(1, 5, 1);
            //topercell.Tiles.Add(GetTile(b3));

            //var topercell2 = world.GetAt(1, 4, 1);
            //topercell2.Tiles.Add(GetTile(b3));
        }

        public Tile GetTile(Texture2D texture)
        {
            return new Tile()
            {
                Clipping = false,
                Texture = new LindaEngine.WorldModel.Content.Texture()
                {
                    ContentSet = "local",
                    ContentName = "dalle",
                    Content = texture
                }
            };
        }

        public T LoadContent<T>(string contentSet, string contentName)
        {
            return _contentManager.Load<T>(contentSet + @"\" + contentName);
        }

        public TContent Load<TContent>(string contentKey)
        {
            return _contentManager.Load<TContent>(contentKey);
        }
    }
}
