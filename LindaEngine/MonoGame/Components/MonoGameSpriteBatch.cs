using LindaEngine.Core.Infrastructure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;


namespace LindaEngine.MonoGame.Components
{
    public class MonoGameSpriteBatch : ISpriteBatch
    {
        SpriteBatch _batch;
        SpriteFont defaultFont;

        public MonoGameSpriteBatch(SpriteBatch batch)
        {
            _batch = batch;
        }

        public void Begin()
        {
            _batch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
        }

        public void End()
        {
            _batch.End();
        }

        public void Draw(LindaEngine.WorldModel.Content.Texture texture, Framework.Rect? source, Framework.Rect destination, float rotation, float depth)
        {
            _batch.Draw(
                texture.Content as Texture2D,
                destination.ToRectangle(),
                source.HasValue ? source.Value.ToRectangle() : Rectangle.Empty,
                Color.White,
                rotation,
                Vector2.Zero,
                SpriteEffects.None,
                depth);
        }

        public void DrawString(LindaEngine.WorldModel.Content.Font font, string text, Framework.V2 position, Framework.V4 color, float rotation, float scale, float depth)
        {
            _batch.DrawString(
                font.Content as SpriteFont,
                text,
                position.ToVector2(),
                new Color(color.ToVector4()),
                rotation,
                Vector2.Zero,
                scale,
                SpriteEffects.None,
                depth);
        }
    }
}
