using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class checkpoint_controller : MonoBehaviour
{
    // private Camera mainCam;
    // public int currentCamPos;
    // private Vector3 vel = Vector3.zero;
    // private float velFloat = 0f;
    private Vector3 checkpoint;
    private SpriteRenderer spriteRenderer;
    private GameObject ball;
    private Rigidbody2D ballrb;
    public bool touched = false;
    public bool recently_touched = false;
    void Start()
    {
        // mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();

        transform.position = transform.parent.position; // 부모의 위치에 자신의 위치를 맞춤. (부모는 game_manager.cs에서의 체크포인트 지점들.)
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        checkpoint = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && !touched){ // 현재 공이 닿은 체크포인트를 제외한 다른 체크포인트의 recently_touched를 false로.
            GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("CheckpointObj");
            foreach (GameObject checkpoint in checkpoints){
                checkpoint.GetComponent<checkpoint_controller>().recently_touched = false;
            }

            touched = true; // 이미 사용한 체크포인트 색깔 노란색으로 바꾸기 & 다시 터치하는거 방지.
            recently_touched = true; // 현재 체크포인트만 recently_touched를 true. (재시작시 제일 최근 체크포인트로 가는 용도; game_manager.cs에서 활용)

            ball = GameObject.FindWithTag("Player");
            ballrb = ball.GetComponent<Rigidbody2D>();
            ball.transform.position = checkpoint + new Vector3(0, 1f, 0);
            ballrb.velocity = new Vector3(0, 0, 0);

            spriteRenderer.color = Color.yellow;

            // 캠 사이즈
            // if (transform.parent.name == "checkpoint1"){
            //     currentCamPos = 1;
            // }
            // else if (transform.parent.name == "checkpoint2"){
            //     currentCamPos = 2;
            // } 
        }
    }

    void Update()
    {
        // 캠 움직임
        // if (currentCamPos == 1 && recently_touched){ // 1 = levelBorder 1
        //     mainCam.transform.position = Vector3.SmoothDamp(mainCam.transform.position, GameObject.Find("1cam").transform.position + new Vector3(0, 0, -1f), ref vel, 0.5f);
        //     mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 13, ref velFloat, 0.5f);
        // }
        // else if (currentCamPos == 2 && recently_touched){ // 2 = levelBorder 2
        //     mainCam.transform.position = Vector3.SmoothDamp(mainCam.transform.position, GameObject.Find("2cam").transform.position + new Vector3(0, 0, -1f), ref vel, 0.5f);
        //     mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 13, ref velFloat, 0.5f);
        // }
    }
}
