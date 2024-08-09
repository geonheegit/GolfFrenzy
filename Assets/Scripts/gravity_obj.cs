using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity_obj : MonoBehaviour
{
    [SerializeField] AudioSource gravity_up_sound;
    [SerializeField] AudioSource gravity_down_sound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            if (other.gameObject.GetComponent<Rigidbody2D>().gravityScale > 0 && gameObject.tag == "gravity_up"){
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = -other.gameObject.GetComponent<Rigidbody2D>().gravityScale;
                gravity_up_sound.Play();
            }
            else if (other.gameObject.GetComponent<Rigidbody2D>().gravityScale < 0 && gameObject.tag == "gravity_down"){
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = -other.gameObject.GetComponent<Rigidbody2D>().gravityScale;
                gravity_down_sound.Play();
            }
        }
    }
}
