using LindaEngine.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LindaEngine.WorldModel.Content;

namespace LindaEngine.Core.Infrastructure
{
    public interface ISpriteBatch
    {
        void Begin();
        void End();

        void Draw(Texture texture, Nullable<Rect> source, Rect destination, float rotation, float depth);
        void DrawString(LindaEngine.WorldModel.Content.Font font, string text, Framework.V2 position, Framework.V4 color, float rotation, float scale, float depth);
    }
}
