using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle1_lever_obj_control : MonoBehaviour
{
    [SerializeField] GameObject[] first;
    [SerializeField] GameObject[] second;
    [SerializeField] AudioSource leverPull_SFX;
    public bool first_active = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchObjects(){
        leverPull_SFX.Play();
        
        if (!first_active){
            first_active = true;

            foreach (GameObject obj in first){
                obj.SetActive(true);
            }
            foreach (GameObject obj in second){
                obj.SetActive(false);
            }
        }
        else{
            first_active = false;

            foreach (GameObject obj in first){
                obj.SetActive(false);
            }
            foreach (GameObject obj in second){
                obj.SetActive(true);
            }
        }
    }
}
