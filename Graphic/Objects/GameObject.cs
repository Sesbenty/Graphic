using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic.Geometry;

namespace Graphic.Objects
{
    class GameObject
    {
        public Vector3 position;

        private List<Component> components;

        public GameObject()
        {
            components = new List<Component>();
            position = new Vector3(0, 0);
        }

        public void Update()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Update();
            }
        }

        public void Draw()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Draw();
            }
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
        }

    }
}
