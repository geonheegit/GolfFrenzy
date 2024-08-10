using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_lever : MonoBehaviour
{
    public bool contacted = false;
    private puzzle1_lever_obj_control puzzle1_Lever_Obj_Control;
    void Start()
    {
        puzzle1_Lever_Obj_Control = transform.parent.GetComponent<puzzle1_lever_obj_control>();
    }

    // Update is called once per frame
    void Update()
    {
        if (contacted){
            if (Input.GetKeyDown(KeyCode.E)){
                puzzle1_Lever_Obj_Control.SwitchObjects();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            contacted = true;
        }

        if (other.gameObject.tag == "Interactives"){
            puzzle1_Lever_Obj_Control.SwitchObjects();
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player"){
            contacted = false;
        }
    }
}
