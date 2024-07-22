using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    [SerializeField] GameObject player_prefab;
    [SerializeField] GameObject checkpoint_prefab;
    public int currentCamPos; // level_border.cs

    void Awake()
    {
        Instantiate(player_prefab);

        GameObject[] checkpoint_points = GameObject.FindGameObjectsWithTag("Checkpoint");
        foreach (GameObject point in checkpoint_points){
            Instantiate(checkpoint_prefab, point.transform); // 각 체크포인트 지점의 자식오브젝트로서 체크포인트 오브젝트 instantiate.
        }

        currentCamPos = 0;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            Destroy(GameObject.FindWithTag("Player"));
            Instantiate(player_prefab);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            GameObject.FindWithTag("Player").transform.position = GameObject.Find("Debug1").transform.position;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            GameObject.FindWithTag("Player").transform.position = GameObject.Find("Debug2").transform.position;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)){
            GameObject.FindWithTag("Player").transform.position = GameObject.Find("Debug3").transform.position;
        }
        
    }
}
