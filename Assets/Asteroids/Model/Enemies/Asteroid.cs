
using UnityEngine;

namespace Asteroids
{
    class Asteroid : Body
    {
        public Asteroid(Vector2 position, float rotation,float velocity)
        {
            Position = position;
            Rotation = rotation;
            Velocity = velocity;
        }

        public override void Collision(Simulation simulation, Body bodyCollision)
        {
            if (bodyCollision is Bullet)
            {
                simulation.Bodies.Remove(this);
            }
        }
        public override void Update(Simulation simulation, float delta)
        {
            var v = (Vector2)(Quaternion.AngleAxis(Rotation, Vector3.forward) * Vector3.up);
            var direct = new Vector2(v.x, v.y);
            Position += direct.normalized * delta * Velocity;
        }
    }
}
