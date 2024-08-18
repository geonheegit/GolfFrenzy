using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitinteraction : MonoBehaviour
{
    private bool check = false;
    [SerializeField] GameObject obj;
    void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.CompareTag("Player")){
            if(check == false){
                check = true;
                obj.SetActive(true);
            }
        }
    }
}
