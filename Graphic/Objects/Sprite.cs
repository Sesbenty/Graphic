using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;

namespace Graphic.Objects
{
    class Sprite:Component
    {
        public Bitmap sprite;
        public float height, width;

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            //Render.gfx.DrawImage(sprite, new RectangleF(gameObject.position.x, gameObject.position.y, height, width));
        }

        public override void Draw()
        {
            Render.gfx.DrawImage(sprite, new RectangleF(gameObject.transform.position.x, gameObject.transform.position.y, width, height));
        }
    }
}
