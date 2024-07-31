using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spark1_animator_controller : MonoBehaviour
{
    public bool playing;
    private Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playing){
            anim.enabled = true;
        }
        else{
            anim.enabled = false;
        }
    }
}
