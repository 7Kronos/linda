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
        TileRenderer _tileRenderer;

        bool showHelpers;

        public Butterfly(ISubEngine sub)
        {
            _sub = sub;
        }

        public void LoadWorld(IWorldLoader loader)
        {
            _loader = loader;
            loader.LoadMap(_world);
            _tileRenderer.Configure(_loader);
            _tileRenderer.Setup(_world);
        }

        /// <summary>
        /// Warmup
        /// </summary>
        public void StretchWings()
        {
            _world = new WorldSpace();
            _tileRenderer = new TileRenderer();
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

            var firstSquare = new V2(_sub.Camera.Location.X / _loader.TileStepX, _sub.Camera.Location.Y / _loader.TileStepY);
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            var squareOffset = new V2(_sub.Camera.Location.X % _loader.TileStepX, _sub.Camera.Location.Y % _loader.TileStepY);
            int offsetX = (int)squareOffset.X;
            int offsetY = (int)squareOffset.Y;

            _tileRenderer.Render(_sub.SpriteBatch, new V2(0f, 0f));

            _sub.SpriteBatch.End();
        }

        public void Dispose()
        {
        }
    }
}
