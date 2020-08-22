
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Extensions
{
    public static class VectorExtentions
    {
        public static Color ToColorRGB(this Vector4 v)
        {
            return new Color(v.x, v.y, v.z, v.w);
        }
        public static Color ToColorRGB(this Vector3 v)
        {
            return new Color(v.x, v.y, v.z, 1);
        }
        public static Color ToColorHSV(this Vector4 v)
        {
            return Color.HSVToRGB(v.x, v.y, v.z).SetA(v.w);
        }
        public static Color ToColorHSV(this Vector3 v)
        {
            return Color.HSVToRGB(v.x, v.y, v.z);
        }
        public static Vector4 ScaleChain(this Vector4 t, Vector4 o)
        {
            return Vector4.Scale(t,o);
        }
        public static Vector3 ScaleChain(this Vector3 t, Vector3 o)
        {
            return Vector3.Scale(t, o);
        }
        public static Vector2 ScaleChain(this Vector2 t, Vector2 o)
        {
            return Vector2.Scale(t, o);
        }
        public static Vector4 setX(this Vector4 v, float value)
        {
            v.x = value;
            return v;
        }
        public static Vector4 setY(this Vector4 v, float value)
        {
            v.y = value;
            return v;
        }
        public static Vector4 setZ(this Vector4 v, float value)
        {
            v.z = value;
            return v;
        }
        public static Vector4 setW(this Vector4 v, float value)
        {
            v.w = value;
            return v;
        }

        public static Vector3 setX(this Vector3 v, float value)
        {
            return ((Vector4)v).setX(value);
        }
        public static Vector3 setY(this Vector3 v, float value)
        {
            return ((Vector4)v).setY(value);
        }
        public static Vector3 setZ(this Vector3 v, float value)
        {
            return ((Vector4)v).setZ(value);
        }

        public static Vector2 setX(this Vector2 v, float value)
        {
            return ((Vector4)v).setX(value);
        }
        public static Vector2 setY(this Vector2 v, float value)
        {
            return ((Vector4)v).setY(value);
        }
    }
}