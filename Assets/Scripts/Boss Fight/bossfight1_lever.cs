using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossfight1_lever : MonoBehaviour
{
    [SerializeField] AudioSource leverpull_SFX;
    [SerializeField] AudioSource spikefall_SFX;
    [SerializeField] GameObject spikes_parent;
    private bool contacted = false;
    private bool active_once = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contacted){
            if (Input.GetKeyDown(KeyCode.E) && !active_once){
                active_once = true;
                
                leverpull_SFX.Play();
                spikefall_SFX.Play();

                for (int i = 0; i < spikes_parent.transform.childCount; i++){
                    spikes_parent.transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
                }
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
