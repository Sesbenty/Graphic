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
        public float velocity { get; set; }
        public MoveInput()
        {
            velocity = 100;
        }
        public MoveInput(float velocity)
        {
            this.velocity = velocity;
        }

        public override void Update()
        {
            float moveDistance = velocity * Time.deltaTime;
            if ((Keyboard.GetKeyStates(Key.Right) & KeyStates.Down) > 0)
            {
                gameObject.transform.position.x += moveDistance;
            }
            if ((Keyboard.GetKeyStates(Key.Left) & KeyStates.Down) > 0)
            {
                gameObject.transform.position.x -= moveDistance;
            }
            if ((Keyboard.GetKeyStates(Key.Up) & KeyStates.Down) > 0)
            {
                gameObject.transform.position.z -= moveDistance;
            }
            if ((Keyboard.GetKeyStates(Key.Down) & KeyStates.Down) > 0)
            {
                gameObject.transform.position.z += moveDistance;
            }

        }
    }
}
