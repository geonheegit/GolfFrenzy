using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_goal : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;
    [SerializeField] GameObject destination;
    [SerializeField] AudioSource complete_SFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactives"){
            foreach (GameObject block in blocks){
                block.transform.position = destination.transform.position;
            }

            complete_SFX.Play();
        }
    }
}
