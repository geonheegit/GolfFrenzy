using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_controller : MonoBehaviour
{
    [SerializeField] GameObject ballObj;
    ball_controller ball_Controller;
    void Start()
    {
        ball_Controller = transform.parent.GetComponent<ball_controller>();
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
        if(Input.GetKeyDown(KeyCode.X)){
            Destroy(gameObject);
        }
    }
}
