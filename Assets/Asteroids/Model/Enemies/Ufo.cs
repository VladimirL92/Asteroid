using UnityEngine;

namespace Asteroids
{
    public class Ufo: Body
    {

        public Ufo (Vector2 position, float rotation, float velocity)
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
            var target = simulation.Player.Position;
            var moveOffset = target - Position;
            moveOffset = moveOffset.normalized;
            Position += moveOffset * delta * Velocity;

        }


    }
}
