using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrint : MonoBehaviour
{
    private string iText;
    [TextArea]
    public string[] texts;
    public Text cText;
    private bool fineprint = false;
    private int i = 0;
    private int maxI;
    private Rigidbody2D player;
    public bool done;
    [SerializeField] AudioSource typing_SFX;
  
    public IEnumerator delay(string text)
    {
        
        cText.text = "";
        if (text != "0"){
            foreach(var i in text)
            {       
                cText.text += i;
                typing_SFX.Play();
                yield return new WaitForSeconds(0.03f);
            }
            
            fineprint = true;
            i++;
        }
    }
          
    void Awake()
    {
        typing_SFX = transform.parent.GetComponent<AudioSource>();
        
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        maxI = texts.Length;
        iText = texts[i];
        StartCoroutine(delay(iText));
    }

    void Update(){
        if(fineprint){
            if(i < maxI){
                if(fineprint && Input.GetKeyDown(KeyCode.E)){
                    fineprint = false;
                    iText = texts[i];
                    StartCoroutine(delay(iText));
                }
                
            }
            else{
                done = true;
                if(Input.GetKeyDown(KeyCode.E)){
                    this.gameObject.SetActive(false);
                }               
            }

        }

        if(!done){
            GameObject.FindWithTag("Player").GetComponent<player_controller>().isStop = true;
        }
        else{
            GameObject.FindWithTag("Player").GetComponent<player_controller>().isStop = false;

        }

    }
    

    
}
