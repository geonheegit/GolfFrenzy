using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class item_selection : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    private Image image;
    private float spacing;
    public int slotNumber;
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        slotNumber = 1;
        StartCoroutine(LoopAnimation());
        spacing = Mathf.Abs(GameObject.Find("Slot1").GetComponent<RectTransform>().anchoredPosition.x - GameObject.Find("Slot2").GetComponent<RectTransform>().anchoredPosition.x);
    }

    IEnumerator LoopAnimation(){
        foreach(var item in sprites){
            yield return new WaitForSeconds(0.2f);
            image.sprite = item;
        }
        StartCoroutine(LoopAnimation());
    }

    
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            spacing = Mathf.Abs(GameObject.Find("Slot1").GetComponent<RectTransform>().anchoredPosition.x - GameObject.Find("Slot2").GetComponent<RectTransform>().anchoredPosition.x);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            slotNumber = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)){
            spacing = Mathf.Abs(GameObject.Find("Slot1").GetComponent<RectTransform>().anchoredPosition.x - GameObject.Find("Slot2").GetComponent<RectTransform>().anchoredPosition.x);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(spacing, 0, 0);
            slotNumber = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)){
            spacing = Mathf.Abs(GameObject.Find("Slot1").GetComponent<RectTransform>().anchoredPosition.x - GameObject.Find("Slot2").GetComponent<RectTransform>().anchoredPosition.x);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(spacing * 2, 0, 0);
            slotNumber = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)){
            spacing = Mathf.Abs(GameObject.Find("Slot1").GetComponent<RectTransform>().anchoredPosition.x - GameObject.Find("Slot2").GetComponent<RectTransform>().anchoredPosition.x);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(spacing * 3, 0, 0);
            slotNumber = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5)){
            spacing = Mathf.Abs(GameObject.Find("Slot1").GetComponent<RectTransform>().anchoredPosition.x - GameObject.Find("Slot2").GetComponent<RectTransform>().anchoredPosition.x);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(spacing * 4, 0, 0);
            slotNumber = 5;
        }
    }
}
