using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikecontroller : MonoBehaviour
{
    [SerializeField] GameObject gameover;
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Time.timeScale = 0;
        } 
    }


}
