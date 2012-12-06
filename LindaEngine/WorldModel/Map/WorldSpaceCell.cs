using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using World.Content;

namespace LindaEngine.WorldModel.Map
{
    /// <summary>
    /// Reprents a cell in the world
    /// </summary>
    public class WorldSpaceCell
    {
        public TileSet Tiles { get; private set; }
        public TileSet HeightTiles { get; private set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public WorldSpaceCell()
        {
            Tiles = new TileSet();
            HeightTiles = new TileSet();
        }

        public void AddTile(Texture texture, bool doesClip = false)
        {
            Tiles.Add(new Tile()
            {
                Clipping = doesClip,
                Texture = texture
            });
        }
    }
}
