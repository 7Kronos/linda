using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Content;

namespace World.Map
{
    public class WorldSpaceCell
    {
        public TileSet Tiles { get; private set; }

        public WorldSpaceCell()
        {
            Tiles = new TileSet();
        }

        public void AddTile(Texture texture, bool doesClip = false)
        { 
            Tiles.Add(new Tile() {
                Clipping = doesClip,
                Texture = texture
            })
        }
    }
}
