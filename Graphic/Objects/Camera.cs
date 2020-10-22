using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Graphic.Geometry;

namespace Graphic.Objects
{
    class Camera:Component
    {
        const int width  = 800;
const int height = 800;
const int depth  = 255;

        Matrix4x4 projection;
        Matrix4x4 view;

        public Vector3 direction;
        public Vector3 up;

        float speedMouse = 0.01f;

        public Camera()
        {
            //direction = new Vector3(1,1,1);
            up = new Vector3(0, 1, 0);
        }

        public override void Start()
        {
            
        }

        public override void Update()
        {
            if (MouseHandler.deltaX != 0 || MouseHandler.deltaY != 0)
            {
                Console.WriteLine(MouseHandler.deltaX + " " + MouseHandler.deltaY);
                gameObject.transform.quaternion.x += speedMouse * MouseHandler.deltaX * Time.deltaTime;
                gameObject.transform.quaternion.y += speedMouse * MouseHandler.deltaY * Time.deltaTime;

            }

            if ((Keyboard.GetKeyStates(Key.A) & KeyStates.Down) > 0)
            {
                gameObject.transform.quaternion.x += Time.deltaTime;
            }
            if ((Keyboard.GetKeyStates(Key.D) & KeyStates.Down) > 0)
            {
                gameObject.transform.quaternion.x -= Time.deltaTime;
            }
            if ((Keyboard.GetKeyStates(Key.S) & KeyStates.Down) > 0)
            {
                gameObject.transform.quaternion.y -= Time.deltaTime;
            }
            if ((Keyboard.GetKeyStates(Key.W) & KeyStates.Down) > 0)
            {
                gameObject.transform.quaternion.y += Time.deltaTime;
            }

            projection = Matrix4x4.MatrixProjection(600);
            //Console.WriteLine(gameObject.transform.position);
            float cosx= Convert.ToSingle(Math.Cos(gameObject.transform.quaternion.x));
            float sinx= Convert.ToSingle(Math.Sin(gameObject.transform.quaternion.x));
            float cosy= Convert.ToSingle(Math.Cos(gameObject.transform.quaternion.y));
            float siny= Convert.ToSingle(Math.Sin(gameObject.transform.quaternion.y));

            direction = new Vector3(cosy * sinx, siny, cosy * cosx);

            
            Vector3 target = direction + gameObject.transform.position;
            //Console.WriteLine(target);
            //Console.WriteLine(direction);
            view = Matrix4x4.MatrixLookAt(target, gameObject.transform.position,up);

            Render.projection = projection;
            Render.view = view;
            //Render.viewPort = Matrix4x4.MatrixViewPort(723)
        }

        public override void Draw()
        {
            
        }
    }
}
