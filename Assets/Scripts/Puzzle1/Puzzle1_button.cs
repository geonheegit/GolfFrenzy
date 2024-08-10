using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_button : MonoBehaviour
{
    [SerializeField] GameObject box;
    [SerializeField] float push_force;
    public bool contacted;
    // public bool active_once = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contacted){
            if (Input.GetKeyDown(KeyCode.E)){
                box.GetComponent<Rigidbody2D>().AddForce(new Vector2(push_force, 0));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            contacted = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            contacted = false;
        }
    }
}
