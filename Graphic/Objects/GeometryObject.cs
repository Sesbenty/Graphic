using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;
using Graphic.Geometry;

namespace Graphic.Objects
{
    class GeometryObject : Component
    {
        List<Vector4> points;
        List<Point> lines;
        int a;

        public GeometryObject(GameObject parent, List<Vector4> points, List<Point> lines):base(parent)
        {
            this.points = points;
            this.lines = lines;
        }
        public override void Draw()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                Render.WuLine(points[lines[i].X] + gameObject.position, points[lines[i].Y] + gameObject.position);
            }

            Render.WuLine(0, 0, 150, 100);
            Render.BrezenheimLine(0, 50, 150, 150);
            Render.DDALine(0, 100, 150, 200);
        }

        public override void Start()
        {

        }
    

        public override void Update()
        {
                float time = Time.deltaTime;

                //gameObject.position.AngleAtCenter(time, new Vector4(300,300,50));

                Matrix4x4 mx = Matrix4x4.MatrixRotateX(time);
                Matrix4x4 my = Matrix4x4.MatrixRotateY(time);
                Matrix4x4 mz = Matrix4x4.MatrixRotateZ(time);

                for (int i = 0; i < points.Count; i++)
                {

                    mx.Mult(points[i]);
                    my.Mult(points[i]);
                    //mz.Mult(points[i]);
                    //Console.Write(points[i].x + " " + points[i].y+"  -- ");
                }
            
        }
    }
}
