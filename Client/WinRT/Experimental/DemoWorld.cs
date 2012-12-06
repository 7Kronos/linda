using LindaEngine.Core.Infrastructure;
using LindaEngine.WorldModel.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimental
{
    public class DemoWorld : IWorldLoader
    {
        public int TileWidth { get { return 82; } }
        public int TileHeight { get { return 82; } }
        public float TileStepX { get { return 82f; } }
        public float TileStepY { get { return 20.5f; } }
        public int OddRowXOffset { get { return 41; } }
        public int HeightTileOffset { get { return 41; } }

        public int baseOffsetX { get { return -41; } }
        public int baseOffsetY { get { return -82; } }
        public float heightRowDepthMod { get { return 0.0000001f; } }

        public void LoadMap(WorldSpace world)
        {
            world.BuildNew(10, 10, 1);
        }
    }
}
