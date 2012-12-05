using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Map
{
    public class WorldSpace
    {
        public static readonly int TileWidth = 64;
        public static readonly int TileHeight = 64;
        public static readonly int TileStepX = 64;
        public static readonly int TileStepY = 16;
        public static readonly int OddRowXOffset = 32;
        public static readonly int HeightTileOffset = 32;

        public static readonly int baseOffsetX = -32;
        public static readonly int baseOffsetY = -64;
        public static readonly float heightRowDepthMod = 0.0000001f;

        public IList<WorldSpaceCell> Cells { get; private set; }

        public WorldSpace()
        {
            Cells = new List<WorldSpaceCell>();
        }
    }
}
