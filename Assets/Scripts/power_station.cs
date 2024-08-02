using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_station : MonoBehaviour
{
    private bool contacted = false;
    private item_selection item_Selection;
    private inventory inventory;
    void Start()
    {
        inventory = GameObject.FindWithTag("Inventory").GetComponent<inventory>();
        item_Selection = GameObject.Find("Selection").GetComponent<item_selection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (contacted){
            if (Input.GetKeyDown(KeyCode.E)){
                if (inventory.GetItemName(item_Selection.slotNumber) == "Yellow Keycard"){
                    Debug.Log("On");
                }
                else{
                    Debug.Log("Yellow Keycard required.");
                }
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            contacted = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player"){
            contacted = false;
        }
    }
}
