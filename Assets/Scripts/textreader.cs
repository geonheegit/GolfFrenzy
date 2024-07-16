using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrint : MonoBehaviour
{
    public string iText;
    public Text cText;
    private bool fineprint = false;

  
    IEnumerator delay(string text)
    {
        foreach(var i in text)
        {       
            cText.text += i;
            yield return new WaitForSeconds(0.1f);
        }
        
        fineprint = true;

    }
          
    void Awake()
    {
        StartCoroutine(delay(iText));
    }

    void Update(){
        if(fineprint){
            if(Input.GetKey(KeyCode.E)){
                this.gameObject.SetActive(false);
            }
        }
    }
    

    
}
