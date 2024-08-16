using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject[] gears;
    public bool active = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (active){
            transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
            foreach (GameObject gear in gears){
                gear.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }
    }
}
