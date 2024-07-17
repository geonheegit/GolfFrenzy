using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot_particle : MonoBehaviour
{
    void Awake()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        transform.position = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
