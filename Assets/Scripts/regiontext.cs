using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class regiontext : MonoBehaviour
{
    [SerializeField] string regionName;
    private regioninfo rginfo;

    void Awake(){
        rginfo = GameObject.FindWithTag("regiontxt").GetComponent<regioninfo>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            rginfo.txt.text = regionName;
            rginfo.txtclr.a = 0;

            rginfo.gofadein = true;
            rginfo.gofadeout = false;

        }
    }

}
