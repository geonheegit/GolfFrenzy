using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class new_camera : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float movamp;
    [SerializeField] private float offset;
    [SerializeField] private float camsize;
    private float velFloat = 0;
    private float smoothTime = 0.5f;


    private Vector3 vel = Vector3.zero;
    private bool isloop;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            isloop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.tag == "Player"){
            isloop = false;
        }
    }

    void FixedUpdate(){
        if(isloop){
            cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position, Time.smoothDeltaTime * movamp);
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, camsize, ref velFloat, smoothTime);
            if(Mathf.Sqrt(Mathf.Pow(transform.position.x - cam.transform.position.x, 2) + Mathf.Pow(transform.position.y - cam.transform.position.y, 2)) < offset){
                isloop = false;
            }
        }
        // Debug.Log(Mathf.Sqrt(Mathf.Pow(transform.position.x - cam.transform.position.x, 2) + Mathf.Pow(transform.position.y - cam.transform.position.y, 2)));

    }
    
}
