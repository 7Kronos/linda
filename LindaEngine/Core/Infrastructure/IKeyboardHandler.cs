using LindaEngine.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LindaEngine.Core.Infrastructure
{
    public interface IKeyboardHandler
    {
        bool this[Keys key] { get; }
        Keys[] GetPressedKeys();
        bool IsKeyDown(Keys key);
        bool IsKeyUp(Keys key);
    }
}
