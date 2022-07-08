using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Simulation
    {
        public List<Body> Bodies = new List<Body>();
        private int ufoCount = 1;
        private int asteroidCount = 3;
        public float screenWidth = 16;
        public float screenHeight = 10;
        private float ufoSpeed = 1;
        private float asteroidSpeed = 0.3f;


        public void Initialization()
        {
            for (var i = 0; i < ufoCount; i++)
            {
                var ufo = new Ufo();
                var angle = Random.Range(0f, 360f);
                var v = (Vector2)(Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right);
                ufo.Direction = new Vector2(v.x, v.y);
                ufo.Position = Random.insideUnitCircle * 5f;
                ufo.Velosity = ufoSpeed;
                Bodies.Add(ufo);
            }

            for (var i = 0; i < asteroidCount; i++)
            {
                var asteroid = new Asteroid();
                var angle = Random.Range(0f, 360f);
                var v = (Vector2)(Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right);
                asteroid.Direction = new Vector2(v.x, v.y);
                asteroid.Position = Random.insideUnitCircle * 5f;
                asteroid.Velosity = asteroidSpeed;
                Bodies.Add(asteroid);
            }
        }
        public void Update(float deltaTime)
        {
            foreach (var body in Bodies)
            {
                var absX = Mathf.Abs(body.Position.x);
                var absY = Mathf.Abs(body.Position.y);

                if (absX > screenWidth / 2)
                {
                    var newPos = new Vector2(-body.Position.x, body.Position.y);
                    body.Position = newPos;
                }

                if (absY > screenHeight / 2)
                {
                    var newPos = new Vector2(body.Position.x, -body.Position.y);
                    body.Position = newPos;
                }

                body.Position += body.Direction * deltaTime * body.Velosity; 


            }
        }
    }
}
