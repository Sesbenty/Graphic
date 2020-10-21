using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic.Objects;
using System.Drawing;
using Graphic.Geometry;

namespace Graphic
{
    class GameBase : Game
    {
        public GameBase(Size Resolution):base(Resolution){

        }
        public override void Load()
        {
            GameObject player = new GameObject();
            Sprite sprtiePlayer = player.AddComponent<Sprite>() as Sprite;
            sprtiePlayer.sprite = Properties.Resources.cat;
            sprtiePlayer.width = 100;
            sprtiePlayer.height = 100;
            MoveInput input = player.AddComponent<MoveInput>() as MoveInput;
            input.velocity = 200;


            GameObject mainCamera = new GameObject();

            Camera camera = mainCamera.AddComponent<Camera>() as Camera;
            MoveInput move = mainCamera.AddComponent<MoveInput>() as MoveInput;
            move.velocity = 100;
            mainCamera.transform.position.z = 40;

            gameObjects.Add(mainCamera);
            //gameObjects.Add(player);

            gameObjects.Add(box(new Vector3(0, 0, 0), 5));

            Random rnd = new Random(33);
            for (int i = 0; i < 5; i++)
            {
                gameObjects.Add(Cube(
                    new Vector3((float)rnd.NextDouble() * 200,
                    (float)rnd.NextDouble() * 200,
                    (float)rnd.NextDouble() * 100),
                    50
                    ));
            } 

        }

        public GameObject box(Vector3 position, float size)
        {
            GameObject box = new GameObject();

            var p = new List<Vector3>();
            p.Add(new Vector3(-size, size, 2));
            p.Add(new Vector3(size, size, 2));
            p.Add(new Vector3(size, -size, 2));
            p.Add(new Vector3(-size, -size,2));

            var l = new List<Point>();
            l.Add(new Point(0, 1));
            l.Add(new Point(1, 2));
            l.Add(new Point(2, 3));
            l.Add(new Point(3, 0));

            GeometryObject gbox = box.AddComponent<GeometryObject>() as GeometryObject;

            gbox.lines = l;
            gbox.points = p;
            box.transform.position = position;

            return box;
        }
        public GameObject Cube(Vector3 position, float size)
        {
            GameObject Cube = new GameObject();
            size /= 2;
            var p = new List<Vector3>();
            p.Add(new Vector3(size, size, -size));
            p.Add(new Vector3(-size, size, -size));
            p.Add(new Vector3(-size, -size, -size));
            p.Add(new Vector3(size, -size, -size));

            p.Add(new Vector3(size, size, size));
            p.Add(new Vector3(-size, size, size));
            p.Add(new Vector3(-size, -size, size));
            p.Add(new Vector3(size, -size, size));

            var l = new List<Point>();
            l.Add(new Point(0, 1));
            l.Add(new Point(1, 2));
            l.Add(new Point(2, 3));
            l.Add(new Point(3, 0));

            l.Add(new Point(4, 5));
            l.Add(new Point(5, 6));
            l.Add(new Point(6, 7));
            l.Add(new Point(7, 4));

            l.Add(new Point(0, 4));
            l.Add(new Point(1, 5));
            l.Add(new Point(2, 6));
            l.Add(new Point(3, 7));

            GeometryObject gCube = Cube.AddComponent<GeometryObject>() as GeometryObject;

            gCube.lines = l;
            gCube.points = p;
            Cube.transform.position = position;

            return Cube;
        }
        public override void Unload()
        {
            throw new NotImplementedException();
        }
    }
}
