using System;

namespace InfiniteScrollViewer
{
    internal static class MathUtil
    {
        public static double Clamp(this double value , double min , double max)
        {
            return Math.Max(min, Math.Min(value, max));
        }
    }
}