using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_controller : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] GameObject arrow;
    [SerializeField] Vector3 spawnpoint;
    [SerializeField] float DragMA; //Mid Air Linear drag
    [SerializeField] float DragOG; //On Ground Linear drag

    public float rotation_speed;
    public float max_power;

    public bool isfire;
    
    public float smash_power; 

    public int shot_mode = 0;  // 0 : stop, 1 : set direction, 2 : charge 
    private bool isStop = true;
    void Start()
    {
        spawnpoint = GameObject.FindWithTag("Spawn").transform.position;
        transform.position = spawnpoint;
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground"))
        {
            rb.drag = DragOG;
        }
    }

    void Update() 
    {
        
        if(Input.GetKeyDown(KeyCode.C) && isStop == true){

            if(shot_mode == 1){
                shot_mode = 2;
            }

            if(shot_mode == 0){
                shot_mode = 1;

                GameObject summoned_arrow = Instantiate(arrow, gameObject.transform);
                summoned_arrow.transform.localPosition = new Vector3(1.0f, 0, 0);
            }
        }

        if(Input.GetKey(KeyCode.C) && shot_mode == 2)
        {
            if(smash_power <= max_power){
                smash_power += Time.deltaTime * 5;
            }
        }

        if(Input.GetKeyUp(KeyCode.C) && shot_mode == 2) // => arrow_controller.cs
        {
            shot_mode = 0;
            rb.drag = DragMA;
            isfire = true;
            isStop = false;
        }
        
        if(Input.GetKeyDown(KeyCode.X)){ // => arrow_controller.cs
            if(shot_mode == 1){
                shot_mode = 0;
            }
        }


    }

    void FixedUpdate(){

        if(Mathf.Abs(rb.velocity.x) <= 0.5f){
            rb.velocity = new Vector2(0, rb.velocity.y);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            isStop = true;
        }
    }
}
