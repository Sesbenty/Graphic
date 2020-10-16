using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic.Geometry
{
    class Matrix4x4
    {
        float[] vs;

        public Matrix4x4()
        {
            vs = new float[16];
        }

        public static Matrix4x4 MatrixRotateX(double a)
        {
            Matrix4x4 m = new Matrix4x4();

            float cosa = (float)Math.Cos(a);
            float sina = (float)Math.Sin(a);

            m.vs[0] = 1;
            m.vs[5] = cosa;
            m.vs[6] = -sina;
            m.vs[9] = sina;
            m.vs[10] = cosa;
            m.vs[15] = 1; 

            return m;
        }

        public static Matrix4x4 MatrixRotateY(double a)
        {
            Matrix4x4 m = new Matrix4x4();

            float cosa = (float)Math.Cos(a);
            float sina = (float)Math.Sin(a);

            m.vs[0] = cosa;
            m.vs[2] = -sina;
            m.vs[8] = sina;
            m.vs[10] = cosa;

            m.vs[5] = 1;
            m.vs[15] = 1;

            return m;
        }

        public static Matrix4x4 MatrixRotateZ(double a)
        {
            Matrix4x4 m = new Matrix4x4();

            float cosa = (float)Math.Cos(a);
            float sina = (float)Math.Sin(a);

            m.vs[0] = cosa;
            m.vs[1] = sina;
            m.vs[4] = -sina;
            m.vs[5] = cosa;

            m.vs[10] = 1;
            m.vs[15] = 1;

            return m;
        }

        public void Mult(Vector4 v)
        {
            float x = v.x * vs[0] + v.y * vs[1] + v.z * vs[2] + v.w * vs[3] ;
            float y = v.x * vs[4] + v.y * vs[5] + v.z * vs[6] + v.w * vs[7];
            float z = v.x * vs[8] + v.y * vs[9] + v.z * vs[10] + v.w * vs[11];
            float w = v.x * vs[12] + v.y * vs[13] + v.z * vs[14] + v.w * vs[15];

            v.Set(x, y, z, w);
        }
    }
}
