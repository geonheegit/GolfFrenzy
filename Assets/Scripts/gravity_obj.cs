using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity_obj : MonoBehaviour
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
            if (other.gameObject.GetComponent<Rigidbody2D>().gravityScale > 0){
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = -other.gameObject.GetComponent<Rigidbody2D>().gravityScale;
                other.gameObject.transform.Rotate(0, 0, 180);
            }
            else if (other.gameObject.GetComponent<Rigidbody2D>().gravityScale < 0){
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = -other.gameObject.GetComponent<Rigidbody2D>().gravityScale;
                other.gameObject.transform.Rotate(0, 0, 180);
            }
        }
    }
}
