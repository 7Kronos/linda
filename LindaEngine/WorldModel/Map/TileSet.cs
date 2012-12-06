using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LindaEngine.WorldModel.Map
{
    public class TileSet : List<Tile>
    {
        public TileSet() : base()
        {

        }

        public TileSet(IEnumerable<Tile> tiles) : base (tiles)
        {

        }
    }
}
