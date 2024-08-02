using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycards : MonoBehaviour
{
    private inventory inventory;
    void Start()
    {
        inventory = GameObject.FindWithTag("Inventory").GetComponent<inventory>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            inventory.AddItem(gameObject.GetComponent<SpriteRenderer>().sprite);
            Destroy(gameObject);
        }
    }
}
