using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pdf : MonoBehaviour
{
    [SerializeField] private GameObject E;
    [SerializeField] private GameObject pdfui;
    [SerializeField] private GameObject text;


    public void closeUI(){
        pdfui.SetActive(false);
        text.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            E.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)){
                pdfui.SetActive(true);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player"){
            if(Input.GetKeyDown(KeyCode.E)){
                pdfui.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            E.SetActive(false);
        }
    }
}
