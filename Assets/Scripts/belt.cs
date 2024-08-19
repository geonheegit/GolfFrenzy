using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class belt : MonoBehaviour
{
    [SerializeField] float power;
    GameObject player;
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            player.transform.position += new Vector3(power, 0, 0);
        }
    }
    void OnCollisionStay2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            player.transform.position += new Vector3(power, 0, 0);
        }
    }

    void Update(){
        if(player == null){
            player = GameObject.FindWithTag("Player");
        }
    }
}
