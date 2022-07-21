using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Asteroids
{
    public class Simulation
    {
        public List<Body> Bodies = new List<Body>();
        public Input Input = new Input();
        public float screenWidth = 16;
        public float screenHeight = 10;

        public Body Player { get; private set; }

        private int ufoCount = 1;
        private int asteroidCount = 3;
        private float ufoSpeed = 0.6f;
        private float asteroidSpeed = 0.3f;
        private float spaceShipSpeed = 8f;
        private float spaceShipAcceleration = 0.1f;
        private float spaceShipSpeedRotation = 0.8f;



        public void Initialization()
        {
            Player = new SpaceShip(Vector2.zero,0,1f);
            Player.Position = Vector2.zero;
            Player.Radius = Config.ShipRadius;
            Bodies.Add(Player);

            SpawnAsteroid();
            SpawnUfo();
        }

        public void Update(float deltaTime)
        {
            MoveEntities(deltaTime);
            SpawnAsteroid();
            SpawnUfo();
        }

        public bool TryCollision(Body body, Body withBody)
        {
            if (body == withBody)
            {
                return false;
            }
            var distance = Vector2.Distance(body.Position, withBody.Position);
            if (distance < (body.Radius + withBody.Radius))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        void MoveEntities(float DeltaTime)
        {
            
            foreach (var body in Bodies)
            {

                body.Update(this, DeltaTime);

                foreach (var current in Bodies)
                {

                        if (TryCollision(body, current))
                        {
                        body.Collision(this, current);
                        current.Collision(this, body);
                        }
                    
                }
                MoveRepeat(body);

            }
        }

        public void MoveRepeat(Body body)
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
        }
        public void SpawnUfo()
        {
            var count = Bodies.OfType<Ufo>().Count();
            for (var i = count; i < ufoCount; i++)
            {
                var rPos = Random.insideUnitCircle * 5f;
                var angle = Random.Range(0f, 360f);
                var ufo = new Ufo(rPos, angle,ufoSpeed);
                ufo.Radius = Config.UfoRadius;
                Bodies.Add(ufo);
            }
        }
        public void SpawnAsteroid()
        {
            var count = Bodies.OfType<Asteroid>().Count();
            for (var i = count; i< asteroidCount; i++)
            {
                var rPos = Random.insideUnitCircle * 5f;
                var angle = Random.Range(0f, 360f);
                var asteroid = new Asteroid(rPos, angle ,asteroidSpeed);
                asteroid.Radius = Config.AsteroidRadius;
                Bodies.Add(asteroid);
            }
        }

    }
}
