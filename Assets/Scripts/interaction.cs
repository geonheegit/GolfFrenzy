using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] GameObject buttonE;

    
    private bool check = false;
    void OnTriggerEnter2D(Collider2D collision){


        if(collision.gameObject.CompareTag("Player")){
            buttonE.SetActive(true);
            if(Input.GetKey(KeyCode.E) && check == false){
                check = true;
                obj.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision){
            buttonE.SetActive(false);
        
    }

    void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            if(Input.GetKey(KeyCode.E) && check == false){
                check = true;
                obj.SetActive(true);
            }
        }
    }
    void Awake(){
        buttonE.SetActive(false);
        obj.SetActive(false);

    }
}
