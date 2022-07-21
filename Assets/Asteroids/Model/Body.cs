using UnityEngine;

namespace Asteroids
{
    public abstract class Body
    {
        public Vector2 Position;
        public float Radius;
        public float Rotation;
        public Vector2 Direction;
        public float Velocity;
        public abstract void Update(Simulation simulation, float delta);
        public abstract void Collision(Simulation simulation, Body bodyCollision);
    }
}
