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
    }
}
