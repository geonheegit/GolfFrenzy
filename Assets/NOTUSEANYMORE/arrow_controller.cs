using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_controller : MonoBehaviour
{
    [SerializeField] GameObject ballObj;
    ball_controller ball_Controller;
    void Start()
    {
        ball_Controller = transform.parent.GetComponent<ball_controller>(); // <= ball_contorller.cs
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.RotateAround(transform.parent.transform.position, new Vector3(0, 0, 1), ball_Controller.rotation_speed * Time.fixedDeltaTime);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.RotateAround(transform.parent.transform.position, new Vector3(0, 0, 1), -ball_Controller.rotation_speed * Time.fixedDeltaTime);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) || ball_Controller.shot_mode == 0){ // <= ball_contorller.cs
            Destroy(gameObject);
        }

        if(ball_Controller.isfire){ // <= ball_contorller.cs
            ball_Controller.isfire = false; 
            ball_Controller.rb.AddForce(new Vector3(transform.position.x - ball_Controller.transform.position.x, transform.position.y - ball_Controller.transform.position.y, 0).normalized * ball_Controller.smash_power * 5, ForceMode2D.Impulse);
            ball_Controller.smash_power = 0;
        }
    }
}
