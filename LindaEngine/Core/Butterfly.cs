using LindaEngine.Core.Infrastructure;
using LindaEngine.Framework;
using LindaEngine.Framework.Input;
using LindaEngine.WorldModel.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LindaEngine.WorldModel.Content;

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

        bool showHelpers;

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
        /// Butterly flies
        /// </summary>
        /// <param name="gameTime"></param>
        public void Flutter(TimeSpan gameTime)
        {
            showHelpers = _sub.Keyboard.IsKeyDown(Keys.X);
        }

        /// <summary>
        /// Send love to screen
        /// </summary>
        public void Fly()
        {
            _sub.SpriteBatch.Begin();
            float heightRowDepthMod = 0.00001f;

            var firstSquare = new V2(_sub.Camera.Location.X / _loader.TileStepX, _sub.Camera.Location.Y / _loader.TileStepY);
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            var squareOffset = new V2(_sub.Camera.Location.X % _loader.TileStepX, _sub.Camera.Location.Y % _loader.TileStepY);
            int offsetX = (int)squareOffset.X;
            int offsetY = (int)squareOffset.Y;

            float maxdepth = ((_world.WorldWidth + 1) * ((_world.WorldHeight + 1) * _loader.TileWidth)) * 10;
            float depthOffset;

            for (int yTileIndex = 0; yTileIndex < _world.WorldHeight; yTileIndex++)
            {
                int rowOffset = 0;
                if ((firstY + yTileIndex) % 2 == 1)
                    rowOffset = _loader.OddRowXOffset;

                for (int xTileIndex = 0; xTileIndex < _world.WorldWidth; xTileIndex++)
                {
                    if (showHelpers)
                    {
                        var s = new StringBuilder();

                        //s.AppendLine((xTileIndex + firstX).ToString() + ", " + (yTileIndex + firstY).ToString());
                        s.Append(((xTileIndex * _loader.TileStepX) - offsetX + rowOffset).ToString() + ", " + ((yTileIndex * _loader.TileStepY) - offsetY).ToString());

                        _sub.SpriteBatch.DrawString(SysCore.SystemFont, s.ToString(),
                            new V2((xTileIndex * _loader.TileStepX) - offsetX + rowOffset + _loader.baseOffsetX + 24, (yTileIndex * _loader.TileStepY) - offsetY + _loader.baseOffsetY + 48),
                            new V4(255, 255, 255, 255),
                            0f,
                            1.0f,
                            0f);
                    }

                    for (int zTileIndex = 0; zTileIndex < _world.WorldDepth; zTileIndex++)
                    {
                        int mapx = (firstX + xTileIndex);
                        int mapy = (firstY + yTileIndex);
                        depthOffset = (1.0f / _world.WorldDepth) - ((mapx + (mapy * _loader.TileWidth)) / maxdepth);

                        foreach (var Tile in _world.GetAt(xTileIndex, yTileIndex, zTileIndex).Tiles)
                        {
                            _sub.SpriteBatch.Draw(Tile.Texture,
                                new Rect(0, 0, _loader.TileWidth, _loader.TileHeight),
                                new Rect(
                                    (xTileIndex * _loader.TileStepX) - offsetX + rowOffset + _loader.baseOffsetX,
                                    (yTileIndex * _loader.TileStepY) - offsetY + _loader.baseOffsetY,
                                    _loader.TileWidth, _loader.TileHeight),
                                0.0f,
                                depthOffset);
                        }

                        var heightTilesCount = 0;
                        foreach (var Tile in _world.GetAt(xTileIndex, yTileIndex, zTileIndex).HeightTiles)
                        {
                            _sub.SpriteBatch.Draw(Tile.Texture,
                                new Rect(0, 0, _loader.TileWidth, _loader.TileHeight),
                                new Rect(
                                    (xTileIndex * _loader.TileStepX) - offsetX + rowOffset + _loader.baseOffsetX,
                                    (yTileIndex * _loader.TileStepY) - offsetY + _loader.baseOffsetY + (heightTilesCount * _loader.HeightTileOffset),
                                    _loader.TileWidth, _loader.TileHeight),
                                0.0f,
                                depthOffset - (_loader.heightRowDepthMod * (heightTilesCount + zTileIndex)));

                            heightTilesCount++;
                        }
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
