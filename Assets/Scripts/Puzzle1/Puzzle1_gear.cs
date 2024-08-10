using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_gear : MonoBehaviour
{
    [SerializeField] GameObject box_spawn;
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
            other.gameObject.transform.position = box_spawn.transform.position;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
    }
}
