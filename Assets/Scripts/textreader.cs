using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrint : MonoBehaviour
{
    public string iText;
    public Text cText;

  
    IEnumerator delay(string text)
    {
        foreach(var i in text)
        {       
            cText.text += i;
            yield return new WaitForSeconds(0.1f);
        }
        
    }
          
    void Awake()
    {
        StartCoroutine(delay(iText));
    }

    

    
}
