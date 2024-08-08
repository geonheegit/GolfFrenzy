using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nogravity : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            other.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            other.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
    }
}
