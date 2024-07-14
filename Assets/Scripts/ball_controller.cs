using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_controller : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] GameObject arrow;
    [SerializeField] GameObject chargeBar;
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
                GameObject summoned_chargeBar = Instantiate(chargeBar, gameObject.transform);
                summoned_chargeBar.transform.localPosition = new Vector3(-0.5f, 1.0f, 0);
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
                smash_power += Time.deltaTime * 2;
            }

            GameObject chargebar = GameObject.FindWithTag("Chargebar");

            if(smash_power / max_power <= 0.2f){
                chargebar.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if(smash_power / max_power <= 0.4f){
                chargebar.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if(smash_power / max_power <= 0.6f){
                chargebar.transform.GetChild(2).gameObject.SetActive(true);
            }
            else if(smash_power / max_power <= 0.8f){
                chargebar.transform.GetChild(3).gameObject.SetActive(true);
            }
            else if(smash_power / max_power <= 1f){
                chargebar.transform.GetChild(4).gameObject.SetActive(true);
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
