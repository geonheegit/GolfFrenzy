using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private player_deathcontroller pdc;
    [SerializeField] ParticleSystem respawn_particle;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            pdc.respawnPos = gameObject;

            ParticleSystem spawned_particle = Instantiate(respawn_particle);
            spawned_particle.transform.position = other.gameObject.transform.position;
            spawned_particle.Play();

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
