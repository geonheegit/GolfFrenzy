using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_activator : MonoBehaviour
{
    private boss boss;
    [SerializeField] bool activate_boss = true;
    void Start()
    {
        boss = GameObject.FindWithTag("Boss").GetComponent<boss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            if (activate_boss){
                boss.active = true;
            }
            else{
                boss.active = false;
            }
        }
    }
}
