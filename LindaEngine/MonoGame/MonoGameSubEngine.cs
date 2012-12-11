using LindaEngine.Core.Infrastructure;
using LindaEngine.MonoGame.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaEngine.MonoGame
{
    /// <summary>
    /// Can make butterflies fly in MonoGame
    /// </summary>
    public class MonoGameSubEngine : ISubEngine
    {
        public ISpriteBatch SpriteBatch { get; private set; }
        public ICameraController Camera { get; private set; }
        public IKeyboardHandler Keyboard { get; private set; }

        public MonoGameSubEngine(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            SpriteBatch = new MonoGameSpriteBatch(spriteBatch);
            Camera = new MonoGameCameraController();
            Keyboard = new MonoGameKayboardHandler();
        }
    }
}
