using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_controller : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] GameObject arrow;
    [SerializeField] Vector3 spawnpoint;

    public float rotation_speed;
    [SerializeField] float smash_power;

    public bool shot_mode = false;
    void Start()
    {
        spawnpoint = GameObject.FindWithTag("Spawn").transform.position;
        transform.position = spawnpoint;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            if(!shot_mode){
                shot_mode = true;

                GameObject summoned_arrow = Instantiate(arrow, gameObject.transform);
                summoned_arrow.transform.localPosition = new Vector3(1.0f, 0, 0);
            }
        }
        
        if(Input.GetKeyDown(KeyCode.X)){
            if(shot_mode){
                shot_mode = false;
            }
        }
    }
}
