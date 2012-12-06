#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Text;
using System.Globalization;


namespace LindaEngine.Framework
{
    public struct V2 : IEquatable<V2>
    {
        #region Private Fields

        private static V2 zeroVector = new V2(0f, 0f);
        private static V2 unitVector = new V2(1f, 1f);
        private static V2 unitXVector = new V2(1f, 0f);
        private static V2 unitYVector = new V2(0f, 1f);

        #endregion Private Fields


        #region Public Fields
#if WINRT
        [DataMember]
#endif
        public float X;
#if WINRT
        [DataMember]
#endif
        public float Y;

        #endregion Public Fields


        #region Properties

        public static V2 Zero
        {
            get { return zeroVector; }
        }

        public static V2 One
        {
            get { return unitVector; }
        }

        public static V2 UnitX
        {
            get { return unitXVector; }
        }

        public static V2 UnitY
        {
            get { return unitYVector; }
        }

        #endregion Properties


        #region Constructors

        public V2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
		 
        public V2(float value)
        {
            this.X = value;
            this.Y = value;
        }

        #endregion Constructors


        #region Public Methods

        public static V2 Add(V2 value1, V2 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            return value1;
        }

        public static void Add(ref V2 value1, ref V2 value2, out V2 result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
        }

        public static V2 Barycentric(V2 value1, V2 value2, V2 value3, float amount1, float amount2)
        {
            return new V2(
                MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2));
        }

        public static void Barycentric(ref V2 value1, ref V2 value2, ref V2 value3, float amount1, float amount2, out V2 result)
        {
            result = new V2(
                MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2));
        }

        public static V2 CatmullRom(V2 value1, V2 value2, V2 value3, V2 value4, float amount)
        {
            return new V2(
                MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount));
        }

        public static void CatmullRom(ref V2 value1, ref V2 value2, ref V2 value3, ref V2 value4, float amount, out V2 result)
        {
            result = new V2(
                MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount));
        }

        public static V2 Clamp(V2 value1, V2 min, V2 max)
        {
            return new V2(
                MathHelper.Clamp(value1.X, min.X, max.X),
                MathHelper.Clamp(value1.Y, min.Y, max.Y));
        }

        public static void Clamp(ref V2 value1, ref V2 min, ref V2 max, out V2 result)
        {
            result = new V2(
                MathHelper.Clamp(value1.X, min.X, max.X),
                MathHelper.Clamp(value1.Y, min.Y, max.Y));
        }

        public static float Distance(V2 value1, V2 value2)
        {
			float v1 = value1.X - value2.X, v2 = value1.Y - value2.Y;
			return (float)Math.Sqrt((v1 * v1) + (v2 * v2));
        }

        public static void Distance(ref V2 value1, ref V2 value2, out float result)
        {
			float v1 = value1.X - value2.X, v2 = value1.Y - value2.Y;
            result = (float)Math.Sqrt((v1 * v1) + (v2 * v2));
        }

        public static float DistanceSquared(V2 value1, V2 value2)
        {
			float v1 = value1.X - value2.X, v2 = value1.Y - value2.Y;
			return (v1 * v1) + (v2 * v2);
        }

        public static void DistanceSquared(ref V2 value1, ref V2 value2, out float result)
        {
			float v1 = value1.X - value2.X, v2 = value1.Y - value2.Y;
			result = (v1 * v1) + (v2 * v2);
        }

        public static V2 Divide(V2 value1, V2 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            return value1;
        }

        public static void Divide(ref V2 value1, ref V2 value2, out V2 result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
        }

        public static V2 Divide(V2 value1, float divider)
        {
            float factor = 1 / divider;
            value1.X *= factor;
            value1.Y *= factor;
            return value1;
        }

        public static void Divide(ref V2 value1, float divider, out V2 result)
        {
            float factor = 1 / divider;
            result.X = value1.X * factor;
            result.Y = value1.Y * factor;
        }

        public static float Dot(V2 value1, V2 value2)
        {
            return (value1.X * value2.X) + (value1.Y * value2.Y);
        }

        public static void Dot(ref V2 value1, ref V2 value2, out float result)
        {
            result = (value1.X * value2.X) + (value1.Y * value2.Y);
        }

        public override bool Equals(object obj)
        {
			if(obj is V2)
			{
				return Equals((V2)obj);
			}
			
            return false;
        }

        public bool Equals(V2 other)
        {
            return (X == other.X) && (Y == other.Y);
        }
		
		public static V2 Reflect(V2 vector, V2 normal)
		{
			V2 result;
			float val = 2.0f * ((vector.X * normal.X) + (vector.Y * normal.Y));
			result.X = vector.X - (normal.X * val);
			result.Y = vector.Y - (normal.Y * val);
			return result;
		}
		
		public static void Reflect(ref V2 vector, ref V2 normal, out V2 result)
		{
			float val = 2.0f * ((vector.X * normal.X) + (vector.Y * normal.Y));
			result.X = vector.X - (normal.X * val);
			result.Y = vector.Y - (normal.Y * val);
		}
		
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public static V2 Hermite(V2 value1, V2 tangent1, V2 value2, V2 tangent2, float amount)
        {
            V2 result = new V2();
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
            return result;
        }

        public static void Hermite(ref V2 value1, ref V2 tangent1, ref V2 value2, ref V2 tangent2, float amount, out V2 result)
        {
            result.X = MathHelper.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount);
            result.Y = MathHelper.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
        }

        public float Length()
        {
			return (float)Math.Sqrt((X * X) + (Y * Y));
        }

        public float LengthSquared()
        {
			return (X * X) + (Y * Y);
        }

        public static V2 Lerp(V2 value1, V2 value2, float amount)
        {
            return new V2(
                MathHelper.Lerp(value1.X, value2.X, amount),
                MathHelper.Lerp(value1.Y, value2.Y, amount));
        }

        public static void Lerp(ref V2 value1, ref V2 value2, float amount, out V2 result)
        {
            result = new V2(
                MathHelper.Lerp(value1.X, value2.X, amount),
                MathHelper.Lerp(value1.Y, value2.Y, amount));
        }

        public static V2 Max(V2 value1, V2 value2)
        {
            return new V2(value1.X > value2.X ? value1.X : value2.X, 
			                   value1.Y > value2.Y ? value1.Y : value2.Y);
        }

        public static void Max(ref V2 value1, ref V2 value2, out V2 result)
        {
            result.X = value1.X > value2.X ? value1.X : value2.X;
			result.Y = value1.Y > value2.Y ? value1.Y : value2.Y;
        }

        public static V2 Min(V2 value1, V2 value2)
        {
            return new V2(value1.X < value2.X ? value1.X : value2.X, 
			                   value1.Y < value2.Y ? value1.Y : value2.Y); 
        }

        public static void Min(ref V2 value1, ref V2 value2, out V2 result)
        {
            result.X = value1.X < value2.X ? value1.X : value2.X;
			result.Y = value1.Y < value2.Y ? value1.Y : value2.Y;
		}

        public static V2 Multiply(V2 value1, V2 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            return value1;
        }

        public static V2 Multiply(V2 value1, float scaleFactor)
        {
            value1.X *= scaleFactor;
            value1.Y *= scaleFactor;
            return value1;
        }

        public static void Multiply(ref V2 value1, float scaleFactor, out V2 result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
        }

        public static void Multiply(ref V2 value1, ref V2 value2, out V2 result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
        }

        public static V2 Negate(V2 value)
        {
            value.X = -value.X;
            value.Y = -value.Y;
            return value;
        }

        public static void Negate(ref V2 value, out V2 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
        }

        public void Normalize()
        {
			float val = 1.0f / (float)Math.Sqrt((X * X) + (Y * Y));
			X *= val;
			Y *= val;
        }

        public static V2 Normalize(V2 value)
        {
			float val = 1.0f / (float)Math.Sqrt((value.X * value.X) + (value.Y * value.Y));
			value.X *= val;
			value.Y *= val;
            return value;
        }

        public static void Normalize(ref V2 value, out V2 result)
        {
			float val = 1.0f / (float)Math.Sqrt((value.X * value.X) + (value.Y * value.Y));
			result.X = value.X * val;
			result.Y = value.Y * val;
        }

        public static V2 SmoothStep(V2 value1, V2 value2, float amount)
        {
            return new V2(
                MathHelper.SmoothStep(value1.X, value2.X, amount),
                MathHelper.SmoothStep(value1.Y, value2.Y, amount));
        }

        public static void SmoothStep(ref V2 value1, ref V2 value2, float amount, out V2 result)
        {
            result = new V2(
                MathHelper.SmoothStep(value1.X, value2.X, amount),
                MathHelper.SmoothStep(value1.Y, value2.Y, amount));
        }

        public static V2 Subtract(V2 value1, V2 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            return value1;
        }

        public static void Subtract(ref V2 value1, ref V2 value2, out V2 result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
        }

        #endregion Public Methods


        #region Operators

        public static V2 operator -(V2 value)
        {
            value.X = -value.X;
            value.Y = -value.Y;
            return value;
        }


        public static bool operator ==(V2 value1, V2 value2)
        {
            return value1.X == value2.X && value1.Y == value2.Y;
        }


        public static bool operator !=(V2 value1, V2 value2)
        {
            return value1.X != value2.X || value1.Y != value2.Y;
        }


        public static V2 operator +(V2 value1, V2 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            return value1;
        }


        public static V2 operator -(V2 value1, V2 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            return value1;
        }


        public static V2 operator *(V2 value1, V2 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            return value1;
        }


        public static V2 operator *(V2 value, float scaleFactor)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            return value;
        }


        public static V2 operator *(float scaleFactor, V2 value)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            return value;
        }


        public static V2 operator /(V2 value1, V2 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            return value1;
        }


        public static V2 operator /(V2 value1, float divider)
        {
            float factor = 1 / divider;
            value1.X *= factor;
            value1.Y *= factor;
            return value1;
        }

        #endregion Operators
    }
}
