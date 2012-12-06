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
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace LindaEngine.Framework
{

    public struct V3 : IEquatable<V3>
    {
        #region Private Fields

        private static  V3 zero = new V3(0f, 0f, 0f);
        private static  V3 one = new V3(1f, 1f, 1f);
        private static  V3 unitX = new V3(1f, 0f, 0f);
        private static  V3 unitY = new V3(0f, 1f, 0f);
        private static  V3 unitZ = new V3(0f, 0f, 1f);
        private static  V3 up = new V3(0f, 1f, 0f);
        private static  V3 down = new V3(0f, -1f, 0f);
        private static  V3 right = new V3(1f, 0f, 0f);
        private static V3 left = new V3(-1f, 0f, 0f);
        private static V3 forward = new V3(0f, 0f, -1f);
        private static V3 backward = new V3(0f, 0f, 1f);

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
#if WINRT
        [DataMember]
#endif
        public float Z;

        #endregion Public Fields


        #region Properties

        public static V3 Zero
        {
            get { return zero; }
        }

        public static V3 One
        {
            get { return one; }
        }

        public static V3 UnitX
        {
            get { return unitX; }
        }

        public static V3 UnitY
        {
            get { return unitY; }
        }

        public static V3 UnitZ
        {
            get { return unitZ; }
        }

        public static V3 Up
        {
            get { return up; }
        }

        public static V3 Down
        {
            get { return down; }
        }

        public static V3 Right
        {
            get { return right; }
        }

        public static V3 Left
        {
            get { return left; }
        }

        public static V3 Forward
        {
            get { return forward; }
        }

        public static V3 Backward
        {
            get { return backward; }
        }

        #endregion Properties


        #region Constructors

        public V3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }


        public V3(float value)
        {
            this.X = value;
            this.Y = value;
            this.Z = value;
        }


        public V3(V2 value, float z)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = z;
        }


        #endregion Constructors


        #region Public Methods

        public static V3 Add(V3 value1, V3 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            value1.Z += value2.Z;
            return value1;
        }

        public static void Add(ref V3 value1, ref V3 value2, out V3 result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            result.Z = value1.Z + value2.Z;
        }

        public static V3 Barycentric(V3 value1, V3 value2, V3 value3, float amount1, float amount2)
        {
            return new V3(
                MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
                MathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2));
        }

        public static void Barycentric(ref V3 value1, ref V3 value2, ref V3 value3, float amount1, float amount2, out V3 result)
        {
            result = new V3(
                MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
                MathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2));
        }

        public static V3 CatmullRom(V3 value1, V3 value2, V3 value3, V3 value4, float amount)
        {
            return new V3(
                MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
                MathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount));
        }

        public static void CatmullRom(ref V3 value1, ref V3 value2, ref V3 value3, ref V3 value4, float amount, out V3 result)
        {
            result = new V3(
                MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
                MathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount));
        }

        public static V3 Clamp(V3 value1, V3 min, V3 max)
        {
            return new V3(
                MathHelper.Clamp(value1.X, min.X, max.X),
                MathHelper.Clamp(value1.Y, min.Y, max.Y),
                MathHelper.Clamp(value1.Z, min.Z, max.Z));
        }

        public static void Clamp(ref V3 value1, ref V3 min, ref V3 max, out V3 result)
        {
            result = new V3(
                MathHelper.Clamp(value1.X, min.X, max.X),
                MathHelper.Clamp(value1.Y, min.Y, max.Y),
                MathHelper.Clamp(value1.Z, min.Z, max.Z));
        }

        public static V3 Cross(V3 vector1, V3 V2)
        {
            Cross(ref vector1, ref V2, out vector1);
            return vector1;
        }

        public static void Cross(ref V3 vector1, ref V3 V2, out V3 result)
        {
            result = new V3(vector1.Y * V2.Z - V2.Y * vector1.Z,
                                 -(vector1.X * V2.Z - V2.X * vector1.Z),
                                 vector1.X * V2.Y - V2.X * vector1.Y);
        }

        public static float Distance(V3 vector1, V3 V2)
        {
            float result;
            DistanceSquared(ref vector1, ref V2, out result);
            return (float)Math.Sqrt(result);
        }

        public static void Distance(ref V3 value1, ref V3 value2, out float result)
        {
            DistanceSquared(ref value1, ref value2, out result);
            result = (float)Math.Sqrt(result);
        }

        public static float DistanceSquared(V3 value1, V3 value2)
        {
            float result;
            DistanceSquared(ref value1, ref value2, out result);
            return result;
        }

        public static void DistanceSquared(ref V3 value1, ref V3 value2, out float result)
        {
            result = (value1.X - value2.X) * (value1.X - value2.X) +
                     (value1.Y - value2.Y) * (value1.Y - value2.Y) +
                     (value1.Z - value2.Z) * (value1.Z - value2.Z);
        }

        public static V3 Divide(V3 value1, V3 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            value1.Z /= value2.Z;
            return value1;
        }

        public static V3 Divide(V3 value1, float value2)
        {
            float factor = 1 / value2;
            value1.X *= factor;
            value1.Y *= factor;
            value1.Z *= factor;
            return value1;
        }

        public static void Divide(ref V3 value1, float divisor, out V3 result)
        {
            float factor = 1 / divisor;
            result.X = value1.X * factor;
            result.Y = value1.Y * factor;
            result.Z = value1.Z * factor;
        }

        public static void Divide(ref V3 value1, ref V3 value2, out V3 result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
            result.Z = value1.Z / value2.Z;
        }

        public static float Dot(V3 vector1, V3 V2)
        {
            return vector1.X * V2.X + vector1.Y * V2.Y + vector1.Z * V2.Z;
        }

        public static void Dot(ref V3 vector1, ref V3 V2, out float result)
        {
            result = vector1.X * V2.X + vector1.Y * V2.Y + vector1.Z * V2.Z;
        }

        public override bool Equals(object obj)
        {
            return (obj is V3) ? this == (V3)obj : false;
        }

        public bool Equals(V3 other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return (int)(this.X + this.Y + this.Z);
        }

        public static V3 Hermite(V3 value1, V3 tangent1, V3 value2, V3 tangent2, float amount)
        {
            V3 result = new V3();
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
            return result;
        }

        public static void Hermite(ref V3 value1, ref V3 tangent1, ref V3 value2, ref V3 tangent2, float amount, out V3 result)
        {
            result.X = MathHelper.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount);
            result.Y = MathHelper.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
            result.Z = MathHelper.Hermite(value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount);
        }

        public float Length()
        {
            float result;
            DistanceSquared(ref this, ref zero, out result);
            return (float)Math.Sqrt(result);
        }

        public float LengthSquared()
        {
            float result;
            DistanceSquared(ref this, ref zero, out result);
            return result;
        }

        public static V3 Lerp(V3 value1, V3 value2, float amount)
        {
            return new V3(
                MathHelper.Lerp(value1.X, value2.X, amount),
                MathHelper.Lerp(value1.Y, value2.Y, amount),
                MathHelper.Lerp(value1.Z, value2.Z, amount));
        }

        public static void Lerp(ref V3 value1, ref V3 value2, float amount, out V3 result)
        {
            result = new V3(
                MathHelper.Lerp(value1.X, value2.X, amount),
                MathHelper.Lerp(value1.Y, value2.Y, amount),
                MathHelper.Lerp(value1.Z, value2.Z, amount));
        }
                
        public static V3 Max(V3 value1, V3 value2)
        {
            return new V3(
                MathHelper.Max(value1.X, value2.X),
                MathHelper.Max(value1.Y, value2.Y),
                MathHelper.Max(value1.Z, value2.Z));
        }

        public static void Max(ref V3 value1, ref V3 value2, out V3 result)
        {
            result = new V3(
                MathHelper.Max(value1.X, value2.X),
                MathHelper.Max(value1.Y, value2.Y),
                MathHelper.Max(value1.Z, value2.Z));
        }

        public static V3 Min(V3 value1, V3 value2)
        {
            return new V3(
                MathHelper.Min(value1.X, value2.X),
                MathHelper.Min(value1.Y, value2.Y),
                MathHelper.Min(value1.Z, value2.Z));
        }

        public static void Min(ref V3 value1, ref V3 value2, out V3 result)
        {
            result = new V3(
                MathHelper.Min(value1.X, value2.X),
                MathHelper.Min(value1.Y, value2.Y),
                MathHelper.Min(value1.Z, value2.Z));
        }

        public static V3 Multiply(V3 value1, V3 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            value1.Z *= value2.Z;
            return value1;
        }

        public static V3 Multiply(V3 value1, float scaleFactor)
        {
            value1.X *= scaleFactor;
            value1.Y *= scaleFactor;
            value1.Z *= scaleFactor;
            return value1;
        }

        public static void Multiply(ref V3 value1, float scaleFactor, out V3 result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
            result.Z = value1.Z * scaleFactor;
        }

        public static void Multiply(ref V3 value1, ref V3 value2, out V3 result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
            result.Z = value1.Z * value2.Z;
        }

        public static V3 Negate(V3 value)
        {
            value = new V3(-value.X, -value.Y, -value.Z);
            return value;
        }

        public static void Negate(ref V3 value, out V3 result)
        {
            result = new V3(-value.X, -value.Y, -value.Z);
        }

        public void Normalize()
        {
            Normalize(ref this, out this);
        }

        public static V3 Normalize(V3 vector)
        {
            Normalize(ref vector, out vector);
            return vector;
        }

        public static void Normalize(ref V3 value, out V3 result)
        {
            float factor;
            Distance(ref value, ref zero, out factor);
            factor = 1f / factor;
            result.X = value.X * factor;
            result.Y = value.Y * factor;
            result.Z = value.Z * factor;
        }

	public static V3 Reflect(V3 vector, V3 normal)
	{
		// I is the original array
		// N is the normal of the incident plane
		// R = I - (2 * N * ( DotProduct[ I,N] ))
		V3 reflectedVector;
		// inline the dotProduct here instead of calling method
		float dotProduct = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);
		reflectedVector.X = vector.X - (2.0f * normal.X) * dotProduct;
		reflectedVector.Y = vector.Y - (2.0f * normal.Y) * dotProduct;
		reflectedVector.Z = vector.Z - (2.0f * normal.Z) * dotProduct;

		return reflectedVector;
	}

	public static void Reflect(ref V3 vector, ref V3 normal, out V3 result)
	{
		// I is the original array
		// N is the normal of the incident plane
		// R = I - (2 * N * ( DotProduct[ I,N] ))

		// inline the dotProduct here instead of calling method
		float dotProduct = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);
		result.X = vector.X - (2.0f * normal.X) * dotProduct;
		result.Y = vector.Y - (2.0f * normal.Y) * dotProduct;
		result.Z = vector.Z - (2.0f * normal.Z) * dotProduct;

	}
		
        public static V3 SmoothStep(V3 value1, V3 value2, float amount)
        {
            return new V3(
                MathHelper.SmoothStep(value1.X, value2.X, amount),
                MathHelper.SmoothStep(value1.Y, value2.Y, amount),
                MathHelper.SmoothStep(value1.Z, value2.Z, amount));
        }

        public static void SmoothStep(ref V3 value1, ref V3 value2, float amount, out V3 result)
        {
            result = new V3(
                MathHelper.SmoothStep(value1.X, value2.X, amount),
                MathHelper.SmoothStep(value1.Y, value2.Y, amount),
                MathHelper.SmoothStep(value1.Z, value2.Z, amount));
        }

        public static V3 Subtract(V3 value1, V3 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            value1.Z -= value2.Z;
            return value1;
        }

        public static void Subtract(ref V3 value1, ref V3 value2, out V3 result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
            result.Z = value1.Z - value2.Z;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(32);
            sb.Append("{X:");
            sb.Append(this.X);
            sb.Append(" Y:");
            sb.Append(this.Y);
            sb.Append(" Z:");
            sb.Append(this.Z);
            sb.Append("}");
            return sb.ToString();
        }

        #endregion Public methods


        #region Operators

        public static bool operator ==(V3 value1, V3 value2)
        {
            return value1.X == value2.X
                && value1.Y == value2.Y
                && value1.Z == value2.Z;
        }

        public static bool operator !=(V3 value1, V3 value2)
        {
            return !(value1 == value2);
        }

        public static V3 operator +(V3 value1, V3 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            value1.Z += value2.Z;
            return value1;
        }

        public static V3 operator -(V3 value)
        {
            value = new V3(-value.X, -value.Y, -value.Z);
            return value;
        }

        public static V3 operator -(V3 value1, V3 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            value1.Z -= value2.Z;
            return value1;
        }

        public static V3 operator *(V3 value1, V3 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            value1.Z *= value2.Z;
            return value1;
        }

        public static V3 operator *(V3 value, float scaleFactor)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            value.Z *= scaleFactor;
            return value;
        }

        public static V3 operator *(float scaleFactor, V3 value)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            value.Z *= scaleFactor;
            return value;
        }

        public static V3 operator /(V3 value1, V3 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            value1.Z /= value2.Z;
            return value1;
        }

        public static V3 operator /(V3 value, float divider)
        {
            float factor = 1 / divider;
            value.X *= factor;
            value.Y *= factor;
            value.Z *= factor;
            return value;
        }

        #endregion
    }
}
