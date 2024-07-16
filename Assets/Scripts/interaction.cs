using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    [SerializeField] GameObject obj;
    private bool check = false;
    void OnTriggerEnter2D(Collider2D collision){


        if(collision.gameObject.CompareTag("Ball")){
            if(Input.GetKey(KeyCode.E) && check == false){
                check = true;
                obj.SetActive(true);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Ball")){
            if(Input.GetKey(KeyCode.E) && check == false){
                check = true;
                obj.SetActive(true);
            }
        }
    }
}
