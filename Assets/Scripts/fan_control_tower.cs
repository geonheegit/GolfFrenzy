using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fan_control_tower : MonoBehaviour
{
    [SerializeField] bool contacted = false;
    private item_selection item_Selection;
    private inventory inventory;
    public bool turnedOn = false;
    public bool powered = false;

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
                if (!turnedOn){
                    if (inventory.GetItemName(item_Selection.slotNumber) == "Green Keycard"){
                        if (powered){
                            Debug.Log("On");
                            turnedOn = true;

                            // Lights
                        }
                        else{
                            Debug.Log("Need Power Supply.");
                        }    
                    }
                    else{
                        Debug.Log("Green Keycard required.");
                    }
                }
                else{
                    Debug.Log("The Fan Control Tower already turned on.");
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

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            contacted = false;
        }
    }
}
