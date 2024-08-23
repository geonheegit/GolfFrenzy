using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossactivate : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    void Update()
    {
        if(GameObject.FindWithTag("startboss") != null){
            if(GameObject.FindWithTag("startboss").GetComponent<TextPrint>().done){
                boss.SetActive(true);
            }
        }

    }
}
