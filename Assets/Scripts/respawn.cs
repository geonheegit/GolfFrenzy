using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private player_deathcontroller pdc;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            pdc.respawnPos = this.gameObject;
        }
    }

    void Awake(){
        pdc = GameObject.FindWithTag("Player").GetComponent<player_deathcontroller>();
    }
}
