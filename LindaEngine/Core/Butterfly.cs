using LindaEngine.Core.Infrastructure;
using LindaEngine.Framework;
using LindaEngine.WorldModel.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LindaEngine.Core
{
    /// <summary>
    /// Main core class
    /// </summary>
    public class Butterfly : IDisposable
    {
        WorldSpace _world;
        IWorldLoader _loader;
        ISubEngine _sub;

        public Butterfly(ISubEngine sub)
        {
            _sub = sub;
        }

        public void LoadWorld(IWorldLoader loader)
        {
            _loader = loader;
            loader.LoadMap(_world);
        }

        /// <summary>
        /// Warmup
        /// </summary>
        public void StretchWings()
        {
            _world = new WorldSpace();
        }

        /// <summary>
        /// Send love to screen
        /// </summary>
        public void Fly()
        {
            _sub.SpriteBatch.Begin();

            var firstSquare = new V2(_sub.Camera.Location.X / _loader.TileStepX, _sub.Camera.Location.Y / _loader.TileStepY);
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            var squareOffset = new V2(_sub.Camera.Location.X % _loader.TileStepX, _sub.Camera.Location.Y % _loader.TileStepY);
            int offsetX = (int)squareOffset.X;
            int offsetY = (int)squareOffset.Y;

            float maxdepth = ((_world.WorldWidth + 1) * ((_world.WorldHeight + 1) * _loader.TileWidth)) / 10;
            float depthOffset;

            for (int yTileIndex = 0; yTileIndex < _world.WorldHeight; yTileIndex++)
            {
                int rowOffset = 0;
                if ((firstY + yTileIndex) % 2 == 1)
                    rowOffset = _loader.OddRowXOffset;

                for (int xTileIndex = 0; xTileIndex < _world.WorldWidth; xTileIndex++)
                {

                    int mapx = (firstX + xTileIndex);
                    int mapy = (firstY + yTileIndex);
                    depthOffset = 0.7f - ((mapx + (mapy * _loader.TileWidth)) / maxdepth);

                    foreach (var Tile in _world.GetAt(xTileIndex, yTileIndex).Tiles)
                    {
                        _sub.SpriteBatch

                    }


                }
            }


            _sub.SpriteBatch.End();
        }



        public void Dispose()
        {
        }
    }
}
