using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrint : MonoBehaviour
{
    private string iText;
    [TextArea]
    public string[] texts;
    public int[] imageorder;
    public Text cText;
    private bool fineprint = false;
    private int i = 0;
    private int maxI;
    private Rigidbody2D player;
    public bool done;
    [SerializeField] AudioSource typing_SFX;
    [SerializeField] GameObject panel;
    [SerializeField] bool useSwitch;


    [SerializeField] Sprite icon1;
    [SerializeField] Sprite icon2;
  
    public IEnumerator delay(string text)
    {    
        cText.text = "";
        if(text != "0"){
            i++;
            foreach(var i in text)
            {       
                cText.text += i;
                typing_SFX.Play();
                yield return new WaitForSeconds(0.03f);
            }
        }
        else{   
            i++;
            iText = texts[i];
            StartCoroutine(delay(iText));
        }

        fineprint = true;
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

        if(useSwitch){
            if(i != 0){
                if(imageorder[i - 1] == 0){
                    panel.GetComponent<Image>().sprite = icon1;
                    cText.color = new Color(0.4705113f,0.557251f,0.7672955f,1);
                }
                else{
                    panel.GetComponent<Image>().sprite = icon2;
                    cText.color = new Color(0.7686275f,0.4705882f,0.7279503f,1);
                }
            }
            else
            {
               if(imageorder[i] == 0){
                    panel.GetComponent<Image>().sprite = icon1;
                }
                else{
                    panel.GetComponent<Image>().sprite = icon2;
                }
            }

        }


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
