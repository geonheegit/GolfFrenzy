using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class regioninfo : MonoBehaviour
{
    public Text txt;
    [SerializeField] private float lasttime;
    public Color txtclr;
    public bool gofadein = true;
    public bool gofadeout;

    IEnumerator TextLast(){
        yield return new WaitForSeconds(lasttime);
        gofadeout = true;
    }

    void Awake(){
        txtclr = txt.color;
        txtclr.a = 0;
    }
   
      void Update(){

        txt.color = txtclr;

        if(gofadein){
            txtclr.a = Mathf.Lerp(txtclr.a, 0.8f, Time.deltaTime);
            if(txtclr.a > 0.75f){
                StartCoroutine("TextLast");
                gofadein = false;
            }
        }

        if(gofadeout){
            txtclr.a = Mathf.Lerp(txtclr.a, 0, Time.deltaTime);
            if(txtclr.a < 0.05f){
                gofadeout = false;
                txtclr.a = 0;
            }
        }
    }
}
