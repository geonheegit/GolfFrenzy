using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fly : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool horo;


    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            other.GetComponent<Rigidbody2D>().gravityScale = 0f;
            other.GetComponent<player_controller>().isfly = true;
            if(horo){
                other.GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(other.GetComponent<Rigidbody2D>().velocity, new Vector2(0, speed), Time.smoothDeltaTime);
            }
            else{
                other.GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(other.GetComponent<Rigidbody2D>().velocity, new Vector2(speed, 0), Time.smoothDeltaTime);
            }
            


        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            other.GetComponent<Rigidbody2D>().gravityScale = 1;
            other.GetComponent<player_controller>().isfly = false;

        }
    }
}
