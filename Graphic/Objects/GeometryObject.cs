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
        public List<Vector3> points;
        public List<Point> lines;

        public override void Draw()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                Render.WuLine(points[lines[i].X], points[lines[i].Y], gameObject.transform.model);
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
            //gameObject.transform.Translate(0, 0, -4 *time);
            //gameObject.transform.Rotate(0, 0, time);
            //gameObject.transform.position = gameObject.transform.position + new Vector3(time, time) * 7;
            //Console.WriteLine(gameObject.transform.position);
        }
    }
}
