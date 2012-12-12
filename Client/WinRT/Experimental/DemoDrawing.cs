using LindaEngine.Core;
using LindaEngine.MonoGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        ContentManager _contentManager;

        public DemoDrawing(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, ContentManager contentManager)
        {
            _spriteBatch = spriteBatch;
            _graphics = graphics;
            _contentManager = contentManager;
            engine = new Butterfly(new MonoGameSubEngine(_graphics, _spriteBatch));

            SysCore.SystemFont = new LindaEngine.WorldModel.Content.Font() { 
                ContentName = "systemFont",
                Content = contentManager.Load<SpriteFont>(@"Fonts\Segoe")
            };
        }

        public void Initialize()
        {
            engine.StretchWings();
        }

        public void LoadContent()
        {
            engine.LoadWorld(new DemoWorld(_contentManager));
        }

        public void Update(GameTime gameTime)
        {
            engine.Flutter(gameTime.TotalGameTime);
        }
        public void Draw(GameTime gameTime)
        {
            engine.Fly();
        }
    }
}
