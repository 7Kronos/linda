using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Map
{
    public class WorldSpace
    {
        public static readonly int TileWidth = 82;
        public static readonly int TileHeight = 82;
        public static readonly float TileStepX = 82;
        public static readonly float TileStepY = 20.5;
        public static readonly int OddRowXOffset = 41;
        public static readonly int HeightTileOffset = 41;

        public static readonly int baseOffsetX = -41;
        public static readonly int baseOffsetY = -82;
        public static readonly float heightRowDepthMod = 0.0000001f;

        private IList<WorldSpaceCell> _cells;
        public IEnumerable<WorldSpaceCell> Cells
        {
            get
            {
                return _cells.AsEnumerable();
            }
        }

        public WorldSpace AddCell(WorldSpaceCell cell)
        {
            if (GetAt(cell.X, cell.Y, cell.Z) != null)
                throw new InvalidOperationException("There is already a cell at this location.");

            _cells.Add(cell);

            return this;
        }

        public WorldSpace BuildNew(int width, int height, int depth)
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    for (int z = 0; z < depth; z++)
                    {
                        AddCell(new WorldSpaceCell()
                        {
                            X = x,
                            Y = y,
                            Z = z
                        });
                    }

            return this;
        }

        public WorldSpaceCell GetAt(int x, int y, int z = 0)
        {
            return Cells.Where(cell => cell.X == x & cell.Y == y & cell.Z == z).SingleOrDefault();
        }

        public WorldSpace()
        {
            _cells = new List<WorldSpaceCell>();
        }
    }
}
