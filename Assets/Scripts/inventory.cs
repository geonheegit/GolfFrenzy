using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    [SerializeField] int numberOfItems = 5;
    private Sprite[] items;
    private int not_empty_count = 0;

    void Start()
    {
        items = new Sprite[numberOfItems];
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
                    transform.GetChild(i).transform.GetChild(j).GetComponent<Image>().sprite = items[i]; // Slot의 item_img의 sprite를 keycards.cs에서 전달받은 sprite로 변경.
                    
                }
            }    
        }
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
