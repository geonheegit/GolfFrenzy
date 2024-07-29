using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private GameObject player;
    private BoxCollider2D bc;
    private bool isGoDown;
    [SerializeField] private float yOffset = 1f;
    void Awake(){
        bc = GetComponent<BoxCollider2D>();
    }
    void FixedUpdate(){
        if(!isGoDown && player != null){
            if(player.transform.position.y - yOffset > transform.position.y){
                bc.isTrigger = false;
            }
            else{
                bc.isTrigger = true;
            }
        }
        else{
            bc.isTrigger = true;
        }

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.J)){
            isGoDown = true;
        }
        if(Input.GetKeyUp(KeyCode.J)){
            isGoDown = false;
        }

        if(player == null){
            player = GameObject.FindWithTag("Player");
        }
        
    }
}
