using LindaEngine.Framework;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ConversionExtensions
    {
        public static Vector4 ToVector4(this V4 source)
        {
            return new Vector4(source.X, source.Y, source.Z, source.W);
        }

        public static Vector2 ToVector2(this V2 source)
        {
            return new Vector2(source.X, source.Y);
        }

        public static Rectangle ToRectangle(this Rect source)
        {
            return new Rectangle(source.X, source.Y, source.Width, source.Height);
        }
    }
}
