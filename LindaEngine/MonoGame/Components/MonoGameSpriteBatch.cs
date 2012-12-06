using LindaEngine.Core.Infrastructure;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaEngine.MonoGame.Components
{
    public class MonoGameSpriteBatch : ISpriteBatch
    {
        SpriteBatch _batch;

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
    }
}
