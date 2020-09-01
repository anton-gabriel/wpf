using System;
using System.Windows;

namespace SmoothCurvedSegment
{
    internal static class VectorExtensions
    {
        public static Vector Lerp(this Vector source, in Vector target, double factor)
        {
            double clamp = (factor < 0.0) ? 0.0 : (factor > 1.0) ? 1.0 : factor;
            return source + ((target - source) * clamp);
        }
        public static Vector RotateRadians(this Vector v, double radians)
        {
            var ca = Math.Cos(radians);
            var sa = Math.Sin(radians);
            return new Vector(ca * v.X - sa * v.Y, sa * v.X + ca * v.Y);
        }
    }
}
