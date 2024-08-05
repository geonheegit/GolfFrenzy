using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_img : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject parentBG;
    [SerializeField] GameObject[] forestBG;
    [SerializeField] GameObject[] factoryBG;
    public int currentBG;
    void Start()
    {
        
        currentBG = 1; // 1: Forest, 2: Factory
        forestBG = GameObject.FindGameObjectsWithTag("BG_forest");
        factoryBG = GameObject.FindGameObjectsWithTag("BG_factory");

        foreach (GameObject forest in forestBG){
            forest.SetActive(false);
        }
        foreach (GameObject factory in factoryBG){
            factory.SetActive(false);
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
        else if (currentBG == 2){
            foreach (GameObject factory in factoryBG){
                factory.SetActive(true);
            }
        }
    }
}
