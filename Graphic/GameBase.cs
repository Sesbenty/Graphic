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
            Sprite sprtiePlayer = new Sprite(player, Properties.Resources.cat);
            player.AddComponent(sprtiePlayer);

            MoveInput input = new MoveInput(player, 200);
            player.AddComponent(input);

            GameObject player2 = new GameObject();
            Sprite sprtiePlayer2 = new Sprite(player2, Properties.Resources.cat);
            player2.AddComponent(sprtiePlayer2);

            MoveInput input2 = new MoveInput(player2, 400);
            player2.AddComponent(input2);
            player2.position.x = 100;

            GameObject enemy = new GameObject();
            Sprite spriteEnemy = new Sprite(enemy, Properties.Resources.bear, 200, 100);
            enemy.AddComponent(spriteEnemy);
            List<Vector3> points = new List<Vector3>();
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                points.Add(new Vector3((float)r.NextDouble() * 500, (float)r.NextDouble() * 500));
            }

            enemy.position.x = 200;




            gameObjects.Add(enemy);
            gameObjects.Add(player);
            gameObjects.Add(player2);


            Random rnd = new Random(100);
            for (int i = 0; i < 4; i++)
            {
                gameObjects.Add(box(
                    new Vector4((float)rnd.NextDouble() * 200,
                    (float)rnd.NextDouble() * 200,
                    (float)rnd.NextDouble() * 400)
                    ));
            } 

        }

        public GameObject box(Vector4 postion)
        {
            GameObject box = new GameObject();

            var p = new List<Vector4>();
            p.Add(new Vector4(-50, 50,2));
            p.Add(new Vector4(50, 50,2));
            p.Add(new Vector4(50, -50,2));
            p.Add(new Vector4(-50, -50,2));

            var l = new List<Point>();
            l.Add(new Point(0, 1));
            l.Add(new Point(1, 2));
            l.Add(new Point(2, 3));
            l.Add(new Point(3, 0));

            GeometryObject gbox = new GeometryObject(box, p, l);
            box.AddComponent(gbox);
            box.position = postion;

            return box;
        }

        public override void Unload()
        {
            throw new NotImplementedException();
        }
    }
}
