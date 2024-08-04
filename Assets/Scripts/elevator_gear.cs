using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator_gear : MonoBehaviour
{
    [SerializeField] float gear_speed;
    [SerializeField] float multiply;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, gear_speed * multiply * Time.deltaTime);
    }
}
