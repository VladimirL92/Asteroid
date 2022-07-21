using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    public class Bullet : Body
    {
        private Body parentBody;
        public Bullet(Vector2 position, float rotation, float velocity, float radius,Body parent)
        {
            Position = position;
            Rotation = rotation;
            Velocity = velocity;
            Radius = radius;
            parentBody = parent;
        }
        public override void Collision(Simulation simulation, Body bodyCollision)
        {
            if (bodyCollision != parentBody)
            {
                simulation.Bodies.Remove(this);
            }

        }

        public override void Update(Simulation simulation, float delta)
        {
            var v = (Vector2)(Quaternion.AngleAxis(Rotation, Vector3.forward) * Vector3.up);
            Direction = new Vector2(v.x,v.y);
            Position += Direction * delta * Velocity;
            if (Mathf.Abs(Position.x) > simulation.screenWidth / 2 || Mathf.Abs(Position.y) > simulation.screenHeight / 2)
            {
                simulation.Bodies.Remove(this);
            }
        }
    }
}
