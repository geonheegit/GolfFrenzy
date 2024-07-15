using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    [SerializeField] GameObject ball_prefab;
    [SerializeField] GameObject checkpoint_prefab;

    void Start()
    {
        Instantiate(ball_prefab);

        GameObject[] checkpoint_points = GameObject.FindGameObjectsWithTag("Checkpoint");
        foreach (GameObject point in checkpoint_points){
            Instantiate(checkpoint_prefab, point.transform); // 각 체크포인트 지점의 자식오브젝트로서 체크포인트 오브젝트 instantiate.
        }
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            Destroy(GameObject.FindWithTag("Ball"));
            Instantiate(ball_prefab);
        }
    }
}
