using LindaEngine.WorldModel.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LindaEngine.WorldModel.Content;

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
        int TileStepX { get; }
        int TileStepY { get; }
        int TileWidth { get; }

        TContent Load<TContent>(string contentKey);
        void LoadMap(WorldSpace world);
    }
}
