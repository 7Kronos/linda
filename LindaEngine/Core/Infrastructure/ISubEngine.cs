using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LindaEngine.Core.Infrastructure
{
    public interface ISubEngine
    {
        ISpriteBatch SpriteBatch { get; }
        ICameraController Camera { get; }
        IKeyboardHandler Keyboard { get; }
    }
}
