using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_detection : MonoBehaviour
{
    // Start is called before the first frame update
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
            StartCoroutine(transform.parent.gameObject.GetComponent<laser>().ActiveLaser(1f, true));
        }
    }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "Player"){
    //         StartCoroutine(transform.parent.gameObject.GetComponent<laser>().ActiveLaser(1f, false));
    //     }
    // }
}
