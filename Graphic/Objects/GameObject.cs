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
        public Transform transform;
        private List<Component> components;

        public GameObject()
        {
            components = new List<Component>();
            transform = AddComponent<Transform>() as Transform;
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

        public Component AddComponent<T>() where T : Component, new()
        {
            Component component = new T() as Component;
            component.gameObject = this;
            components.Add(component);

            return component;
        }

    }
}
