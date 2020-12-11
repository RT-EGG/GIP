using System;

namespace GIP.Common
{
    public static class NumericExtensions
    {
        const float con_FloatThreshold = 1.0e-6f;
        const float con_DoubleThreshold = 1.0e-10f;

        public static bool IsZero(this float aValue, float aThreshould = con_FloatThreshold)
        {
            return Math.Abs(aValue) <= aThreshould;
        }

        public static bool IsZero(this double aValue, double aThreshould = con_DoubleThreshold)
        {
            return Math.Abs(aValue) <= aThreshould;
        }

        public static bool AlmostEquals(this float aValue, float aValue2, float aThreshould = con_FloatThreshold)
        {
            return (aValue - aValue2).IsZero(aThreshould);
        }

        public static bool AlmostEquals(this double aValue, double aValue2, double aThreshould = con_DoubleThreshold)
        {
            return (aValue - aValue2).IsZero(aThreshould);
        }
    }
}
