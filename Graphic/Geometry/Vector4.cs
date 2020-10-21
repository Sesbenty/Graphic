using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic.Geometry
{
    public struct Vector4
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float w { get; set; }


        public Vector4(float x, float y)
        {
            this.x = x;
            this.y = y;
            z = 0;
            w = 1;
        }
        public Vector4(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            w = 1;
        }
        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public void Set(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public void AngleAtCenter(float a, Vector4 center)
        {
            x -= center.x;
            y -= center.y;
            z -= center.z;
            w -= center.w;
            Matrix4x4.MatrixRotateZ(a).Mult(this);

            x += center.x;
            y += center.y;
            z += center.z;
            w += center.w;
        }
        public static Vector4 operator+(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }

    }
}
