using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    [SerializeField] int numberOfItems = 5;
    private Sprite[] items;

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
                Debug.Log("Inventory is full.");
            }
        }

        UpdateInventory();
    }

    private void UpdateInventory(){
        for (int i = 0; i < numberOfItems; i++){
            for (int j = 0; j < transform.GetChild(i).transform.GetChild(j).childCount; j++){
                if (transform.GetChild(i).transform.GetChild(j).name == "item_img"){
                    transform.GetChild(i).transform.GetChild(j).GetComponent<Image>().sprite = items[i];
                    
                }
                Debug.Log(transform.GetChild(i).transform.GetChild(j).name);
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
