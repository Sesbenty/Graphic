using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic.Geometry;

namespace Graphic.Objects
{
    class Transform: Component
    {
        Matrix4x4 Translation;
        Matrix4x4 Rotation;
        Matrix4x4 Scale;

        public Vector3 position;
        public Quaternion quaternion;

        public Matrix4x4 model {
            get
            {
                return Matrix4x4.MatrixRotate(quaternion) * Matrix4x4.MatrixTransform(position);
            }
        }

        public Transform()
        {
            Translation = Matrix4x4.identity;
            Rotation = Matrix4x4.identity;
            Scale = Matrix4x4.identity;
        }
        public void Rotate(Vector3 vector)
        {
            Rotate(vector.x, vector.y, vector.z);
        }
        public void Rotate(float xAngle, float yAngle, float zAngle)
        {
            quaternion.x += xAngle;
            quaternion.y += yAngle;
            quaternion.z += zAngle;
        }
        public void Translate(Vector3 vector)
        {
            position += vector;
        }
        public void Translate(float x, float y, float z)
        {
            position += new Vector3(x, y, z);
        }

        public override void Start()
        {
            
        }

        public override void Update()
        {
            
        }

        public override void Draw()
        {
            
        }
    }
}
