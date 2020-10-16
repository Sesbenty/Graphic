using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic.Geometry;
using Graphic.Objects;
namespace Graphic
{
    class MoveObj:GameScript
    {
        Vector2 a, b;
        public MoveObj(GameObject parent,Vector2 a, Vector2 b) : base(parent)
        {

        }
    }
}
