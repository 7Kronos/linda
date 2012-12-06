using System;
using System.Text;

namespace LindaEngine.Framework
{
    public struct V4 : IEquatable<V4>
    {
        #region Private Fields

        private static V4 zeroVector = new V4();
        private static V4 unitVector = new V4(1f, 1f, 1f, 1f);
        private static V4 unitXVector = new V4(1f, 0f, 0f, 0f);
        private static V4 unitYVector = new V4(0f, 1f, 0f, 0f);
        private static V4 unitZVector = new V4(0f, 0f, 1f, 0f);
        private static V4 unitWVector = new V4(0f, 0f, 0f, 1f);

        #endregion Private Fields


        #region Public Fields

        public float X;
        public float Y;
        public float Z;
        public float W;

        #endregion Public Fields


        #region Properties

        public static V4 Zero
        {
            get { return zeroVector; }
        }

        public static V4 One
        {
            get { return unitVector; }
        }

        public static V4 UnitX
        {
            get { return unitXVector; }
        }

        public static V4 UnitY
        {
            get { return unitYVector; }
        }

        public static V4 UnitZ
        {
            get { return unitZVector; }
        }

        public static V4 UnitW
        {
            get { return unitWVector; }
        }

        #endregion Properties


        #region Constructors

        public V4(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public V4(V2 value, float z, float w)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = z;
            this.W = w;
        }

        public V4(V3 value, float w)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
            this.W = w;
        }

        public V4(float value)
        {
            this.X = value;
            this.Y = value;
            this.Z = value;
            this.W = value;
        }

        #endregion


        #region Public Methods

        public static V4 Add(V4 value1, V4 value2)
        {
            value1.W += value2.W;
            value1.X += value2.X;
            value1.Y += value2.Y;
            value1.Z += value2.Z;
            return value1;
        }

        public static void Add(ref V4 value1, ref V4 value2, out V4 result)
        {
            result.W = value1.W + value2.W;
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            result.Z = value1.Z + value2.Z;
        }

        public static V4 Barycentric(V4 value1, V4 value2, V4 value3, float amount1, float amount2)
        {
#if(USE_FARSEER)
            return new V4(
                SilverSpriteMathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                SilverSpriteMathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
                SilverSpriteMathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2),
                SilverSpriteMathHelper.Barycentric(value1.W, value2.W, value3.W, amount1, amount2));
#else
            return new V4(
                MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
                MathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2),
                MathHelper.Barycentric(value1.W, value2.W, value3.W, amount1, amount2));
#endif
        }

        public static void Barycentric(ref V4 value1, ref V4 value2, ref V4 value3, float amount1, float amount2, out V4 result)
        {
#if(USE_FARSEER)
            result = new V4(
                SilverSpriteMathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                SilverSpriteMathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
                SilverSpriteMathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2),
                SilverSpriteMathHelper.Barycentric(value1.W, value2.W, value3.W, amount1, amount2));
#else
            result = new V4(
                MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
                MathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2),
                MathHelper.Barycentric(value1.W, value2.W, value3.W, amount1, amount2));
#endif
        }

        public static V4 CatmullRom(V4 value1, V4 value2, V4 value3, V4 value4, float amount)
        {
#if(USE_FARSEER)
            return new V4(
                SilverSpriteMathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                SilverSpriteMathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
                SilverSpriteMathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount),
                SilverSpriteMathHelper.CatmullRom(value1.W, value2.W, value3.W, value4.W, amount));
#else
            return new V4(
                MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
                MathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount),
                MathHelper.CatmullRom(value1.W, value2.W, value3.W, value4.W, amount));
#endif
        }

        public static void CatmullRom(ref V4 value1, ref V4 value2, ref V4 value3, ref V4 value4, float amount, out V4 result)
        {
#if(USE_FARSEER)
            result = new V4(
                SilverSpriteMathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                SilverSpriteMathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
                SilverSpriteMathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount),
                SilverSpriteMathHelper.CatmullRom(value1.W, value2.W, value3.W, value4.W, amount));
#else
            result = new V4(
                MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
                MathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount),
                MathHelper.CatmullRom(value1.W, value2.W, value3.W, value4.W, amount));
#endif
        }

        public static V4 Clamp(V4 value1, V4 min, V4 max)
        {
            return new V4(
                MathHelper.Clamp(value1.X, min.X, max.X),
                MathHelper.Clamp(value1.Y, min.Y, max.Y),
                MathHelper.Clamp(value1.Z, min.Z, max.Z),
                MathHelper.Clamp(value1.W, min.W, max.W));
        }

        public static void Clamp(ref V4 value1, ref V4 min, ref V4 max, out V4 result)
        {
            result = new V4(
                MathHelper.Clamp(value1.X, min.X, max.X),
                MathHelper.Clamp(value1.Y, min.Y, max.Y),
                MathHelper.Clamp(value1.Z, min.Z, max.Z),
                MathHelper.Clamp(value1.W, min.W, max.W));
        }

        public static float Distance(V4 value1, V4 value2)
        {
            return (float)Math.Sqrt(DistanceSquared(value1, value2));
        }

        public static void Distance(ref V4 value1, ref V4 value2, out float result)
        {
            result = (float)Math.Sqrt(DistanceSquared(value1, value2));
        }

        public static float DistanceSquared(V4 value1, V4 value2)
        {
            float result;
            DistanceSquared(ref value1, ref value2, out result);
            return result;
        }

        public static void DistanceSquared(ref V4 value1, ref V4 value2, out float result)
        {
            result = (value1.W - value2.W) * (value1.W - value2.W) +
                     (value1.X - value2.X) * (value1.X - value2.X) +
                     (value1.Y - value2.Y) * (value1.Y - value2.Y) +
                     (value1.Z - value2.Z) * (value1.Z - value2.Z);
        }

        public static V4 Divide(V4 value1, V4 value2)
        {
            value1.W /= value2.W;
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            value1.Z /= value2.Z;
            return value1;
        }

        public static V4 Divide(V4 value1, float divider)
        {
            float factor = 1f / divider;
            value1.W *= factor;
            value1.X *= factor;
            value1.Y *= factor;
            value1.Z *= factor;
            return value1;
        }

        public static void Divide(ref V4 value1, float divider, out V4 result)
        {
            float factor = 1f / divider;
            result.W = value1.W * factor;
            result.X = value1.X * factor;
            result.Y = value1.Y * factor;
            result.Z = value1.Z * factor;
        }

        public static void Divide(ref V4 value1, ref V4 value2, out V4 result)
        {
            result.W = value1.W / value2.W;
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
            result.Z = value1.Z / value2.Z;
        }

        public static float Dot(V4 vector1, V4 V2)
        {
            return vector1.X * V2.X + vector1.Y * V2.Y + vector1.Z * V2.Z + vector1.W * V2.W;
        }

        public static void Dot(ref V4 vector1, ref V4 V2, out float result)
        {
            result = vector1.X * V2.X + vector1.Y * V2.Y + vector1.Z * V2.Z + vector1.W * V2.W;
        }

        public override bool Equals(object obj)
        {
            return (obj is V4) ? this == (V4)obj : false;
        }

        public bool Equals(V4 other)
        {
            return this.W == other.W
                && this.X == other.X
                && this.Y == other.Y
                && this.Z == other.Z;
        }

        public override int GetHashCode()
        {
            return (int)(this.W + this.X + this.Y + this.Y);
        }

        public static V4 Hermite(V4 value1, V4 tangent1, V4 value2, V4 tangent2, float amount)
        {
            V4 result = new V4();
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
            return result;
        }

        public static void Hermite(ref V4 value1, ref V4 tangent1, ref V4 value2, ref V4 tangent2, float amount, out V4 result)
        {
#if(USE_FARSEER)
            result.W = SilverSpriteMathHelper.Hermite(value1.W, tangent1.W, value2.W, tangent2.W, amount);
            result.X = SilverSpriteMathHelper.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount);
            result.Y = SilverSpriteMathHelper.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
            result.Z = SilverSpriteMathHelper.Hermite(value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount);
#else
            result.W = MathHelper.Hermite(value1.W, tangent1.W, value2.W, tangent2.W, amount);
            result.X = MathHelper.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount);
            result.Y = MathHelper.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
            result.Z = MathHelper.Hermite(value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount);
#endif
        }

        public float Length()
        {
            float result;
            DistanceSquared(ref this, ref zeroVector, out result);
            return (float)Math.Sqrt(result);
        }

        public float LengthSquared()
        {
            float result;
            DistanceSquared(ref this, ref zeroVector, out result);
            return result;
        }

        public static V4 Lerp(V4 value1, V4 value2, float amount)
        {
            return new V4(
                MathHelper.Lerp(value1.X, value2.X, amount),
                MathHelper.Lerp(value1.Y, value2.Y, amount),
                MathHelper.Lerp(value1.Z, value2.Z, amount),
                MathHelper.Lerp(value1.W, value2.W, amount));
        }

        public static void Lerp(ref V4 value1, ref V4 value2, float amount, out V4 result)
        {
            result = new V4(
                MathHelper.Lerp(value1.X, value2.X, amount),
                MathHelper.Lerp(value1.Y, value2.Y, amount),
                MathHelper.Lerp(value1.Z, value2.Z, amount),
                MathHelper.Lerp(value1.W, value2.W, amount));
        }

        public static V4 Max(V4 value1, V4 value2)
        {
            return new V4(
               MathHelper.Max(value1.X, value2.X),
               MathHelper.Max(value1.Y, value2.Y),
               MathHelper.Max(value1.Z, value2.Z),
               MathHelper.Max(value1.W, value2.W));
        }

        public static void Max(ref V4 value1, ref V4 value2, out V4 result)
        {
            result = new V4(
               MathHelper.Max(value1.X, value2.X),
               MathHelper.Max(value1.Y, value2.Y),
               MathHelper.Max(value1.Z, value2.Z),
               MathHelper.Max(value1.W, value2.W));
        }

        public static V4 Min(V4 value1, V4 value2)
        {
            return new V4(
               MathHelper.Min(value1.X, value2.X),
               MathHelper.Min(value1.Y, value2.Y),
               MathHelper.Min(value1.Z, value2.Z),
               MathHelper.Min(value1.W, value2.W));
        }

        public static void Min(ref V4 value1, ref V4 value2, out V4 result)
        {
            result = new V4(
               MathHelper.Min(value1.X, value2.X),
               MathHelper.Min(value1.Y, value2.Y),
               MathHelper.Min(value1.Z, value2.Z),
               MathHelper.Min(value1.W, value2.W));
        }

        public static V4 Multiply(V4 value1, V4 value2)
        {
            value1.W *= value2.W;
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            value1.Z *= value2.Z;
            return value1;
        }

        public static V4 Multiply(V4 value1, float scaleFactor)
        {
            value1.W *= scaleFactor;
            value1.X *= scaleFactor;
            value1.Y *= scaleFactor;
            value1.Z *= scaleFactor;
            return value1;
        }

        public static void Multiply(ref V4 value1, float scaleFactor, out V4 result)
        {
            result.W = value1.W * scaleFactor;
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
            result.Z = value1.Z * scaleFactor;
        }

        public static void Multiply(ref V4 value1, ref V4 value2, out V4 result)
        {
            result.W = value1.W * value2.W;
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
            result.Z = value1.Z * value2.Z;
        }

        public static V4 Negate(V4 value)
        {
            value = new V4(-value.X, -value.Y, -value.Z, -value.W);
            return value;
        }

        public static void Negate(ref V4 value, out V4 result)
        {
            result = new V4(-value.X, -value.Y, -value.Z,-value.W);
        }

        public void Normalize()
        {
            Normalize(ref this, out this);
        }

        public static V4 Normalize(V4 vector)
        {
            Normalize(ref vector, out vector);
            return vector;
        }

        public static void Normalize(ref V4 vector, out V4 result)
        {
            float factor;
            DistanceSquared(ref vector, ref zeroVector, out factor);
            factor = 1f / (float)Math.Sqrt(factor);

            result.W = vector.W * factor;
            result.X = vector.X * factor;
            result.Y = vector.Y * factor;
            result.Z = vector.Z * factor;
        }

        public static V4 SmoothStep(V4 value1, V4 value2, float amount)
        {
#if(USE_FARSEER)
            return new V4(
                SilverSpriteMathHelper.SmoothStep(value1.X, value2.X, amount),
                SilverSpriteMathHelper.SmoothStep(value1.Y, value2.Y, amount),
                SilverSpriteMathHelper.SmoothStep(value1.Z, value2.Z, amount),
                SilverSpriteMathHelper.SmoothStep(value1.W, value2.W, amount));
#else
            return new V4(
                MathHelper.SmoothStep(value1.X, value2.X, amount),
                MathHelper.SmoothStep(value1.Y, value2.Y, amount),
                MathHelper.SmoothStep(value1.Z, value2.Z, amount),
                MathHelper.SmoothStep(value1.W, value2.W, amount));
#endif
        }

        public static void SmoothStep(ref V4 value1, ref V4 value2, float amount, out V4 result)
        {
#if(USE_FARSEER)
            result = new V4(
                SilverSpriteMathHelper.SmoothStep(value1.X, value2.X, amount),
                SilverSpriteMathHelper.SmoothStep(value1.Y, value2.Y, amount),
                SilverSpriteMathHelper.SmoothStep(value1.Z, value2.Z, amount),
                SilverSpriteMathHelper.SmoothStep(value1.W, value2.W, amount));
#else
            result = new V4(
                MathHelper.SmoothStep(value1.X, value2.X, amount),
                MathHelper.SmoothStep(value1.Y, value2.Y, amount),
                MathHelper.SmoothStep(value1.Z, value2.Z, amount),
                MathHelper.SmoothStep(value1.W, value2.W, amount));
#endif
        }

        public static V4 Subtract(V4 value1, V4 value2)
        {
            value1.W -= value2.W;
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            value1.Z -= value2.Z;
            return value1;
        }

        public static void Subtract(ref V4 value1, ref V4 value2, out V4 result)
        {
            result.W = value1.W - value2.W;
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
            sb.Append(" W:");
            sb.Append(this.W);
            sb.Append("}");
            return sb.ToString();
        }

        #endregion Public Methods


        #region Operators

        public static V4 operator -(V4 value)
        {
            return new V4(-value.X, -value.Y, -value.Z, -value.W);
        }

        public static bool operator ==(V4 value1, V4 value2)
        {
            return value1.W == value2.W
                && value1.X == value2.X
                && value1.Y == value2.Y
                && value1.Z == value2.Z;
        }

        public static bool operator !=(V4 value1, V4 value2)
        {
            return !(value1 == value2);
        }

        public static V4 operator +(V4 value1, V4 value2)
        {
            value1.W += value2.W;
            value1.X += value2.X;
            value1.Y += value2.Y;
            value1.Z += value2.Z;
            return value1;
        }

        public static V4 operator -(V4 value1, V4 value2)
        {
            value1.W -= value2.W;
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            value1.Z -= value2.Z;
            return value1;
        }

        public static V4 operator *(V4 value1, V4 value2)
        {
            value1.W *= value2.W;
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            value1.Z *= value2.Z;
            return value1;
        }

        public static V4 operator *(V4 value1, float scaleFactor)
        {
            value1.W *= scaleFactor;
            value1.X *= scaleFactor;
            value1.Y *= scaleFactor;
            value1.Z *= scaleFactor;
            return value1;
        }

        public static V4 operator *(float scaleFactor, V4 value1)
        {
            value1.W *= scaleFactor;
            value1.X *= scaleFactor;
            value1.Y *= scaleFactor;
            value1.Z *= scaleFactor;
            return value1;
        }

        public static V4 operator /(V4 value1, V4 value2)
        {
            value1.W /= value2.W;
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            value1.Z /= value2.Z;
            return value1;
        }

        public static V4 operator /(V4 value1, float divider)
        {
            float factor = 1f / divider;
            value1.W *= factor;
            value1.X *= factor;
            value1.Y *= factor;
            value1.Z *= factor;
            return value1;
        }

        #endregion Operators
    }
}
