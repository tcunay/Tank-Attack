using UnityEngine;

namespace Code.Common.Extensions
{
    public static class ColorExtensions
    {
        public static Color AlphaMultiplied(this Color c, float multiplier)
        {
            return new Color(c.r, c.g, c.b, c.a * multiplier);
        }
    }
}