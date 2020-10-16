using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Graphic.Objects;

namespace Graphic
{
    abstract class Game
    {
        protected List<GameObject> gameObjects;
        public Size Resolution { get; set; }

        public Game(Size Resolution)
        {
            this.Resolution = Resolution;
            gameObjects = new List<GameObject>();
        }

        public abstract void Load();
        public abstract void Unload();
        public void Update(TimeSpan gameTime)
        {
            Time.deltaTime = (float) gameTime.TotalMilliseconds / 1000;
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update();
            }
        }

        public void Draw()
        {
            Render.gfx.FillRectangle(new SolidBrush(Color.CornflowerBlue), new Rectangle(0, 0, Resolution.Width, Resolution.Height));
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Draw();
            }
        }
    }
}
