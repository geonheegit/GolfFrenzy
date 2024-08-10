using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private player_deathcontroller pdc;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            pdc.respawnPos = gameObject;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GetPlayerScript(){
        pdc = GameObject.FindWithTag("Player").GetComponent<player_deathcontroller>();
    }
}
