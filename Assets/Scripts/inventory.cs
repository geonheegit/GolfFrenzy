using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    [SerializeField] int numberOfItems = 5;
    [SerializeField] Sprite emptySprite;
    private Sprite[] items;
    private int not_empty_count = 0;

    void Start()
    {
        items = new Sprite[numberOfItems];

        for (int i = 0; i < numberOfItems; i++){
            for (int j = 0; j < transform.GetChild(i).childCount; j++){
                if (transform.GetChild(i).transform.GetChild(j).name == "item_img"){
                    transform.GetChild(i).transform.GetChild(j).GetComponent<Image>().color = new Color(255, 255, 255, 0);
                }
            }    
        }
    }

    public void AddItem(Sprite item){
        for (int i = 0; i < numberOfItems; i++){
            if (items[i] == null){
                items[i] = item;
                break;
                
            }
            else{
                not_empty_count += 1;
            }
        }

        if (not_empty_count == numberOfItems){
            Debug.Log("Inventory is full.");
        }

        UpdateInventory();
        not_empty_count = 0;
    }

    private void UpdateInventory(){
        for (int i = 0; i < numberOfItems; i++){
            for (int j = 0; j < transform.GetChild(i).childCount; j++){
                if (transform.GetChild(i).transform.GetChild(j).name == "item_img"){
                    
                    if (items[i] != null){
                        transform.GetChild(i).transform.GetChild(j).GetComponent<Image>().color = new Color(255, 255, 255, 255);
                        transform.GetChild(i).transform.GetChild(j).GetComponent<Image>().sprite = items[i]; // Slot의 item_img의 sprite를 keycards.cs에서 전달받은 sprite로 변경.
                    }
                    else{
                        transform.GetChild(i).transform.GetChild(j).GetComponent<Image>().sprite = emptySprite;
                    }
                    
                }
            }    
        }
    }

    public string GetItemName(int slotNum){
        // Debug.Log(slotNum);
        
        for (int j = 0; j < transform.GetChild(slotNum - 1).childCount; j++){
            if (transform.GetChild(slotNum - 1).transform.GetChild(j).name == "item_img"){
                // Debug.Log(transform.GetChild(slotNum - 1).transform.GetChild(j).GetComponent<Image>().sprite.name);
                return transform.GetChild(slotNum - 1).transform.GetChild(j).GetComponent<Image>().sprite.name;
            }
        }
        return null; // return null when nothing found.
    }

    void Update()
    {
        // FOR DEBUG (NOT A IN-GAME FUNCTION)
        // for (int i = 0; i < numberOfItems; i++){
        //     if (items[i] != null){
        //         Debug.Log(items[i].name);
        //     }
        //     else{
        //         Debug.Log("NULL");
        //     }
        // }


    }
}
