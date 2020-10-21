using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic.Geometry
{
    public struct Matrix4x4
    {
        private float[] vs;
        float this[int x,int y]
        {
            get { return vs[x + 4 * y]; }
            set { vs[x + 4 * y] = value; }
        }
        public static Matrix4x4 identity
        {
            get
            {
                Matrix4x4 m = new Matrix4x4();
                m.vs = new float[16];

                m.vs[0] = 1;
                m.vs[5] = 1;
                m.vs[10] = 1;
                m.vs[15] = 1;

                return m;
            }
        }
        public static Matrix4x4 zero
        {
            get
            {
                Matrix4x4 m = new Matrix4x4();
                m.vs = new float[16];

                return m;
            }
        }    

        public static Matrix4x4 MatrixRotateX(double a)
        {
            Matrix4x4 m = identity;

            float cosa = (float)Math.Cos(a);
            float sina = (float)Math.Sin(a);

            m.vs[5] = cosa;
            m.vs[6] = -sina;
            m.vs[9] = sina;
            m.vs[10] = cosa;

            return m;
        }

        public static Matrix4x4 MatrixRotateY(double a)
        {
            Matrix4x4 m = identity;

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
            Matrix4x4 m = identity;

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

        public static Matrix4x4 MatrixRotate(Quaternion q)
        {
            return MatrixRotateX(q.x) * MatrixRotateY(q.y) * MatrixRotateZ(q.z); 
        }

        public static Matrix4x4 MatrixTransform(float x, float y, float z)
        {
            Matrix4x4 m = identity;
            m.vs[3] = x;
            m.vs[7] = y;
            m.vs[11] = z;

            return m;
        }
        public static Matrix4x4 MatrixTransform(Vector3 a)
        {
            Matrix4x4 m = identity;
            m.vs[3] = a.x;
            m.vs[7] = a.y;
            m.vs[11] = a.z;

            return m;
        }

        public static Matrix4x4 MatrixLookAt(Vector3 eye, Vector3 center, Vector3 up)
        { 
            Vector3 z = (eye - center).Normalize();
            Vector3 x = Vector3.Cross(up, z).Normalize();
            Vector3 y = Vector3.Cross(z, x).Normalize();
            Matrix4x4 Minv = identity;
            Matrix4x4 Tr = identity;

            Minv.vs[0] = x.x;
            Minv.vs[1] = x.y;
            Minv.vs[2] = x.z;

            Minv.vs[4] = y.x;
            Minv.vs[5] = y.y;
            Minv.vs[6] = y.z;

            Minv.vs[8] = z.x;
            Minv.vs[9] = z.y;
            Minv.vs[10] = z.z;

            Tr.vs[3] = -eye.x;
            Tr.vs[7] = -eye.y;
            Tr.vs[11] = -eye.z;

            return Minv * Tr ;
        }

        public static Matrix4x4 MatrixViewPort(float x, float y, float w, float h)
        {
            Matrix4x4 m = identity;
            float depth = 255;

            m.vs[12] = x + w / 2;
            m.vs[13] = y + h / 2;
            m.vs[14] = depth / 2;

            m.vs[0] = w / 2;
            m.vs[5] = h / 2;
            m.vs[10] = depth / 2;
            return m;
        }

        public static Matrix4x4 MatrixProjection(float c)
        {
            Matrix4x4 m = identity;

            m.vs[0] = 1;
            m.vs[5] = 1;

            m.vs[14] = -1/c;

            m.vs[10] = 1;
            m.vs[15] = 1;

            return m;
        }

        public void Mult(Vector4 v)
        {
            float x = v.x * vs[0] + v.y * vs[1] + v.z * vs[2] + v.w * vs[3];
            float y = v.x * vs[4] + v.y * vs[5] + v.z * vs[6] + v.w * vs[7];
            float z = v.x * vs[8] + v.y * vs[9] + v.z * vs[10] + v.w * vs[11];
            float w = v.x * vs[12] + v.y * vs[13] + v.z * vs[14] + v.w * vs[15];

            v.Set(x, y, z, w);
        }

        public static Vector4 operator *(Matrix4x4 m, Vector4 v)
        {
            float x = v.x * m.vs[0] + v.y * m.vs[1] + v.z * m.vs[2] + v.w * m.vs[3];
            float y = v.x * m.vs[4] + v.y * m.vs[5] + v.z * m.vs[6] + v.w * m.vs[7];
            float z = v.x * m.vs[8] + v.y * m.vs[9] + v.z * m.vs[10] + v.w * m.vs[11];
            float w = v.x * m.vs[12] + v.y * m.vs[13] + v.z * m.vs[14] + v.w * m.vs[15];

            return new Vector4(x / w, y / w, z / w, 1);
        }

        public static Matrix4x4 operator *(Matrix4x4 a, Matrix4x4 b)
        {
            Matrix4x4 m = zero;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //Console.WriteLine("cell" + (4 * i + j));
                    for (int k = 0; k < 4; k++)
                    {
                        int aa = 4 * k + j;
                        int bb = k + 4 * i;
                        //Console.Write(aa + " x " + bb + "   ");
                        m.vs[4 * i + j] += a.vs[aa] * b.vs[bb];
                    }
                    //Console.WriteLine();
                }
            }
            return m;
        }

        public void String()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(vs[4 * j + i] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
