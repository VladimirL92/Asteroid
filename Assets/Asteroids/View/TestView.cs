using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestView : MonoBehaviour
{
    public Asteroids. Simulation sim;
    public GameObject Player;

    void Start()
    {
        sim = new Asteroids.Simulation();
        sim.Initialization();
        
    }
    private void Update()
    {
        var input = sim.Input;
        sim.Update(Time.deltaTime);
        Player.transform.position = sim.Bodies[0].Position;
        Player.transform.rotation = Quaternion.Euler(0,0,sim.Bodies[0].Rotation);

        input.Acceleration = Input.GetKey(KeyCode.W);
        input.TurnLeft = Input.GetKey(KeyCode.A);
        input.TurnRight = Input.GetKey(KeyCode.D);

        if (Input.GetKeyDown(KeyCode.E)) input.BulletShot = true;
        if (Input.GetKeyDown(KeyCode.Q)) input.LaserShot = true;
    }

    private void OnDrawGizmos()
    {
        if (sim == null )
        {
            return;
        }
        var size = new Vector3(sim.screenWidth, sim.screenHeight, 0);
        Gizmos.DrawWireCube(Vector3.zero, size);
        foreach (var body in sim.Bodies)
        {
            Gizmos.DrawWireSphere(body.Position, body.Radius);
        }
    }
}
