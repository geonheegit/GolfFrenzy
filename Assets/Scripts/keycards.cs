using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycards : MonoBehaviour
{
    private inventory inventory;
    private game_manager gm;
    
    void Start()
    {
        inventory = GameObject.FindWithTag("Inventory").GetComponent<inventory>();
        gm = GameObject.Find("GameManager").GetComponent<game_manager>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            inventory.AddItem(gameObject.GetComponent<SpriteRenderer>().sprite);
            gm.PlayItemPickUpSFX();

            Destroy(gameObject);
        }
    }
}
