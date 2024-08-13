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

    private void Active_forest(bool tf){
        if (tf){
            foreach (GameObject forest in forestBG){
                forest.SetActive(true);
            }
        }
        else{
            foreach (GameObject forest in forestBG){
                forest.SetActive(false);
            }
        }
    }

    private void Active_factory(bool tf){
        if (tf){
            foreach (GameObject factory in factoryBG){
                factory.SetActive(true);
            }
        }
        else{
            foreach (GameObject factory in factoryBG){
                factory.SetActive(false);
            }
        }
    }


    void Update()
    {
        parentBG.transform.position = mainCam.transform.position + new Vector3(0, 0, 1);

        if (currentBG == 1){
            Active_forest(true);
            Active_factory(false);
        }
        else if (currentBG == 2){
            Active_factory(true);
            Active_forest(false);
        }
    }
}
