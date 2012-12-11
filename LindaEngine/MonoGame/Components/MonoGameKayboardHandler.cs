using LindaEngine.Core.Infrastructure;
using LindaEngine.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xna = Microsoft.Xna.Framework.Input;

namespace LindaEngine.MonoGame.Components
{
    public class MonoGameKayboardHandler : IKeyboardHandler
    {
        public bool this[Keys key]
        {
            get { return Xna.Keyboard.GetState().IsKeyDown((Xna.Keys)((int)key)); }
        }

        public Keys[] GetPressedKeys()
        {
            var t = Xna.Keyboard.GetState().GetPressedKeys();
            var t2 = new Keys[t.Length];

            for (int i = 0; i < t.Length; i++)
            {
                t2[i] = (Keys)((int)t[i]);
            }

            return t2;
        }

        public bool IsKeyDown(Keys key)
        {
            return this[key];
        }

        public bool IsKeyUp(Keys key)
        {
            return !this[key];
        }
    }
}
