using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject bullet;

    void Update()
    {
        transform.position +=Vector3.up *  Time.deltaTime;


    }
}
