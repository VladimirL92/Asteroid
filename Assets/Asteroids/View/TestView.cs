using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;

public class TestView : MonoBehaviour
{
    private Simulation sim;
    void Start()
    {
        sim = new Simulation();
        sim.Initialization();
    }
    private void Update()
    {
        sim.Update(Time.deltaTime);
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
            Gizmos.DrawWireSphere(body.Position, 1);
            UnityEditor.Handles.Label(body.Position, "" + body.Direction);
        }
    }
}
