using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_gear : MonoBehaviour
{
    [SerializeField] GameObject box_spawn;
    private AudioSource box_break_SFX;
    void Start()
    {
        box_break_SFX = transform.parent.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactives"){
            other.gameObject.transform.position = new Vector3(box_spawn.transform.position.x, box_spawn.transform.position.y, 9);
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
            box_break_SFX.Play();
        }
    }
}
