using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic.Geometry
{
    class Matrix3x3
    {
        float[] vs;

        public Matrix3x3()
        {
            vs = new float[9];
        }

       

        public static Matrix3x3 MatrixRotateX(double a)
        {
            Matrix3x3 m = new Matrix3x3();

            float cosa = Convert.ToSingle(Math.Cos(a));
            float sina = Convert.ToSingle(Math.Sin(a));

            m.vs[0] = 1;

            m.vs[4] = cosa;
            m.vs[5] = sina;
            m.vs[7] = -sina;
            m.vs[8] = cosa;

            return m;
        }
        public static Matrix3x3 MatrixRotateY(double a)
        {
            Matrix3x3 m = new Matrix3x3();

            float cosa = (float)Math.Cos(a);
            float sina = (float)Math.Sin(a);

            m.vs[0] = cosa;
            m.vs[2] = -sina;
            m.vs[6] = sina;
            m.vs[8] = cosa;

            m.vs[4] = 1;

            return m;
        }
        public static Matrix3x3 MatrixRotateZ(double a)
        {
            Matrix3x3 m = new Matrix3x3();

            float cosa = (float)Math.Cos(a);
            float sina = (float)Math.Sin(a);

            m.vs[0] = cosa;
            m.vs[1] = sina;
            m.vs[3] = -sina;
            m.vs[4] = cosa;

            m.vs[8] = 1;

            return m;
        }

        public static Matrix3x3 MatrixScale(float a)
        {
            Matrix3x3 m = new Matrix3x3();
            m.vs[0] = 1;
            m.vs[4] = 1;
            m.vs[8] = a;

            return m;
        }

        public static Matrix3x3 Mat90()
        {
            Matrix3x3 m = new Matrix3x3();

            m.vs[0] = 0;
            m.vs[1] = 1;
            m.vs[3] = -1;
            m.vs[4] = 0;

            m.vs[8] = 1;

            return m;
        }
        public void Mult(Vector3 v)
        {
            float x = vs[0] * v.x + vs[1] * v.y + vs[2] * v.z;
            float y = vs[3] * v.x + vs[4] * v.y + vs[5] * v.z;
            float z = vs[6] * v.x + vs[7] * v.y + vs[8] * v.z;

            v.Set(x, y, z);
        }
    }
}
