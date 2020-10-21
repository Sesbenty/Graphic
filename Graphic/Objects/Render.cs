using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Graphic.Geometry;

namespace Graphic
{
    static class Render 
    {
        public static Graphics gfx;
        public static Matrix4x4 view = Matrix4x4.identity;
        public static Matrix4x4 projection = Matrix4x4.identity;

        public static void BrezenheimLine(Vector3 a, Vector3 b)
        {
            BrezenheimLine(Convert.ToInt32(a.x), Convert.ToInt32(a.y), Convert.ToInt32(b.x), Convert.ToInt32(b.y));
        }
        public static void BrezenheimLine(Vector2 a, Vector2 b)
        {
            BrezenheimLine(Convert.ToInt32(a.x), Convert.ToInt32(a.y), Convert.ToInt32(b.x), Convert.ToInt32(b.y));
        }
        public static void BrezenheimLine(int x0, int y0, int x1, int y1)
        {
            var steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0); 

            if (steep)
            {
                Swap(ref x0, ref y0); 
                Swap(ref x1, ref y1);
            }
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }
            int dx = x1 - x0;
            int dy = Math.Abs(y1 - y0);
            int error = dx / 2; 
            int ystep = (y0 < y1) ? 1 : -1; 
            int y = y0;
            for (int x = x0; x <= x1; x++)
            {
                gfx.FillRectangle(Brushes.Black, steep ? y : x, steep ? x : y, 1, 1); 
                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
        }

        public static void WuLine(Vector4 a, Vector4 b)
        {
            //WuLine(ax, ay, bx, by);
        }
        public static void WuLine(Vector3 a, Vector3 b, Matrix4x4 model)
        {
            Vector4 ac = new Vector4(a.x, a.y, a.z);
            Vector4 bc = new Vector4(b.x, b.y, b.z);

            ac = model * view * projection * ac;
            bc = model * view * projection * bc;

            WuLine(Convert.ToInt32(ac.x), Convert.ToInt32(ac.y), Convert.ToInt32(bc.x), Convert.ToInt32(bc.y));
        }
        public static void WuLine(Vector2 a, Vector2 b)
        {
            WuLine(Convert.ToInt32(a.x), Convert.ToInt32(a.y), Convert.ToInt32(b.x), Convert.ToInt32(b.y));
        }

        public static void WuLine(int x0, int y0, int x1, int y1)
        {
            var steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

            if (steep)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }
            DrawPoint(steep, x0, y0, 1); 
            DrawPoint(steep, x1, y1, 1);
            float dx = x1 - x0;
            float dy = y1 - y0;
            float gradient = dy / dx;
            float y = y0 + gradient;
            for (var x = x0 + 1; x <= x1 - 1; x++)
            {
                DrawPoint(steep, x, (int)y, 1 - (y - (int)y));
                DrawPoint(steep, x, (int)y + 1, y - (int)y);
                y += gradient;
            }
        }

        public static void DDALine(Vector3 a, Vector3 b)
        {
            DDALine(a.x, a.y, b.x, b.y);
        }
        public static void DDALine(Vector2 a, Vector2 b)
        {
            DDALine(a.x, a.y, b.x, b.y);
        }
        public static void DDALine(float x0, float y0, float x1, float y1)
        {
            int ix0 = Convert.ToInt32(x0);
            int ix1 = Convert.ToInt32(x1);
            int iy0 = Convert.ToInt32(y0);
            int iy1 = Convert.ToInt32(y1);

            int deltaX = Math.Abs(ix0 - ix1);
            int deltaY = Math.Abs(iy0 - iy1);

            int length = Math.Max(deltaX, deltaY);

            if (length == 0)
            {

            }

            double dX = (x1 - x0) / length;
            double dY = (y1 - y0) / length;

            double x = x0;
            double y = y0;

            length++;
            while (length-- > 0)
            {
                x += dX;
                y += dY;
                gfx.FillRectangle(Brushes.Black, Convert.ToInt32(x), Convert.ToInt32(y), 1,1);
            }
        }

        static private void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }

        static private void DrawPoint(bool step, int x, int y, float c)
        {
            if (step)
                Swap(ref x, ref y);
            byte col = (byte)(c * 255);
            var brush = new SolidBrush(Color.FromArgb(col,0,0,0));
            gfx.FillRectangle(brush,x, y, 1, 1);
        }
    }
}
