using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic.Geometry
{
    public struct Vector3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public static Vector3 zero { get { return new Vector3(); } }


        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(float x, float y)
        {
            this.x = x;
            this.y = y;
            z = 0;
        }

        public void Set(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3 Normalize()
        {
            float lenght = Convert.ToSingle(Math.Sqrt((x * x) + (y * y) + (z * z)));
            if (lenght != 0) return new Vector3(x / lenght, y / lenght, z / lenght);
            return zero;
        }

        public static float Dot(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b) =>
            new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3 operator -(Vector3 a, Vector3 b) =>
            new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector3 operator *(Vector3 a, float b) =>
            new Vector3(a.x * b, a.y * b, a.z * b);
        public static Vector3 operator *(float b, Vector3 a) =>
            new Vector3(a.x * b, a.y * b, a.z * b);

        public static Vector3 operator +(Vector3 a, Vector2 b) =>
            new Vector3(a.x + b.x, a.y + b.y, a.z);

        public override string ToString()
        {
            return String.Format("Vector3: {0}, {1}, {2}",x,y,z);
        }
    }
}
