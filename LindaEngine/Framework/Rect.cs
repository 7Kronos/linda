using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LindaEngine.Framework
{
    public struct Rect : IEquatable<Rect>
    {
        #region Private Fields

        private static Rect emptyRect = new Rect();

        #endregion Private Fields


        #region Public Fields

        public int X;
        public int Y;
        public int Width;
        public int Height;

        #endregion Public Fields


        #region Public Properties

        public static Rect Empty
        {
            get { return emptyRect; }
        }

        public int Left
        {
            get { return this.X; }
        }

        public int Right
        {
            get { return (this.X + this.Width); }
        }

        public int Top
        {
            get { return this.Y; }
        }

        public int Bottom
        {
            get { return (this.Y + this.Height); }
        }

        #endregion Public Properties


        #region Constructors

        public Rect(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        #endregion Constructors


        #region Public Methods

        public static bool operator ==(Rect a, Rect b)
        {
            return ((a.X == b.X) && (a.Y == b.Y) && (a.Width == b.Width) && (a.Height == b.Height));
        }

        public bool Contains(int x, int y)
        {
            return ((((this.X <= x) && (x < (this.X + this.Width))) && (this.Y <= y)) && (y < (this.Y + this.Height)));
        }

        public bool Contains(Pt value)
        {
            return ((((this.X <= value.X) && (value.X < (this.X + this.Width))) && (this.Y <= value.Y)) && (value.Y < (this.Y + this.Height)));
        }

        public bool Contains(Rect value)
        {
            return ((((this.X <= value.X) && ((value.X + value.Width) <= (this.X + this.Width))) && (this.Y <= value.Y)) && ((value.Y + value.Height) <= (this.Y + this.Height)));
        }

        public static bool operator !=(Rect a, Rect b)
        {
            return !(a == b);
        }

        public void Offset(Pt offset)
        {
            X += offset.X;
            Y += offset.Y;
        }

        public void Offset(int offsetX, int offsetY)
        {
            X += offsetX;
            Y += offsetY;
        }

        public Pt Location
        {
            get
            {
                return new Pt(this.X, this.Y);
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Pt Center
        {
            get
            {
                // This is incorrect
                //return new Pt( (this.X + this.Width) / 2,(this.Y + this.Height) / 2 );
                // What we want is the Center of the Rect from the X and Y Origins
                return new Pt(this.X + (this.Width / 2), this.Y + (this.Height / 2));
            }
        }




        public void Inflate(int horizontalValue, int verticalValue)
        {
            X -= horizontalValue;
            Y -= verticalValue;
            Width += horizontalValue * 2;
            Height += verticalValue * 2;
        }

        public bool IsEmpty
        {
            get
            {
                return ((((this.Width == 0) && (this.Height == 0)) && (this.X == 0)) && (this.Y == 0));
            }
        }

        public bool Equals(Rect other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return (obj is Rect) ? this == ((Rect)obj) : false;
        }

        public override string ToString()
        {
            return string.Format("{{X:{0} Y:{1} Width:{2} Height:{3}}}", X, Y, Width, Height);
        }

        public override int GetHashCode()
        {
            return (this.X ^ this.Y ^ this.Width ^ this.Height);
        }

        public bool Intersects(Rect value)
        {
            return value.Left < Right &&
                   Left < value.Right &&
                   value.Top < Bottom &&
                   Top < value.Bottom;
        }


        public void Intersects(ref Rect value, out bool result)
        {
            result = value.Left < Right &&
                     Left < value.Right &&
                     value.Top < Bottom &&
                     Top < value.Bottom;
        }

        public static Rect Intersect(Rect value1, Rect value2)
        {
            Rect Rect;
            Intersect(ref value1, ref value2, out Rect);
            return Rect;
        }


        public static void Intersect(ref Rect value1, ref Rect value2, out Rect result)
        {
            if (value1.Intersects(value2))
            {
                int right_side = Math.Min(value1.X + value1.Width, value2.X + value2.Width);
                int left_side = Math.Max(value1.X, value2.X);
                int top_side = Math.Max(value1.Y, value2.Y);
                int bottom_side = Math.Min(value1.Y + value1.Height, value2.Y + value2.Height);
                result = new Rect(left_side, top_side, right_side - left_side, bottom_side - top_side);
            }
            else
            {
                result = new Rect(0, 0, 0, 0);
            }
        }

        public static Rect Union(Rect value1, Rect value2)
        {
            int x = Math.Min(value1.X, value2.X);
            int y = Math.Min(value1.Y, value2.Y);
            return new Rect(x, y,
                                 Math.Max(value1.Right, value2.Right) - x,
                                     Math.Max(value1.Bottom, value2.Bottom) - y);
        }

        public static void Union(ref Rect value1, ref Rect value2, out Rect result)
        {
            result.X = Math.Min(value1.X, value2.X);
            result.Y = Math.Min(value1.Y, value2.Y);
            result.Width = Math.Max(value1.Right, value2.Right) - result.X;
            result.Height = Math.Max(value1.Bottom, value2.Bottom) - result.Y;
        }

        #endregion Public Methods
    }
}
