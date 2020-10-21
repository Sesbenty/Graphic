using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic.Objects
{
    abstract class Component
    {
        public GameObject gameObject { get; set; }

        public abstract void Start();
        public abstract void Update();
        public abstract void Draw();
    }
}
