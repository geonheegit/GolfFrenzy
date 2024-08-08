using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    [SerializeField] GameObject destination_portal;
    [SerializeField] AudioSource portal_SFX;
    void Start()
    {
        portal_SFX = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            other.gameObject.transform.position = destination_portal.transform.position;
            portal_SFX.Play();
        }
    }
}
