using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic.Geometry
{
    class Matrix2x2
    {
        private float[] vs;

        public Matrix2x2()
        {
            vs = new float[4];
        }

        public static Matrix2x2 MatrixRotate(double a)
        {
            Matrix2x2 m = new Matrix2x2();

            float cosa = (float)Math.Cos(a);
            float sina = (float)Math.Sin(a);

            m.vs[0] = cosa;
            m.vs[1] = -sina;
            m.vs[2] = sina;
            m.vs[3] = cosa;

            return m;
        }

        public void Mult(Vector2 v)
        {
            v.x = v.x * vs[0] + v.y * vs[2];
            v.y = v.x * vs[1] + v.y * vs[3];
        } 
    }
}
