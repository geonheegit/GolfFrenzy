using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keypadmanager : MonoBehaviour
{
    public int password;
    public int mypassword;
    public bool enter;
    public bool clear;
    private Text txt;
    private int jaritsu = 4;

    public int PasswordInput(int num){
        if(jaritsu != 0){
            jaritsu--;
            txt.text += num;
            mypassword = (mypassword * 10) + num;
            Debug.Log(mypassword);
            Debug.Log(num);

        }
        return 0;
    }

    void Update(){

        if(txt == null){
            txt = GetComponent<Text>();
        }
        
        if(jaritsu == 0){
            if(enter){
                if(mypassword == password){
                    txt.text = "Success";
                }
                else{
                    txt.text = "INVALID";

                }
                enter = false;
            }
        }

        if(clear){
            txt.text = "";
            jaritsu = 4;
            mypassword = 0;
            clear = false;
        }
    }


}
