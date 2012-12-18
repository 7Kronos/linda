using LindaEngine.Core.Infrastructure;
using LindaEngine.Framework;
using LindaEngine.WorldModel.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LindaEngine.Core
{
    public class TileRenderer
    {
        const float HeightRowDepthMod = 0.0000001f;
        const float baseDepth = 0.7f;

        int TileStepX;
        int TileStepY;
        int WorldWidth;
        int WorldHeight;
        int WorldDepth;

        IList<PositionedWorldCell>[] positionedWorldCells;

        public int HeightTileOffset { get; set; }
        public int OddRowXOffset { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }

        public TileRenderer()
        {
        }

        public void Configure(IWorldLoader loader)
        {
            TileWidth = loader.TileWidth;
            TileHeight = loader.TileHeight;

            TileStepX = TileWidth;
            TileStepY = TileHeight / 4;
            OddRowXOffset = TileWidth / 2;
            HeightTileOffset = TileHeight;
        }

        public void Setup(WorldSpace world)
        {
            WorldWidth = world.WorldWidth;
            WorldHeight = world.WorldHeight;
            WorldDepth = world.WorldDepth;

            // Prefetch cells in an array sorted by z-buffer
            // depth = width + height + depth;
            positionedWorldCells = new List<PositionedWorldCell>[(WorldWidth + WorldHeight + WorldDepth)];

            for (int x = 0; x < WorldWidth; x++)
            {
                for (int y = 0; y < WorldHeight; y++)
                {
                    for (int z = 0; z < WorldDepth; z++)
                    {
                        var cell = world.GetAt(x, y, z);
                        var zbuffer = CalculateDistance(x, y, z);

                        if (positionedWorldCells[zbuffer] == null)
                            positionedWorldCells[zbuffer] = new List<PositionedWorldCell>();

                        for (int i = 0; i < cell.Tiles.Count; i++)
                        {
                            positionedWorldCells[zbuffer].Add(new PositionedWorldCell
                            {
                                Tile = cell.Tiles[i],
                                Position = CalculatePosition(cell)
                            });
                        }
                    }
                }
            }
        }

        public int CalculateDistance(int x, int y, int z)
        {
            return x + y + z;
        }

        public V2 CalculatePosition(WorldSpaceCell cell)
        {
            var pos = new V2(
                cell.X * TileStepX + (cell.Y % 2 == 1 ? OddRowXOffset : 0),
                cell.Y * TileStepY + (HeightTileOffset * cell.Z));

            System.Diagnostics.Debug.WriteLine(pos.X + ", " + pos.Y);

            return pos;
        }

        public void Render(ISpriteBatch spriteBatch, V2 cameraPosition)
        {
            spriteBatch.Begin();

            for (int i = 0; i < positionedWorldCells.Length; i++)
            {
                if (positionedWorldCells[i] == null)
                    continue;

                for (int j = 0; j < positionedWorldCells[i].Count; j++)
                {
                    var cell = positionedWorldCells[i][j];

                    if (cell.Tile == null)
                        continue;

                    spriteBatch.Draw(cell.Tile.Texture,
                        new Rect(0, 0, TileWidth, TileHeight),
                        new Rect((int)cell.Position.X, (int)cell.Position.Y, TileWidth, TileHeight),
                        0f,
                        baseDepth - ((i * 100) + j) * HeightRowDepthMod);

                    spriteBatch.DrawString(SysCore.SystemFont, cell.Position.X + ", " + cell.Position.Y, new V2(cell.Position.X, cell.Position.Y), new V4(255), 0f, 1f, 1f);

                }
            }

            spriteBatch.End();
        }
    }

    public struct PositionedWorldCell
    {
        public Tile Tile;
        public V2 Position;
    }
}
