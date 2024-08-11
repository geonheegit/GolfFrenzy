using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keypad : MonoBehaviour
{
    [SerializeField] private int keyvalue;
    private Button btn;

    public void OnClickStartButton(){
        Debug.Log("A");
        keypadmanager kpm = GameObject.FindWithTag("keypad").GetComponent<keypadmanager>();
        if(keyvalue < 10){
            kpm.PasswordInput(keyvalue);
        }
        else //10 : enter 11 : clear
        {
            if(keyvalue == 10){
                kpm.enter = true;
            }
            else{
                kpm.clear = true;
            }
        }
        
    }

    void Update(){
        if(btn == null){
            btn = GetComponent<Button>();
        }
    }

}
