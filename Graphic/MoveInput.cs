using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic.Objects;
using System.Windows.Input;

namespace Graphic
{
    class MoveInput:GameScript
    {
        float velocity { get; set; }
        public MoveInput(GameObject parent, float velocity) : base(parent)
        {
            this.velocity = velocity;
        }

        public override void Update()
        {
            int moveDistance = (int)(velocity * Time.deltaTime);
            if ((Keyboard.GetKeyStates(Key.Right) & KeyStates.Down) > 0)
            {
                gameObject.position.x += moveDistance;
            }
            if ((Keyboard.GetKeyStates(Key.Left) & KeyStates.Down) > 0)
            {
                gameObject.position.x -= moveDistance;
            }
            if ((Keyboard.GetKeyStates(Key.Up) & KeyStates.Down) > 0)
            {
                gameObject.position.y -= moveDistance;
            }
            if ((Keyboard.GetKeyStates(Key.Down) & KeyStates.Down) > 0)
            {
                gameObject.position.y += moveDistance;
            }
        }
    }
}
