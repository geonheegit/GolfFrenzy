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
    void Start()
    {
        image = gameObject.GetComponent<Image>();
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
        if (Input.GetKeyDown(KeyCode.Keypad1)){
            spacing = Mathf.Abs(GameObject.Find("Slot1").GetComponent<RectTransform>().anchoredPosition.x - GameObject.Find("Slot2").GetComponent<RectTransform>().anchoredPosition.x);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2)){
            spacing = Mathf.Abs(GameObject.Find("Slot1").GetComponent<RectTransform>().anchoredPosition.x - GameObject.Find("Slot2").GetComponent<RectTransform>().anchoredPosition.x);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(spacing, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3)){
            spacing = Mathf.Abs(GameObject.Find("Slot1").GetComponent<RectTransform>().anchoredPosition.x - GameObject.Find("Slot2").GetComponent<RectTransform>().anchoredPosition.x);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(spacing * 2, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4)){
            spacing = Mathf.Abs(GameObject.Find("Slot1").GetComponent<RectTransform>().anchoredPosition.x - GameObject.Find("Slot2").GetComponent<RectTransform>().anchoredPosition.x);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(spacing * 3, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5)){
            spacing = Mathf.Abs(GameObject.Find("Slot1").GetComponent<RectTransform>().anchoredPosition.x - GameObject.Find("Slot2").GetComponent<RectTransform>().anchoredPosition.x);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(spacing * 4, 0, 0);
        }
    }
}
