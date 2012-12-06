using LindaEngine.WorldModel.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using World.Content;

namespace LindaEngine.Core.Infrastructure
{
    public interface IWorldLoader
    {
        int baseOffsetX { get; }
        int baseOffsetY { get; }
        float heightRowDepthMod { get; }
        int HeightTileOffset { get; }
        int OddRowXOffset { get; }
        int TileHeight { get; }
        float TileStepX { get; }
        float TileStepY { get; }
        int TileWidth { get; }

        void LoadMap(WorldSpace world);
    }
}
