using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charge_bar : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {
        if(Input.GetKeyUp(KeyCode.C))
        {
            Destroy(gameObject);
        }
    }
}
