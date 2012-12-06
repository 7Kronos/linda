using LindaEngine.Core;
using LindaEngine.MonoGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimental
{
    public class DemoDrawing
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        Butterfly engine;

        public DemoDrawing(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            _spriteBatch = spriteBatch;
            _graphics = graphics;
            engine = new Butterfly(new MonoGameSubEngine(_graphics, _spriteBatch));
        }

        public void Initialize()
        {
            engine.StretchWings();
        }

        public void LoadContent()
        {
            engine.LoadWorld(new DemoWorld());
        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(GameTime gameTime)
        {
            engine.Fly();
        }
    }
}
