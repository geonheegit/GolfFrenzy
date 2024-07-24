using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_img : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject parentBG;
    [SerializeField] GameObject[] forestBG;
    public int currentBG;
    void Start()
    {
        
        currentBG = 1; // 1: Forest
        forestBG = GameObject.FindGameObjectsWithTag("BG_forest");

        foreach (GameObject forest in forestBG){
            forest.SetActive(false);
        }

    }


    void Update()
    {
        parentBG.transform.position = mainCam.transform.position + new Vector3(0, 0, 1);

        if (currentBG == 1){
            foreach (GameObject forest in forestBG){
                forest.SetActive(true);
            }
        }
    }
}
