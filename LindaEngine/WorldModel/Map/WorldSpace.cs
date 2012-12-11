using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LindaEngine.WorldModel.Map
{
    public class WorldSpace
    {
        private IList<WorldSpaceCell> _cells;
        public IEnumerable<WorldSpaceCell> Cells
        {
            get
            {
                return _cells.AsEnumerable();
            }
        }

        public int WorldWidth { get; private set; }
        public int WorldHeight { get; private set; }
        public int WorldDepth { get; private set; }


        public WorldSpace AddCell(WorldSpaceCell cell)
        {
            if (GetAt(cell.X, cell.Y, cell.Z) != null)
                throw new InvalidOperationException("There is already a cell at this location.");

            _cells.Add(cell);

            return this;
        }

        public WorldSpace BuildNew(int width, int height, int depth)
        {
            WorldWidth = width;
            WorldHeight = height;
            WorldDepth = depth;

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
