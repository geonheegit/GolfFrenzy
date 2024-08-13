using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_objects_trigger : MonoBehaviour
{
    private GameObject falling_obj_parent;
    [SerializeField] AudioSource falling_SFX1;
    [SerializeField] AudioSource falling_SFX2;
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
            falling_obj_parent = GameObject.FindWithTag("Falling Objects");
            for (int i = 0; i < falling_obj_parent.transform.childCount; i++){
                falling_obj_parent.transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
            }
            falling_SFX1.Play();
            falling_SFX2.Play();
        }
    }
}
