using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_platform_trigger : MonoBehaviour
{
    private moving_object moving_Object_script;
    void Start()
    {
        moving_Object_script = transform.parent.GetComponent<moving_object>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            if (gameObject.name == "upper" && !moving_Object_script.go){
                moving_Object_script.left_active =  true;
                moving_Object_script.right_active = false;
            }
            else if (gameObject.name == "upper" && moving_Object_script.go){
                moving_Object_script.left_active =  false;
                moving_Object_script.right_active = true;
            }
            else if (gameObject.name == "left" && !moving_Object_script.go){
                moving_Object_script.left_active =  true;
                moving_Object_script.right_active = false;
            }
            else if (gameObject.name == "right" && moving_Object_script.go){
                moving_Object_script.left_active =  false;
                moving_Object_script.right_active = true;
            }
        }
    }
}
