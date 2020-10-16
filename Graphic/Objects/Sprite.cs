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

        public Sprite(GameObject parent, Bitmap sprite,float height, float width):base(parent)
        {
            this.sprite = sprite;
            this.height = height;
            this.width = width;
        }

        public Sprite(GameObject parent, Bitmap sprite) : base(parent)
        {
            this.sprite = sprite;
            this.height = sprite.Height;
            this.width = sprite.Width;
        }

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
            Render.gfx.DrawImage(sprite, new RectangleF(gameObject.position.x, gameObject.position.y, width, height));
        }
    }
}
