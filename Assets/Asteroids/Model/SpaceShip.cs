
using UnityEngine;

namespace Asteroids
{
    public class SpaceShip : Body
    {
        public SpaceShip(Vector2 position, float rotation, float velocity)
        {
            Position = position;
            Rotation = rotation;
            Velocity = velocity;
        }

        public override void Collision(Simulation simulation, Body bodyCollision)
        {

        }

        public override void Update(Simulation simulation, float delta)
        {
            if (simulation.Input.BulletShot)
            {
                simulation.Input.BulletShot = false;
                BulletShot(simulation);

            }

            if (simulation.Input.TurnRight)
            {
                Rotation -= 1f;
            }

            if (simulation.Input.TurnLeft)
            {
                Rotation += 1f;
            }

            if (simulation.Input.Acceleration)
            {
                var v = (Vector2)(Quaternion.AngleAxis(Rotation, Vector3.forward) * Vector3.up);
                Direction = Vector2.Lerp(Direction, v, delta);
                Velocity = Mathf.Lerp(Velocity, 10, delta );
            }
            else
            {
                Velocity = Mathf.Lerp(Velocity, 0, delta );
            }

            Velocity = Mathf.Clamp(Velocity, 0f, 10f);
            Position += Direction * Velocity *  delta;
        }

        private void BulletShot(Simulation simulation)
        {
            var bullet = new Bullet(Position,Rotation,15f,Config.BulletRadius,this);
            simulation.Bodies.Add(bullet);
        }
    }
}
