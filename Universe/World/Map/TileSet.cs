using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Map
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
