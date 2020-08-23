
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Extensions
{
    public static class ColorExtentions
    {

        public static Color SetR(this Color c, float v)
        {
            c.r = v;
            return c;
        }
        public static Color SetG(this Color c, float v)
        {

            c.g = v;
            return c;
        }
        public static Color SetB(this Color c, float v)
        {
            c.b = v;
            return c;
        }

        public static Color SetA(this Color c, float v)
        {
            c.a = v;
            return c;
        }
        /// <summary>
        /// converts a color to hsv h=x s=y v=z w=a
        /// </summary>
        /// <param name="c">color to convert to HSV vector</param>
        /// <returns></returns>
        public static Vector4 ColorToHSV(this Color c)
        {
            Vector4 f = new Vector3();
            Color.RGBToHSV(c, out f.x, out f.y, out f.z);
            f.w = c.a;
            return f;
        }
        public static Color avrageColor(this IEnumerable<Color> c)
        {
            var count = c.Count();
            if (c== null || count < 1)
                return new Color(0, 0, 0, 0);
            return (c.Select(i => i.ColorToHSV()).Aggregate((c1, c2) => c1 + c2) * (1f / count)).ToColorHSV();
        }
        /// <summary>
        /// converts color to a vector4 r=x g=y b=z a=w
        /// </summary>
        /// <param name="c">color to convert to RGB vector</param>
        /// <returns></returns>
        public static Vector4 ToVector(this Color c)
        {
            return new Vector4(c.r, c.g, c.b, c.a);
        }
    }
}